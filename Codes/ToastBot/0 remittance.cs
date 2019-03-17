using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastBot
{
    class remittance
    {
        public async Task remi(SocketMessage message)
        {
            string[] notepad = File.ReadAllLines("Players.txt");
            string[] tell = message.Content.Split(' ', '!');
            int index = Array.IndexOf(notepad, message.Author.Id.ToString());
            
        }
    }
}