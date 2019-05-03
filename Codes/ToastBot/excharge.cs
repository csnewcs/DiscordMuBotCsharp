using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;

namespace ToastBot
{
    class excharge
    {
        public async void breadtomute(SocketMessage message,string[] playertext)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playerid = message.Author.Id.ToString();
            string[] readfile = File.ReadAllLines("price.txt");
            int price = int.Parse(readfile[6]);

            WebClient client = new WebClient();
            string url = "https://api.myjson.com/bins/183xhk";
            string readjscoin = client.DownloadString(url);
            string[] readcscoin = File.ReadAllLines("Players.txt");
            JObject jscoin = JObject.Parse(readjscoin);
            int js = int.Parse(jscoin[playerid]["UsersCoin"].ToString());
            int cs = int.Parse(readcscoin[Array.IndexOf(readcscoin,playerid) + 1]);
            cs -= int.Parse(playertext[3]);
            if (cs < 0)
            {
                var builder = new EmbedBuilder()
                    .WithColor(red,green,blue)
                    .AddField("빵부족", $"{message.Author.Username} 지금 뭐하냐뮤? 잔고를 확인해 보라뮤! 당신은 {int.Parse(playertext[3])}개의 빵이 필요하지만 당신은 {cs}만큼의 빵이 모자라다뮤!");
                Discord.Embed embed = builder.Build();
                await message.Channel.SendMessageAsync("",embed:embed).ConfigureAwait(false); }
            else
            {
                js += price * int.Parse(playertext[3]);
                readcscoin[Array.IndexOf(readcscoin, playerid) + 1] = cs.ToString();
                jscoin[playerid]["UsersCoin"] = js;
                File.WriteAllLines("Players.txt", readcscoin);
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(url, "Put", jscoin.ToString());
                var builder = new EmbedBuilder()
                    .WithColor(red, green, blue)
                    .AddField("환전 완료", $"{int.Parse(playertext[3])}빵을 {price * int.Parse(playertext[3])}MUC로 전환 완료");
                Discord.Embed embed = builder.Build();
                await message.Channel.SendMessageAsync("", embed:embed).ConfigureAwait(false);
            }
        }

        public async void mutetobread(SocketMessage message, string[] playertext)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playerid = message.Author.Id.ToString();
            string[] readfile = File.ReadAllLines("price.txt");
            int price = int.Parse(readfile[6]);

            WebClient client = new WebClient();
            string url = "https://api.myjson.com/bins/183xhk";
            string readjscoin = client.DownloadString(url);
            string[] readcscoin = File.ReadAllLines("Players.txt");
            JObject jscoin = JObject.Parse(readjscoin);
            int js = int.Parse(jscoin[playerid]["UsersCoin"].ToString());
            int cs = int.Parse(readcscoin[Array.IndexOf(readcscoin, playerid) + 1]);
            js -= price * int.Parse(playertext[3]);
            if (js < 0)
            {
                var builder = new EmbedBuilder()
          .WithColor(red, green, blue)
          .AddField("빵부족", $"{message.Author.Username} 지금 뭐하냐뮤? 잔고를 확인해 보라뮤! 당신은 {int.Parse(playertext[3]) * price}개의 MUC가 필요 했지만 당신은 {js}만큼의 MUC가 모자라다뮤!");
                Discord.Embed embed = builder.Build();
                await message.Channel.SendMessageAsync("", embed: embed).ConfigureAwait(false);
            }
            else
            {
                cs += int.Parse(playertext[3]);
                readcscoin[Array.IndexOf(readcscoin, playerid) + 1] = cs.ToString();
                jscoin[playerid]["UsersCoin"] = js;
                File.WriteAllLines("Players.txt", readcscoin);
                client.Headers.Add("Content-Type", "application/json");
                client.UploadString(url, "Put", jscoin.ToString());
                var builder = new EmbedBuilder()
                    .WithColor(red, green, blue)
                    .AddField("환전 완료", $"{price * int.Parse(playertext[3])}MUC를 {int.Parse(playertext[3])}빵으로 전환 완료");
                Discord.Embed embed = builder.Build();
                await message.Channel.SendMessageAsync("", embed: embed).ConfigureAwait(false);
            }
        }
        public async void price()
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
        }
    }
}
