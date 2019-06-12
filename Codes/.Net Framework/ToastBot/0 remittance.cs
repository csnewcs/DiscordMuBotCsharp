using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastBot
{
    class remittance
    {
        public async void remi(SocketMessage message, DiscordSocketClient client)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0,256);
            byte green = (byte)random.Next(0,256);
            byte blue = (byte)random.Next(0, 256);
            string[] tell = message.Content.Split(' ', '!');
            var to = client.GetUser(509573176825741312);
            ulong toid = 0;
            try
            {
                to = client.GetUser(message.MentionedUsers.First().Id) as SocketUser;
                toid = to.Id;
            }
            catch
            {
                try
                {
                  to = client.GetUser(ulong.Parse(tell[2])) as SocketUser;
                  toid = to.Id;
                }
                catch
                {
                    await message.Channel.SendMessageAsync("뮤...? 지금 누구에게 보내려 한거냐뮤? 그런 사람은 없다뮤!");
                    goto end;
                }
            }
            string[] notepad = File.ReadAllLines("Players.txt");
            int fromindex = Array.IndexOf(notepad, message.Author.Id.ToString());
            int toindex = Array.IndexOf(notepad, toid.ToString());
            if (toindex < 0)
            {
                var builder = new EmbedBuilder()
                              .AddField("사람 없음", "현재 그 사람은 여기에 가입이 되어있지 않다뮤!\n그 사람이 토스트의 명령어를 사용하면 된다뮤우~")
                              .WithColor(new Color(red, green, blue));
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "",
                    embed: embed)
                    .ConfigureAwait(false);
                await message.Channel.SendMessageAsync("");
            }
            int frommoney = int.Parse(notepad[fromindex+1]);
            if (frommoney - int.Parse(tell[3]) < 0) 
            {
                var builder = new EmbedBuilder()
                           .AddField("빵 부족", "뮤? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + tell[3] + "개의 빵을 보내려 했지만... 토스트 창고에는 " + frommoney + "개의 빵이 있다뮤우~!")
                           .WithColor(new Color(red, green, blue));
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "",
                    embed: embed)
                    .ConfigureAwait(false);
                await message.Channel.SendMessageAsync("");
            }
            else
            {
                int get = int.Parse(notepad[toindex + 1]) + int.Parse(tell[3]);
                int give = frommoney - int.Parse(tell[3]);
                notepad[toindex + 1] = get.ToString();
                notepad[fromindex + 1] = give.ToString();
                File.WriteAllLines("Players.txt",notepad);
                var builder = new EmbedBuilder()
                           .AddField("완료", tell[2] + "님께 " + tell[3] + "개의 빵을 정상적으로 보냈다뮤!")
                           .WithColor(new Color(red, green, blue));
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "",
                    embed: embed)
                    .ConfigureAwait(false);
                await message.Channel.SendMessageAsync("");
            }
        end:;
        }
    }
}