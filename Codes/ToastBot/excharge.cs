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
            string playerid = message.Author.Id.ToString();
            WebClient client = new WebClient();
            string url = "https://api.myjson.com/bins/183xhk";
            string readjscoin = await client.DownloadStringTaskAsync(url);
            string[] readcscoin = File.ReadAllLines("Players.txt");
            JObject jscoin = JObject.Parse(readjscoin); 
            int js = int.Parse(jscoin[playerid]["usersCoin"].ToString());
            int cs = int.Parse(readcscoin[Array.IndexOf(readcscoin,playerid) + 1]);
            cs -= int.Parse(playertext[2]);
            js += 2 * int.Parse(playertext[2]);
            readcscoin[Array.IndexOf(readcscoin, playerid) + 1] = cs.ToString();
            jscoin[playerid]["usersCoin"] = js;
            File.WriteAllLines("",readcscoin);
        }
    }
}
