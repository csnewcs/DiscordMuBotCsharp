using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace ToastBot
{
    class question
    {
        public async Task anfdmavy(SocketMessage message) => await message.Channel.SendMessageAsync("```현재 토스트가 할 수 있는 것들 (명령어 앞에 토스트를 붙여야 함)\n?:사용 가능한 기능들을 보여준다\n청소:서버에 영 좋지 못한 글이 올라왔을때 입력하면 청소해준다\n빵굽기:운을 테스트 하는 곳\n현재로는 이게 끝```");
    }
}
