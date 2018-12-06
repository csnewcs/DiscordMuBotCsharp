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
namespace ToastBot
{
    class invest
    {
        public async Task xnwk(SocketMessage message)
        {
            Random random = new Random();
            string playerid = message.Author.Id.ToString();
            string[] array = File.ReadAllLines("Players.txt");
            string turn = "";
            int arrav = Array.BinarySearch(array, playerid);
            if (arrav >= 0)
            {
                turn = array[arrav+1];
            }
            else if (arrav < 0)
            {
                string a = File.ReadAllText("Players.txt");
                File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                turn = "30";
                arrav = array.Length-1;
            }
            string[] playertext = message.Content.Split('!', ' ');
            string playername = message.Author.Username;
            playertext[2] = Regex.Replace(playertext[2], @"\D", "");
            int bread = int.Parse(playertext[2]);
            if (int.Parse(turn) >= bread)
            {
                int result = bread;
                int ran = random.Next(1, 101);
                if (ran == 100) { result *= 100; await message.Channel.SendMessageAsync(playername + "! 극악의 확률을 뚫었다 뮤 보상으로 100배로 돌려줄게뮤! " + result + "개 획득"); }
                else if (ran >= 70) { result *= 4; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 대성공해 " + result + "개의 빵을 받았다뮤!"); }
                else if (ran >= 50) { result *= 2; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 성공해 " + result + "개의 빵을 받았다뮤!"); }
                else if (ran >= 20) await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 본전을 쳐 " + result + "개의 빵을 받았다뮤!");
                else if (ran >= 10) { result /= 3; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 실패해 " + result + "개의 빵을 받았다뮤!"); }
                else { result /= 5; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 폭망해 " + result + "개의 빵을 받았다뮤!"); }
                int skajwl = int.Parse(turn) - bread;
                skajwl = skajwl + result;
                array[arrav + 1] = skajwl.ToString();
                string 총 = string.Join("\n",array);
                File.WriteAllLines("Players.txt",array);
            }
            else
            {
                await message.Channel.SendMessageAsync("당신의 빵 저장소에 있는 빵으로는 투자가 불가능 하다 뮤! 빵굽기로 벌거나 금액을 낮추라 뮤!");
            }
        }
    }
}
