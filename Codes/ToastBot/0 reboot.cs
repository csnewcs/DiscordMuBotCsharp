using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;
using Discord;
using System.IO;

namespace ToastBot
{
    class reboot
    {
        DiscordSocketClient client = new DiscordSocketClient();
        public async Task rebooting(DiscordSocketClient clien, SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 255);
            byte green = (byte)random.Next(0, 255);
            byte blue = (byte)random.Next(0, 255);
            JObject json = JObject.Parse(File.ReadAllText("user.json"));
            ulong id = message.Author.Id;
            bool isowner = (bool)json[id.ToString()]["owner"];

            if (isowner)
            {
                토스트봇.Program program = new 토스트봇.Program();
                await clien.LogoutAsync();
                System.Threading.Thread.Sleep(5000);
                System.Diagnostics.Process.Start("taskkill.exe", "/f /im ConsoleApp1.exe");
                program.MainAsync();
            }
            else
            {
                var builder = new EmbedBuilder()
                      .WithColor(red, green, blue)
                      .AddField("작업 결과", message.Author.Mention + ", 어허 어디서 관리자만 사용 가능한 명령어를!");
                var embed = builder.Build();
                await message.Channel.SendMessageAsync(
                    "", embed: embed).ConfigureAwait(false);
            }
        }
    }
}
