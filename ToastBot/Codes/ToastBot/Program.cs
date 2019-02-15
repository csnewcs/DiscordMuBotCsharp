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
        string[] info = File.ReadAllLines(@"..\..\..\..\..\..\info.txt");
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            Process.Start("ConsoleApp1.exe");
            client.Log += Log;
            string token = info[0];
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            client.MessageReceived += MessageReceived;
            client.Ready += Client_Ready;
            client.GuildAvailable += Client_GuildAvailable;
            await Task.Delay(-1); 
        }

        private Task Client_GuildAvailable(SocketGuild arg)
        {
            arg.DefaultChannel.SendMessageAsync("");
            return Task.CompletedTask;
        }

        private Task Client_Ready() { return Task.CompletedTask; }

        public async Task MessageReceived(SocketMessage message)
        {
            
            DiscordSocketClient client = new DiscordSocketClient();
            client.Log += Log;
            //사용자가 입력한 말 변수에 입력 (Word entered by users enter in Variables)
            string playertest = message.Content.ToString();
            string playername = message.Author.Username;
            string playerid = message.Author.Id.ToString();
            string toastid = info[1];
            string[] playertext = playertest.Split('!', ' ');
            Random random = new Random();
            //명령어 인식 & 실행
            if (toastid!=playerid)
            {
                if (playertext[0] == "mu" || playertext[0] == "뮤")
                {
                    if (playertext[1] == "청소") { ToastBot.Clean clean = new ToastBot.Clean(); await clean.clean(message); }
                    else if (playertext[1] == "토스트") { ToastBot.question question = new ToastBot.question(); await question.anfdmavy(message); }
                    else if (playertext[1] == "빵굽기") { ToastBot.roastbread roastbread = new ToastBot.roastbread(); await roastbread.Roast(message); }
                    else if (playertext[1] == "투자") { ToastBot.invest invest = new ToastBot.invest(); await invest.xnwk(message); }
                    else if (playertext[1] == "빵은행") { ToastBot.bank bank = new ToastBot.bank(); await bank.Bank(message); }
                    else if (playertext[1] == "순위") { ToastBot.rank rank = new ToastBot.rank(); await rank.tnsdnl(message); }
                    else if (playertext[1] == "상위권") { ToastBot.Scoreboard scoreboard = new ToastBot.Scoreboard(); await scoreboard.wjatn(message); }
                    else if (playertext[1] == "주식투자") { ToastBot.wntlrxnwk wntlrxnwk = new ToastBot.wntlrxnwk(); await wntlrxnwk.wntlr(message); }
                }
            }
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
