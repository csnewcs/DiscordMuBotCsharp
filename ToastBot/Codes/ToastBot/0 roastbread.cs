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
    class roastbread
    {
        public async Task Roast(SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string playername = message.Author.Username;
            int coin = random.Next(1, 7);
            string send = "";
            if (coin == 1)
            { send = "차가워뮤...(빵 1개 생성)";
                string[] array = File.ReadAllLines("Players.txt");
                string playerid = message.Author.Id.ToString();
                int arrav = Array.IndexOf(array, playerid);
                string turn = "";
                if (array.Contains(playerid))
                {
                    turn = array[arrav + 1];
                }
                else
                {
                    string a = File.ReadAllText("Players.txt");
                    File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                    turn = "30";
                    arrav = array.Length - 1;
                }
                int rufrhk = int.Parse(turn) + 1;
                array[arrav + 1] = rufrhk.ToString();
                File.WriteAllLines("Players.txt", array);
            }
            else if (coin == 2)
            {
                send = "설익었다뮤~ (빵 3개 생성)";
                string[] array = File.ReadAllLines("Players.txt");
                string playerid = message.Author.Id.ToString();
                int arrav = Array.IndexOf(array, playerid);
                string turn = "";
                if (array.Contains(playerid))
                {
                    turn = array[arrav + 1];
                }
                else
                {
                    string a = File.ReadAllText("Players.txt");
                    File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                    turn = "30";
                    arrav = array.Length - 1;
                }
                int rufrhk = int.Parse(turn) + 3;
                array[arrav + 1] = rufrhk.ToString();
                File.WriteAllLines("Players.txt", array);
            }
            else if (coin == 3)
            { send = "적당하게 구워졌다뮤! (빵 5개 생성)";
                string[] array = File.ReadAllLines("Players.txt");
                string playerid = message.Author.Id.ToString();
                int arrav = Array.IndexOf(array, playerid);
                string turn = "";
                if (array.Contains(playerid))
                {
                    turn = array[arrav + 1];
                }
                else
                {
                    string a = File.ReadAllText("Players.txt");
                    File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                    turn = "30";
                    arrav = array.Length - 1;
                }
                int rufrhk = int.Parse(turn) + 5;
                array[arrav+1] = rufrhk.ToString();
                File.WriteAllLines("Players.txt", array);
            }
            else if (coin == 4)
            { send = "뜨겁다뮤~ (빵 3개 생성)";
                string[] array = File.ReadAllLines("Players.txt");
                string playerid = message.Author.Id.ToString();
                int arrav = Array.IndexOf(array, playerid);
                string turn = "";
                if (array.Contains(playerid))
                {
                    turn = array[arrav + 1];
                }
                else
                {
                    string a = File.ReadAllText("Players.txt");
                    File.WriteAllText("Players.txt", a + "\n" + playerid + "\n30");
                    turn = "30";
                    arrav = array.Length - 1;
                }
                int rufrhk = int.Parse(turn) + 3;
                array[arrav + 1] = rufrhk.ToString();
                File.WriteAllLines("Players.txt", array);
            }
            else if (coin == 5)
            { send = "타버렸다뮤...."; }
            else
            { send = playername + " : 빵? 누가 다 먹어서 읎다뮤!"; }
            var builder = new EmbedBuilder()
            .AddField(playername + "의 빵굽기 결과",send)
            .WithColor(new Color(red, green, blue));
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
    }
}
