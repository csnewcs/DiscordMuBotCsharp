using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;

namespace ToastBot
{
    class rank
    {
        public async Task tnsdnl(SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);

            int arr = 2;
            string[] money = File.ReadAllLines("Players.txt");
            int biggest;
            string playername = message.Author.Username;
            string playerid = message.Author.Id.ToString();
            int he = Array.IndexOf(money, playerid);

            if (he < 0)
            {
                biggest = 30;
                string notepad = File.ReadAllText("Players.txt");
                File.WriteAllText("Players.txt", notepad + "\n" + playerid + "\n30");
            }

            else biggest = int.Parse(money[he + 1]);
            int rank = 0;
            int playermoney = biggest;
            while (arr <= money.Length)
            {
                if (int.Parse(money[arr]) > biggest)
                {
                    biggest = int.Parse(money[arr]);
                    rank++;
                }
                arr = arr+3;
            }
            int ckdl = biggest - playermoney;
            var builder = new EmbedBuilder()
                .AddField(playername + "의 등수는...", rank + "등이다뮤~")
                .AddField("그리고 1등과의 차이는...", "빵 " + ckdl + "개다뮤!")
                .WithColor(new Color(red, green, blue));
            var embed = builder.Build();
            await message.Channel.SendMessageAsync("", embed: embed)
                .ConfigureAwait(false);
        }
    }
}
