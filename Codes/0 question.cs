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
    .WithTitle("토스트가 사용 가능한 명령어들 (괄호 안은 사용법)")
    .WithDescription("토스트봇 깃헙 사이트는 [여기](https://github.com/hj666c2/Toast)\n\n\n")
    .WithColor(new Color(0x1e5aeb))
    .WithTimestamp(DateTimeOffset.FromUnixTimeMilliseconds(1543103823818))
    .WithFooter(footer =>
    {
        footer
            .WithText("디스코드 뮤봇 C# Version")
            .WithIconUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png")
    ;
    })
    .WithImageUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png")
    .WithAuthor(author =>
    {
        author
            .WithName("PMH Studio / CS")
            .WithUrl("https://discordapp.com")
            .WithIconUrl("https://cdn.discordapp.com/attachments/459706597841567746/521169622246883378/Bot_Profile.png");
    })
    .AddInlineField("토스트 (mu(뮤)!토스트)", "```토스트가 할 수 있는 것들을 보여준다뮤~```")
    .AddInlineField("청소 (mu(뮤)!청소)", "```채팅방을 청소해준다뮤!```")
    .AddInlineField("빵굽기 (mu(뮤)!빵굽기)", "```당신의 운을 시험해봐라뮤!\n만약 빵이 적당히 구워지면 투자가 가능한 빵이 된다뮤!```")
    .AddInlineField("투자 (mu(뮤)!투자 [투자금액])", "```빵굽기로 얻은 빵을 이용해 투자를 한다뮤~\n투자한 금액의 1/4~4배까지 얻을 수 있다뮤!```")
    .AddInlineField("빵은행 (mu(뮤)!빵은행)", "```현재 가지고 있는 빵의 갯수를 보여준다뮤!```")
    .AddInlineField("순위 (mu(뮤)!순위)", "```현재 당신이 몇 등인지 알려준다뮤!\n1등과 얼마나 차이가 나는지도 알려준다뮤~★```")
    .AddInlineField("상위권 (mu(뮤)!상위권)", "```빵을 가장 많이 가지고 있는 사람의 1위~5위까지 보여준다뮤~```")
    .AddField("주의할 점", "```빵의 갯수를 저장하는 곳은 서버가 아니고 호스팅하는 사람의 컴퓨터 속에 있다뮤! \n그래서 서버가 달라도 빵은 계속 이어지고 순위 관련된 명령어는 다른 서버에 있는 사람도 포함한다뮤! \n만약에 이것를 원하지 않는다면 서버에 따라 봇을 새로 만들어서 코드를 집어넣는걸 추천한다뮤~~```")
    .AddField("개발중...","투자 (업데이트)");
            var embed = builder.Build();
            await message.Channel.SendMessageAsync(
                "",
                embed: embed)
                .ConfigureAwait(false);
        }
    }
}
