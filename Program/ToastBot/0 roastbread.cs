using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ToastBot
{
    class roastbread
    {
        public async Task Roast(SocketMessage message)
        {
            Random random = new Random();
            string playername = message.Author.Username;
            int coin = random.Next(1, 7);
            if (coin == 1)
            { await message.Channel.SendMessageAsync(playername + " : 차가워..."); }
            else if (coin == 2)
            { await message.Channel.SendMessageAsync(playername + " : 겉은 따뜻 속은 차갑"); }
            else if (coin == 3)
            { await message.Channel.SendMessageAsync(playername + " : 적당적당"); }
            else if (coin == 4)
            { await message.Channel.SendMessageAsync(playername + " : 겉은 뜨겁 속은 따뜻"); }
            else if (coin == 5)
            { await message.Channel.SendMessageAsync(playername + " : 타버렸어..."); }
            else
            { await message.Channel.SendMessageAsync(playername + " : 빵? 누가 다 먹어서 읎서요!"); }
        }
    }
}
