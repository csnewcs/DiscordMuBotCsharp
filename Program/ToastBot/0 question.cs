using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace ToastBot
{
    class question
    {
        public async Task anfdmavy(SocketMessage message)
        {
            var builder = new EmbedBuilder()
    .WithTitle("토스트가 사용 가능한 명령어들")
    .WithDescription("토스트봇 깃헙 사이트는 [여기](https://github.com/hj666c2/Toast)\n\n\n")
    .WithColor(new Color(0x1e5aeb))
    .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1543103823818))
    .WithFooter(footer => {
        footer
            .WithText("디스코드 뮤봇 C# Version")
            .WithIconUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png")
    ;
    })
    .WithThumbnailUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png")
    .WithImageUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png")
    .WithAuthor(author => {
        author
            .WithName("PMH Studio / CS")
            .WithUrl("https://discordapp.com")
            .WithIconUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png");
    })
    .AddField("?","토스트가 할 수 있는 것들을 보여준다뮤~")
    .AddField("청소", "채팅방을 청소해준다뮤! ~~핸드폰에서는 아닌 듯 하다~~뮤!")
    .AddField("빵굽기", "당신의 운을 시험해봐라뮤~ 만약 빵이 적당히 구워지면 투자가 가능한 빵이 된다뮤!")
    .AddField("투자", "빵굽기로 얻은 빵을 이용해 투자를 한다뮤~ 투자한 금액의 1/4~4배까지 얻을 수 있다뮤! ~~잘만 하면 다른 결과가 나올지도?~~")
    .AddInlineField("빵은행", "현재 가지고 있는 빵의 갯수를 보여준다뮤!")
    .AddInlineField("개발중...", "순위");
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
    }
}
