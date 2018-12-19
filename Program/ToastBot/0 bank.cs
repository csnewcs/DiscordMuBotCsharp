using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.IO;
using Discord;

namespace ToastBot
{
    class bank
    {
        public async Task Bank (SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playerid = message.Author.Id.ToString();
            string[] array = File.ReadAllLines("Players.txt");
            int arrav = Array.IndexOf(array, playerid);
            string playername = message.Author.Username;
            string turn = "";
            if (arrav >= 0)
            {
                arrav++;
                turn = array[arrav];
            }
            else if (arrav < 0)
            {
                string a = File.ReadAllText("Players.txt");
                string write = a + "\n" + playerid + "\n" + "30";
                File.WriteAllText("Players.txt",write);
                turn = "30";
                arrav = array.Length;
            }
            var builder = new EmbedBuilder()
            .AddField(playername + "님이 가지고 있는 빵의 수는...", turn + "개다뮤~")
            .WithColor(new Color(red, green, blue));
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
    }
}
