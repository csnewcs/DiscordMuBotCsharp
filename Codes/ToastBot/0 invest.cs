using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.Text.RegularExpressions;
using System.IO;
using Discord;

namespace ToastBot
{
    class invest
    {
        public async Task xnwk(SocketMessage message)
        {
            string[] ab = message.Content.Split('!', ' ');
            if (ab[2] == "0") await message.Author.SendFileAsync("koseason.txt");
            else if (ab[2] == "1") await message.Author.SendFileAsync("enseason.txt");
        }
    }
}
