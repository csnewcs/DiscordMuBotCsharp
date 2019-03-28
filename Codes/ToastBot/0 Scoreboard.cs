using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;
using Discord.Commands;
using Discord.Net;
using Discord.Rpc;


namespace ToastBot
{
    class Scoreboard
    {
        int loop = 2;

        public async Task wjatn(SocketMessage message, DiscordSocketClient client)
        {
            string playerid = message.Author.Id.ToString();
            string[] notepad = File.ReadAllLines("Players.txt");
            int a = Array.IndexOf(notepad,playerid);
            if (a < 0)
            {
                string all = File.ReadAllText("Players.txt");
                File.WriteAllText("Players.txt", all + "\n" + playerid + "\n30");
            }
            notepad = File.ReadAllLines("Players.txt");
            string notuse = File.ReadAllText("Players.txt");
            int[] score = new int[5] {-100, -100, -100, -100, -100 };
            ulong[] ottff = new ulong[5] { 0, 0, 0, 0, 0 };
            string[] output = new string[5];
            
            score[0] = chltkd();
            ottff[0] = ulong.Parse(notepad[loop - 1]);

            score[1] = chltkd();
            ottff[1] = ulong.Parse(notepad[loop - 1]);

            score[2] = chltkd();
            ottff[2] = ulong.Parse(notepad[loop - 1]);

            score[3] = chltkd();
            ottff[3] = ulong.Parse(notepad[loop - 1]);

            score[4] = chltkd();
            ottff[4] = ulong.Parse(notepad[loop - 1]);

            File.WriteAllText("Players.txt", notuse);

            string[] playername = getnickname(ottff, client);

            if (playername[0] == null) playername[0] = "이 서버에 없는 사람이다뮤 =ㅇ=";
            if (playername[1] == null) playername[1] = "이 서버에 없는 사람이다뮤 =ㅇ=";
            if (playername[2] == null) playername[2] = "이 서버에 없는 사람이다뮤 =ㅇ=";
            if (playername[3] == null) playername[3] = "이 서버에 없는 사람이다뮤 =ㅇ=";
            if (playername[4] == null) playername[4] = "이 서버에 없는 사람이다뮤 =ㅇ=";

            File.WriteAllLines("Players.txt", notepad);
            if (score[0] > -1)
            { output[0] = playername[0] + ": " + score[0]+"개"; }
            else output[0] = "사...사람이 읍서요!";
            if (score[1] > -1)
            { output[1] = playername[1] + ": " + score[1]+"개"; }
            else output[1] = "사...사람이 읍서요!";
            if (score[2] > -1)
            { output[2] = playername[2] + ": " + score[2]+"개"; }
            else output[2] = "사...사람이 읍서요!";
            if (score[3] > -1)
            { output[3] = playername[3] + ": " + score[3]+"개"; }
            else output[3]= "사...사람이 읍서요!";
            if (score[4] > -1)
            { output[4] = playername[4] + ": " + score[4]+"개"; }
            else output[4] = "사...사람이 읍서요!";


            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            var builder = new EmbedBuilder()
                .WithTitle("누가누가 빵이 가장 많을까뮤?")
                .WithColor(new Color(red, green, blue))
                .AddField("1등", "```"+output[0]+"```")
                .AddField("2등", "```"+output[1]+"```")
                .AddField("3등", "```"+output[2]+"```")
                .AddField("4등", "``"+output[3]+"``",true)
                .AddField("5등", "``" +output[4]+"``",true);
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
        public string[] getnickname(ulong[] playerid, DiscordSocketClient client)
        {
            var getp1 = client.GetUser(playerid[0]) as SocketUser;
            var getp2 = client.GetUser(playerid[1]) as SocketUser;
            var getp3 = client.GetUser(playerid[2]) as SocketUser;
            var getp4 = client.GetUser(playerid[3]) as SocketUser;
            var getp5 = client.GetUser(playerid[4]) as SocketUser;
            string[] nickname = new string[5];

            nickname[0] = getp1?.Username;

            nickname[1] = getp2?.Username;

            nickname[2] = getp3?.Username;

            nickname[3] = getp4?.Username;

            nickname[4] = getp5?.Username;
            return nickname;
        }
        public int chltkd()
        {
            loop = 2;
            string[] notepad = File.ReadAllLines("Players.txt");
            int best = int.Parse(notepad[2]);
            int arr = 5;
            int length = notepad.Length;
            while (arr <= length)
            {
                int parse = int.Parse(notepad[arr]);
                if (parse >= best)
                {
                    best = parse;
                    loop = arr;
                }
                arr = arr + 3;
            }
            notepad[loop] = "-1";
            File.WriteAllLines("Players.txt", notepad);
            return best;
        }
    }
}
