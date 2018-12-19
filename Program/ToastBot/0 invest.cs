using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Discord;

namespace ToastBot
{
    class invest
    {
        public async Task xnwk(SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playerid = message.Author.Id.ToString();
            string[] array = File.ReadAllLines("Players.txt");
            string turn = "";
            int arrav = Array.IndexOf(array, playerid);
            if (arrav >= 0)
            {
                arrav++;
                turn = array[arrav];
            }
            else if (arrav < 0)
            {
                string a = File.ReadAllText("Players.txt");
                File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                turn = "30";
                arrav = array.Length;
            }
            string[] playertext = message.Content.Split('!', ' ');
            string playername = message.Author.Username;
            playertext[2] = Regex.Replace(playertext[2], @"\D", "");
            int bread = int.Parse(playertext[2]);
            if (int.Parse(turn) >= bread)
            {
                string send = "";
                int result = bread;
                int ran = random.Next(1, 101);
                if (ran == 100) { result *= 100; send = playername + "! 극악의 확률을 뚫었다 뮤 보상으로 100배로 돌려줄게뮤! " + result + "개 획득"; }
                else if (ran >= 90) { result *= 4; send = playername + "님은 " + bread + "개의 빵을 투자해서 대성공해 " + result + "개의 빵을 받았다뮤!"; }
                else if (ran >= 70) { result *= 2; send = playername + "님은 " + bread + "개의 빵을 투자해서 성공해 " + result + "개의 빵을 받았다뮤!"; }
                else if (ran >= 40) { send = playername + "님은 " + bread + "개의 빵을 투자해서 본전을 쳐 " + result + "개의 빵을 받았다뮤!"; }
                else if (ran >= 10) { result /= 3; send = playername + "님은 " + bread + "개의 빵을 투자해서 실패해 " + result + "개의 빵을 받았다뮤!"; }
                else { result /= 5; send = playername + "님은 " + bread + "개의 빵을 투자해서 폭망해 " + result + "개의 빵을 받았다뮤!"; }
                int skajwl = int.Parse(turn) - bread;
                skajwl = skajwl + result;
                array[arrav] = skajwl.ToString();
                File.WriteAllLines("Players.txt",array);
                var builder = new EmbedBuilder()
            .AddField("결과는...",send)
            .WithColor(new Color(red, green, blue));
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "",
                    embed: embed)
                    .ConfigureAwait(false);
            }
            else
            {
                var builder = new EmbedBuilder()
            .AddField("빵 부족", playername + "님이 가지고 있는 빵으로는 투자가 불가능 하다뮤! \n빵 개수를 줄이거나 빵굽기로 빵을 늘려라뮤!\n" + playername + "님은 " + turn + "개의 빵을 가지고 있다뮤!")
            .WithColor(new Color(red, green, blue));
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "",
                    embed: embed)
                    .ConfigureAwait(false);
            }
        }
    }
}
