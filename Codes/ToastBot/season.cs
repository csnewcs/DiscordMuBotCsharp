using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace ToastBot
{
    class season
    {
        private string[] notepad;
        private int loop = 2;
        public async void Season(DiscordSocketClient client)
        {
            string read = File.ReadAllText("user.json");
            JObject json = JObject.Parse(read);
            read = json["Next"].ToString();
            DateTime todate = Convert.ToDateTime(read);
            DateTime present = DateTime.Now;
            for (;true ; )
            {
                for (; todate != present;)
                {
                    await Task.Delay(100);
                    present = DateTime.Now;
                }
                todate = DateTime.Now.AddDays(80);
                json["Next"] = todate.ToString();
                File.WriteAllText("user.json", json.ToString());
                chltkd();
                ulong getuserid = ulong.Parse(notepad[loop - 1]);
                SocketUser socketUser = client.GetUser(getuserid);
                string write = File.ReadAllText("koseason.txt") +
                    $"시즌 기간: {DateTime.Now.AddDays(160)} ~ {DateTime.Now}\n" +
                    $"1위: {socketUser.Username}\n" +
                    $"1위의 소지금: {notepad[loop - 1]}\n\n";
                File.WriteAllText("koseason.txt",write);
                write = File.ReadAllText("enseason.txt") +
                    $"Season period : {DateTime.Now.AddDays(160)} ~ {DateTime.Now}\n" +
                    $"1st: {socketUser.Username}\n" +
                    $"bread of 1st: {notepad[loop - 1]}\n\n";
                File.WriteAllText("enseason.txt", write);
            }
        }
        private int chltkd()
        {
            loop = 2;
            notepad = File.ReadAllLines("Players.txt");
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
            return best;
        }
    }
}
