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

            string[] usermessage = message.Content.Split('!',' ');

            if (usermessage[2] == "가격")
            {
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
                        .AddField("빵 부족", "당신이 가지고 있는 빵의 갯수보다 더 많은 양의 빵을 투자 할 수 없다뮤! 현재 당신은 " + hprice + "개의 빵을 투자하려 했지만 당신은 " + playermoney + "개의 빵을 가지고 있다뮤!")
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
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 당신은 " + number + "개의 주를 사려고 했다뮤!")
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
                        .AddField("빵 부족", "당신이 가지고 있는 빵의 갯수보다 더 많은 양의 빵을 투자 할 수 없다뮤! 현재 당신은 " + mprice + "개의 빵을 투자하려 했지만 당신은 " + playermoney + "개의 빵을 가지고 있다뮤!")
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
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 HC주식회사는 " + pricea[1] + "개의 주가 있지만 당신은 " + number + "개의 주를 사려고 했다뮤!")
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

                }
                else if (usermessage[3] == "PC가전")
                {

                }
                else if (usermessage[3] == "피엠산업")
                {

                }
                else if (usermessage[3] == "비빔밥사")
                {

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
