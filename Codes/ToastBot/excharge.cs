using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace ToastBot
{
    class excharge
    {
        public async void breadtomute(SocketMessage message,string[] playertext)
        {
            Console.WriteLine(0);


            string playerid = message.Author.Id.ToString();
            WebClient client = new WebClient();
            string url = "https://api.myjson.com/bins/183xhk";
            Console.WriteLine(1);
            string readjscoin = "jsonread.json";
            client.DownloadFile(url, readjscoin);
            readjscoin = File.ReadAllText("jsonread.json");
            Console.WriteLine(2);
            Console.WriteLine(readjscoin);
            string[] readcscoin = File.ReadAllLines("Players.txt");
            JObject jscoin = JObject.Parse(readjscoin);
            Console.WriteLine(3);
            int js = int.Parse(jscoin[playerid]["UsersCoin"].ToString());
            int cs = int.Parse(readcscoin[Array.IndexOf(readcscoin,playerid) + 1]);
            cs -= int.Parse(playertext[2]);
            Console.WriteLine(4);
            js += 2 * int.Parse(playertext[2]);
            readcscoin[Array.IndexOf(readcscoin, playerid) + 1] = cs.ToString();
            jscoin[playerid]["UsersCoin"] = js;
            File.WriteAllLines("Players.txt",readcscoin);
            Console.WriteLine(5);
            File.WriteAllText("jsonread.json",jscoin.ToString());
            client.p
            client.UploadFile(url, readjscoin);
            await message.Channel.SendMessageAsync($"송금 완료 ({cs}빵을 {js}MUC로 전환 완료)");
        }
    }
}
