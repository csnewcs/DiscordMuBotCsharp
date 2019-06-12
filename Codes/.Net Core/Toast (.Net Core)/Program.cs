using System;
using Discord;
using Discord.WebSocket;
using Discord.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Discord.Webhook;
using System.IO;
using System.Diagnostics;

namespace 토스트봇
{
    class Program
    {
        DiscordSocketClient client = new DiscordSocketClient();
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            string token = muto();
            client.Log += Log;
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            client.MessageReceived += MessageReceived;
            client.Ready += Client_Ready;
            client.GuildAvailable += Client_GuildAvailable;
            cycle();
            await Task.Delay(-1); 
        }

        public Task Client_GuildAvailable(SocketGuild arg)
        {
            arg.DefaultChannel.SendMessageAsync("");
            return Task.CompletedTask;
        }

        public Task Client_Ready() { return Task.CompletedTask; }
        
        public void cycle()
        {
            ToastBot.spin spin = new ToastBot.spin();
            ToastBot.season season = new ToastBot.season();
            spin.Cycle();
            spin.mutecycle();
            season.Season(client);
        }

        public async Task MessageReceived(SocketMessage message)
        {
            //사용자가 입력한 말 변수에 입력 (Word entered by users enter in Variables)
            string playertest = message.Content.ToString();
            string playername = message.Author.Username;
            ulong playerid = message.Author.Id;
            bool isbot = client.GetUser(playerid).IsBot;
            string[] playertext = playertest.Split('!', ' ');
            ToastBot.blacklist blacklist = new ToastBot.blacklist(); bool black = blacklist.black(playerid.ToString(), message);
            Random random = new Random();
            //명령어 인식 & 실행
            if (isbot != true)
            {
                if (playertext[0] == "mu" || playertext[0] == "뮤")
                {
                    if (black)
                    {
                        string playerids = playerid.ToString();
                        string[] wntlr = File.ReadAllLines("playerhave.txt");
                        string[] array = File.ReadAllLines("Players.txt");
                        int arrav = Array.IndexOf(array, playerids);
                        int wntll = Array.IndexOf(wntlr, playerids);
                        if (wntll < 0)
                        {
                            File.WriteAllText("playerhave.txt", File.ReadAllText("playerhave.txt") + "\n" + playerid + "\n0\n0\n0\n0\n0\n0");
                            wntlr = File.ReadAllLines("playerhave.txt");
                            wntll = Array.IndexOf(wntlr, playerids);
                        }
                        if (arrav < 0)
                        {
                            string a = File.ReadAllText("Players.txt");
                            string write = a + "\n" + playerid + "\n" + "30\n";
                            File.WriteAllText("Players.txt", write);
                        }

                        if (playertext[1] == "청소") { ToastBot.Clean clean = new ToastBot.Clean(); clean.clean(message); }
                        else if (playertext[1] == "토스트") { ToastBot.question question = new ToastBot.question(); question.anfdmavy(message); }
                        else if (playertext[1] == "빵굽기") { ToastBot.roastbread roastbread = new ToastBot.roastbread(); roastbread.Roast(message); }
                        else if (playertext[1] == "명예의전당") { ToastBot.invest invest = new ToastBot.invest(); invest.xnwk(message); }
                        else if (playertext[1] == "빵은행") { ToastBot.bank bank = new ToastBot.bank(); bank.Bank(message); }
                        else if (playertext[1] == "순위") { ToastBot.rank rank = new ToastBot.rank(); rank.tnsdnl(message); }
                        else if (playertext[1] == "상위권") { ToastBot.Scoreboard scoreboard = new ToastBot.Scoreboard(); scoreboard.wjatn(message, client); }
                        else if (playertext[1] == "주식투자") { ToastBot.wntlrxnwk wntlrxnwk = new ToastBot.wntlrxnwk(); wntlrxnwk.wntlr(message); }
                        else if (playertext[1] == "송금") { ToastBot.remittance remittance = new ToastBot.remittance(); remittance.remi(message, client); }
                        else if (playertext[1] == "초대") { ToastBot.invite invite = new ToastBot.invite(); invite.inv(message, client); }
                        else if (playertext[1] == "블랙") { blacklist.writeblack(playerids,message,client); }
                        else if (playertext[1] == "화이트") { blacklist.white(message, client); }
                        else if (playertext[1] == "재시작") { ToastBot.reboot reboot = new ToastBot.reboot(); reboot.rebooting(client,message); }
                        else if (playertext[1] == "환전"&& playertext[2] == "뮤트코인으로") { ToastBot.excharge excharge = new ToastBot.excharge(); excharge.breadtomute(message,playertext); }
                        else if (playertext[1] == "환전" && playertext[2] == "빵으로") { ToastBot.excharge excharge = new ToastBot.excharge(); excharge.mutetobread(message, playertext); }
                        else if (playertext[1] == "환전" && playertext[2] == "가격") { ToastBot.excharge excharge = new ToastBot.excharge(); excharge.price(message); }
                    }
                }
            }
        }
        public Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        public string muto()
        {
            string muto = "MuBot Token";
            try
            {
                muto = File.ReadAllLines("config.txt")[0];
            }
            catch
            {
                muto = Environment.GetEnvironmentVariable("muto");
            }
            return muto;
        }
    }
}
