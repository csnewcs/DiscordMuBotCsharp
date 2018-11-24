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
            playertext = playertest.Split(' ');
            //명령어들 (commands)
            if (toastid!=playerid && playertext[0] == "토스트")
            {
                if (playertext[1] == "청소") { ToastBot.Clean clean = new ToastBot.Clean(); await clean.clean(message); }
                else if (playertext[1] == "?" || playertext[1] == null) await message.Channel.SendMessageAsync("```현재 토스트가 할 수 있는 것들 (명령어 앞에 토스트를 붙여야 함)\n?:사용 가능한 기능들을 보여준다\n청소:서버에 영 좋지 못한 글이 올라왔을때 입력하면 청소해준다\n빵굽기:운을 테스트 하는 곳\n현재로는 이게 끝```");
                else if (playertext[1] == "빵굽기") {ToastBot.roastbread roastbread = new ToastBot.roastbread(); await roastbread.Roast(message); }
                else if (playertext[1] == "투자")
                {
                    playertext[2] = Regex.Replace(playertext[2], @"\D", "");
                    int bread = int.Parse(playertext[2]);
                    int result = bread;
                    int ran = random.Next(1, 13);
                    if (ran == 1)
                    { result *= 4; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 대성공해 " + result + "개의 빵을 받으셨습니다.");
                        using (StreamWriter outputFile = new StreamWriter(@"..\..\Players.txt"))
                        {
                            
                        }
                    }
                    else if (ran == 2 || ran == 3) { result *= 2; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 성공해 " + result + "개의 빵을 받으셨습니다."); }
                    else if (ran == 4 || ran == 5 || ran == 6) await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 본전을 쳐 " + result + "개의 빵을 받으셨습니다");
                    else if (ran == 7 || ran == 8 || ran == 9) { result /= 4; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 실패해 " + result + "개의 빵을 받으셨습니다."); }
                    else { result /= 8; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 폭망해 " + result + "개의 빵을 받으셨습니다."); }
                }
                else await message.Channel.SendMessageAsync("어? 그건 아직 배우지 않은 말인데, 담에 다시 와 뷁뷁");
            }
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
