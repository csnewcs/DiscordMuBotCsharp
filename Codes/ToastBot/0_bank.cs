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
            DiscordSocketClient client = new DiscordSocketClient();
            ulong playeridu = message.Author.Id;
            ulong guildidu = message.Channel.Id;
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playerid = message.Author.Id.ToString();
            string nickname = (message.Channel as SocketTextChannel)?.Guild?.GetUser(playerid[0])?.Nickname;
            if (nickname == null) nickname = (message.Channel as SocketTextChannel)?.Guild?.GetUser(playeridu)?.Username;
            string[] array = File.ReadAllLines("Players.txt");
            string[] wntlr = File.ReadAllLines("playerhave.txt");
            int arrav = Array.IndexOf(array, playerid);
            int wntll = Array.IndexOf(wntlr, playerid);
            if (wntll < 0)
            {
                File.WriteAllText("playerhave.txt", File.ReadAllText("playerhave.txt") + playerid + "\n0\n0\n0\n0\n0\n0");
                wntlr = File.ReadAllLines("playerhave.txt");
                wntll = Array.IndexOf(wntlr, playerid);
            }
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
            if (wntll < 0)
            {
                File.WriteAllText("playerhave.txt", File.ReadAllText("playerhave.txt") + playerid + "\n0\n0\n0\n0\n0\n0");
                wntlr = File.ReadAllLines("playerhave.txt");
            }
            wntll = Array.IndexOf(wntlr, playerid);
            var builder = new EmbedBuilder()
            .AddField(nickname + "님이 가지고 있는 빵의 수는...", turn + "개다뮤~")
            .AddField("그리고 주식 수는...", "HC주식회사: " + wntlr[wntll+1] + "주\n뮤트테크: " + wntlr[wntll+2] + "주\nTK전자: " + wntlr[wntll+3] + "주\nPC가전: " + wntlr[wntll+4] + "주\n피엠산업: " + wntlr[wntll+5] + "주\n비빔밥사: " + wntlr[wntll+6] + "주")
            .WithColor(new Color(red, green, blue));
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
    }
}
