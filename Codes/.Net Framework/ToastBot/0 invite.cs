using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace ToastBot
{
    class invite
    {
        public async void inv(SocketMessage message, DiscordSocketClient client)
        {
            string botid = client.CurrentUser.Id.ToString();
            string link = @"https://discordapp.com/oauth2/authorize?client_id=" + botid + "&scope=bot";
            await message.Channel.SendMessageAsync(link);
        }
    }
}