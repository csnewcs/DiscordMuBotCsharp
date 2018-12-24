using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ToastBot
{
    class Scoreboard
    {
        public async Task wjatn(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("지금 이 명령어는 개발중이다뮤! 다음에 버전업을 해서 이것이 완성되면 그때 사용해라 뮤!");
        }
    }
}
