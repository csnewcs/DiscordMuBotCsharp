using System;
using Discord;
using Discord.WebSocket;
using Discord.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Discord.Webhook;
using System.IO;

namespace 토스트봇
{
    class Program
    {
        //public 변수들
        public string[] playertext;
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public async Task MainAsync()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.Log += Log;
            string token = "Your Bot Token";
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            client.MessageReceived += MessageReceived;
            client.Ready += Client_Ready;
            client.GuildAvailable += Client_GuildAvailable;
            await Task.Delay(-1); // 프로그램 종료시까지 태스크 유지  
        }

        private Task Client_GuildAvailable(SocketGuild arg)
        {
            arg.DefaultChannel.SendMessageAsync("토스트");
            return Task.CompletedTask;
        }

        private Task Client_Ready() { return Task.CompletedTask; }

        public async Task MessageReceived(SocketMessage message)
        {
            //사용자가 입력한 말 변수에 입력 (Word entered by users enter in Variables)
            string playertest = message.Content.ToString();
            string playername = message.Author.Username;
            string playerid = message.Author.Id.ToString();
            string toastid = "Your Bot ID";
            playertext = playertest.Split(' ', '!');
            //명령어들 (commands)
            if (toastid!=playerid && playertext[0] == "mu")
            {
                if (playertext[1] == "청소") { ToastBot.Clean clean = new ToastBot.Clean(); await clean.clean(message); }
                else if (playertext[1] == "토스트" || playertext[1] == "") { ToastBot.question question= new ToastBot.question(); await question.anfdmavy(message); }
                else if (playertext[1] == "빵굽기") {ToastBot.roastbread roastbread = new ToastBot.roastbread(); await roastbread.Roast(message); }
                else if (playertext[1] == "투자"){ToastBot.invest invest = new ToastBot.invest(); await invest.xnwk(message); }
                else if (playertext[1] == "빵은행") { ToastBot.bank bank = new ToastBot.bank(); await bank.Bank(message); }
            }
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
