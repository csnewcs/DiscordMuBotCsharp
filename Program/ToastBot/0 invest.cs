using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using System.Text.RegularExpressions;

namespace ToastBot
{
    class invest
    {
        public async Task xnwk(SocketMessage message)
        {
            Random random = new Random();
            토스트봇.Program program= new 토스트봇.Program();
            string[] playertext = program.playertext;
            string playername = message.Author.Username;
            playertext[2] = Regex.Replace(playertext[2], @"\D", "");
            int bread = int.Parse(playertext[2]);
            int result = bread;
            int ran = random.Next(1, 13);
            if (ran == 1)
            {
                result *= 4; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 대성공해 " + result + "개의 빵을 받으셨습니다.");
            }
            else if (ran == 2 || ran == 3) { result *= 2; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 성공해 " + result + "개의 빵을 받으셨습니다."); }
            else if (ran == 4 || ran == 5 || ran == 6) await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 본전을 쳐 " + result + "개의 빵을 받으셨습니다");
            else if (ran == 7 || ran == 8 || ran == 9) { result /= 4; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 실패해 " + result + "개의 빵을 받으셨습니다."); }
            else { result /= 8; await message.Channel.SendMessageAsync(playername + "님은 " + bread + "개의 빵을 투자해서 폭망해 " + result + "개의 빵을 받으셨습니다."); }
        }
    }
}
