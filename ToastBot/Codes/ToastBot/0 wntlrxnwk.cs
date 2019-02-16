using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using Discord.Rest;

namespace ToastBot
{
    class wntlrxnwk
    {
        public async Task wntlr(SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);

            await message.Channel.SendMessageAsync("테스트중...");
            string[] usermessage = message.Content.Split('!',' ');

            if (usermessage[2] == "가격")
            {
                Console.WriteLine("에엥ㅇ에ㅔㅔㅔ에ㅔ");
                string send = File.ReadAllText("qusemd.txt");
                Console.WriteLine(send);
                await message.Channel.SendMessageAsync("```" + send + "```");
            }

            string[] note = File.ReadAllLines("playerhave.txt");
            string[] notepadt = File.ReadAllLines("Players.txt");
            string playerid = message.Author.Id.ToString();
            int player = Array.IndexOf(notepadt,playerid);
            int number = int.Parse(usermessage[4]);
            int playermoney = int.Parse(notepadt[player+1]);
            string price = File.ReadAllText("price.txt");
            string[] pricea = price.Split(' ', '\n');


            if (usermessage[2] == "매수")
            {
                if (usermessage[3] == "HC주식회사")
                {
                    int hprice = int.Parse(pricea[0]) * number;
                    if (playermoney < hprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + hprice + "개의 빵을 투자하려 했지만... 토스트 창고에는" + playermoney + "개의 빵이 있다뮤우~!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[1]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[1]);
                            priceai = int.Parse(pricea[1]) - number;
                            pricea[1] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 1]) + number;
                            note[where + 1] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[0]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "HC주식회사 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }
                }
                else if (usermessage[3] == "뮤트테크")
                {
                    int mprice = int.Parse(pricea[2]) * number;
                    if (playermoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[3]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 뮤트테크는 " + pricea[3] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[3]);
                            priceai = int.Parse(pricea[3]) - number;
                            pricea[3] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 2]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[2]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "뮤트테크 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }

                }
                else if (usermessage[3] == "TK전자")
                {
                    int mprice = int.Parse(pricea[4]) * number;
                    if (playermoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[5]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 TK전자는 " + pricea[5] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[5]);
                            priceai = int.Parse(pricea[5]) - number;
                            pricea[5] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 3]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[4]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "TK전자 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }

                }
                else if (usermessage[3] == "PC가전")
                {
                    int mprice = int.Parse(pricea[6]) * number;
                    if (playermoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[7]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 PC가전은 " + pricea[5] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[7]);
                            priceai = int.Parse(pricea[7]) - number;
                            pricea[7] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 4]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[6]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "PC가전 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }


                }
                else if (usermessage[3] == "피엠산업")
                {
                    int mprice = int.Parse(pricea[8]) * number;
                    if (playermoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[9]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 피엠산업은 " + pricea[9] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[9]);
                            priceai = int.Parse(pricea[9]) - number;
                            pricea[9] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 5]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[8]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "피엠산업 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }


                }
                else if (usermessage[3] == "비빔밥사")
                {
                    int mprice = int.Parse(pricea[10]) * number;
                    if (playermoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                        .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        if (int.Parse(pricea[11]) < number)
                        {
                            var builder = new EmbedBuilder()
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 피엠산업은 " + pricea[11] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                        else
                        {
                            int priceai = int.Parse(pricea[11]);
                            priceai = int.Parse(pricea[11]) - number;
                            pricea[11] = priceai.ToString();
                            string writehave = pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11];
                            File.WriteAllText("price.txt", writehave);

                            int where = Array.IndexOf(note, playerid);
                            int write = int.Parse(note[where + 6]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[10]);
                            int money = int.Parse(notepadt[player + 1]) - pay;
                            notepadt[player + 1] = money.ToString();
                            File.WriteAllLines("Players.txt", notepadt);

                            var builder = new EmbedBuilder()
                            .AddField("완료", "비빔밥사 " + number + "주 구입이 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                            var embed = builder.Build();
                            await message.Channel.SendMessageAsync(
                                "",
                                embed: embed)
                                .ConfigureAwait(false);
                        }
                    }
                }
            }
            else if (usermessage[2] == "매도")
            {
                if (usermessage[4] == "HC주식회사")
                {

                }
                else if (usermessage[4] == "뮤트테크")
                {

                }
                else if (usermessage[4] == "TK전자")
                {

                }
                else if (usermessage[4] == "PC가전")
                {

                }
                else if (usermessage[4] == "피엠산업")
                {

                }
                else if (usermessage[4] == "비빔밥사")
                {

                }
                else
                {

                }
            }
        }
    }
}
