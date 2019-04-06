using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord.WebSocket;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ToastBot
{
    public class blacklist
    {
        public bool black(string playerid,SocketMessage message)
        {
            string json = File.ReadAllText(@"user.json");
            bool turn = true;
            try
            {
                JObject jObject = JObject.Parse(json);
                turn = (bool)jObject[playerid]["black"];
            }
            catch
            {
                JObject jObject = JObject.Parse(json);
                JObject user= JObject.FromObject(new {owner = false, black = false });
                jObject.Add(playerid, user);
                File.WriteAllText("user.json",jObject.ToString());
                turn = false;
            }
            if (turn == true) turn = false;
            else turn = true;
            return turn;
        }
        public Task writeblack(string playerid, SocketMessage message, DiscordSocketClient client)
        {
            Task.Delay(1);
            return Task.CompletedTask;
        }
    }
}
