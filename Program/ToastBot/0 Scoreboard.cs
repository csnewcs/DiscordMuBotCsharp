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
    class Scoreboard
    {
        int loop = -1;
        public async Task wjatn(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("지금 이 명령어는 개발중이다뮤! 다음에 버전업을 해서 이것이 완성되면 그때 사용해라 뮤!");
            string playerid = message.Author.Id.ToString();
            string[] notepad = File.ReadAllLines("Players.txt");
            int a = Array.IndexOf(notepad, playerid);
            if (a < 0)
            {
                string all = File.ReadAllText("Players.txt");
                File.WriteAllText("Players.txt", all + "\n" + playerid + "\n30");
            }
            int[] score = new int[5] { 0, 0, 0, 0, 0 };
            string[] ottff = new string[5] { null, null, null, null, null };
            string[] output = new string[5] { null, null, null, null, null };
            score[0] = chltkd();
            ottff[0] = notepad[loop - 1];
            loop = -1;
            score[1] = chltkd();
            ottff[1] = notepad[loop - 1];
            loop = -1;
            score[2] = chltkd();
            ottff[2] = notepad[loop - 1];
            loop = -1;
            score[3] = chltkd();
            ottff[3] = notepad[loop - 1];
            loop = -1;
            score[4] = chltkd();
            ottff[4] = notepad[loop - 1];
            File.WriteAllLines("Players.txt", notepad);
            if (score[0] > 0)
            { output[0] = ottff[0] + ": " + score[0]; }
            else output[0] = "사...사람이 읍서요!";
            if (score[1] > 0)
            { output[1] = ottff[1] + "\n" + score[1]; }
            else output[1] = "사...사람이 읍서요!";
            if (score[2] > 0) output[2] = ottff[2] + "\n" + score[2];
            else output[2] = "사...사람이 읍서요!";
            if (score[3] > 0)
            { output[3] = ottff[3] + "\n" + score[3]; }
            else output[3] = "사...사람이 읍서요!";
            if (score[4] > 0)
            { output[4] = ottff[4] + "\n" + score[4]; }
            else output[4] = "사...사람이 읍서요!";
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            var builder = new EmbedBuilder()
                .WithTitle("테스트중...")
                .WithColor(new Color(red, green, blue))
                .AddField("1등", "```" + output[0] + "```")
                .AddField("2등", "```" + output[1] + "```")
                .AddField("3등", "```" + output[2] + "```")
                .AddInlineField("4등", "``" + output[3] + "``")
                .AddInlineField("5등", "``" + output[4] + "``");
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
        public static string getnickname(ulong playerid)
        {
            return playerid.ToString();
        }
        public int chltkd()
        {
            string[] notepad = File.ReadAllLines("Players.txt");
            int best = -1;
            int arr = 2;
            int length = notepad.Length;
            while (arr < length)
            {
                if (int.Parse(notepad[arr]) > best)
                {
                    best = int.Parse(notepad[arr]);
                    loop = loop + 3;
                }
                arr = arr + 3;
            }
            notepad[loop] = "0";
            File.WriteAllLines("Players.txt", notepad);
            return best;
        }
    }
}
