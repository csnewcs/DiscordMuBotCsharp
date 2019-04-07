using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord.WebSocket;
using Discord;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ToastBot
{
    public class blacklist
    {
        public bool black(string playerid,SocketMessage message)
        {
            string json = File.ReadAllText(@"user.json");
            bool turn = true;
            try
            {
                JObject jObject = JObject.Parse(json);
                turn = (bool)jObject[playerid]["black"];
            }
            catch
            {
                JObject jObject = JObject.Parse(json);
                JObject user= JObject.FromObject(new {owner = false, black = false });
                jObject.Add(playerid, user);
                File.WriteAllText("user.json",jObject.ToString());
                turn = false;
            }
            if (turn == true) turn = false;
            else turn = true;
            return turn;
        }
        public async Task writeblack(string playerid, SocketMessage message, DiscordSocketClient client)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0,256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            string author = message.Author.Id.ToString();
            string json = File.ReadAllText("user.json");
            bool isowner = false;
            JObject jObject = JObject.Parse(json);
            isowner = (bool)jObject[playerid]["owner"];
            if (isowner)
            {
                string to = message.MentionedUsers.First().Id.ToString();
                var getuser = client.GetUser(ulong.Parse(to));
                if (to == message.Author.Id.ToString())
                {
                    var builder = new EmbedBuilder()
                    .WithColor(red, green, blue)
                    .AddField("작업 결과", $"흠..., {message.Author.Mention}님은 {getuser.Mention}본인 아니냐뮤? 본인을 블랙리스트에 추가할 순 없다뮤!");
                    var embed = builder.Build();
                    await message.Channel.SendMessageAsync(
                        "", embed: embed).ConfigureAwait(false);
                }

                else if ((bool)jObject[to]["owner"] == true)
                {
                    var builder = new EmbedBuilder()
                    .WithColor(red, green, blue)
                    .AddField("작업 결과", $"어허!, {message.Author.Mention}! {getuser.Mention}님은 관리자라 블랙리스트에 추가 못한다뮤!.");
                    var embed = builder.Build();
                    await message.Channel.SendMessageAsync(
                        "", embed: embed).ConfigureAwait(false);
                }
                else
                {
                        jObject[to]["black"] = true;
                        string write = jObject.ToString();
                        File.WriteAllText("user.json", write);
                        var builder = new EmbedBuilder()
                            .WithColor(red, green, blue)
                            .AddField("작업 결과", $"작업 완료!, {message.Author.Mention}님으로 인해 {getuser.Mention}님이 블랙리스트에 추가되었습니다뮤!");
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "", embed: embed).ConfigureAwait(false);
                }
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
        public async Task white(SocketMessage message, DiscordSocketClient client)
        {

        }
    }
}
