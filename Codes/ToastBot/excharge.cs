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
        public async void breadtomute(SocketMessage message)
        {
            string playerid = message.Author.Id.ToString();
            WebClient client = new WebClient();
            string url = "https://api.myjson.com/bins/183xhk";
            string readjscoin = await client.DownloadStringTaskAsync(url);
            JObject jscoin = JObject.Parse(readjscoin);
            int js = int.Parse(jscoin[playerid]["usersCoin"].ToString());
        }
    }
}
