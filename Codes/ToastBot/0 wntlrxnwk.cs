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
        public async void wntlr(SocketMessage message)
        {
            Random random = new Random();
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);

            string[] usermessage = message.Content.Split('!', ' ');

            if (usermessage[2] == "가격")
            {
                string[] getprice = File.ReadAllText("price.txt").Split(' ', '\n');
                string[] update = File.ReadAllLines("time.txt");

                string phc, pmu, ptk, ppc, ppm, pbm = "";
                int hc, mu, tk, pc, pm, bm = 0;

                if (int.Parse(update[2]) < int.Parse(getprice[0]))
                {
                    hc = int.Parse(getprice[0]) - int.Parse(update[2]);
                    phc = $"{hc}(▲)";
                }
                else
                {
                    hc = int.Parse(update[2]) - int.Parse(getprice[0]);
                    phc = $"{hc}(▼)";
                }

                if (int.Parse(update[3]) < int.Parse(getprice[2]))
                {
                    mu = int.Parse(getprice[2]) - int.Parse(update[3]);
                    pmu = $"{mu}(▲)";
                }
                else
                {
                    mu = int.Parse(update[3]) - int.Parse(getprice[2]);
                    pmu = $"{mu}(▼)";
                }

                if (int.Parse(update[4]) < int.Parse(getprice[4]))
                {
                    tk = int.Parse(getprice[4]) - int.Parse(update[4]);
                    ptk = $"{tk}(▲)";
                }
                else
                {
                    tk = int.Parse(update[4]) - int.Parse(getprice[4]);
                    ptk = $"{tk}(▼)";
                }

                if (int.Parse(update[5]) < int.Parse(getprice[6]))
                {
                    pc = int.Parse(getprice[6]) - int.Parse(update[5]);
                    ppc = $"{pc}(▲)";
                }
                else
                {
                    pc = int.Parse(update[5]) - int.Parse(getprice[6]);
                    ppc = $"{pc}(▼)";
                }

                if (int.Parse(update[6]) < int.Parse(getprice[8]))
                {
                    pm = int.Parse(getprice[8]) - int.Parse(update[6]);
                    ppm = $"{pm}(▲)";
                }
                else
                {
                    pm = int.Parse(update[6]) - int.Parse(getprice[8]);
                    ppm = $"{pm}(▼)";
                }

                if (int.Parse(update[7]) < int.Parse(getprice[10]))
                {
                    bm = int.Parse(getprice[10]) - int.Parse(update[7]);
                    pbm = $"{bm}(▲)";
                }
                else
                {
                    bm = int.Parse(update[7]) - int.Parse(getprice[10]);
                    pbm = $"{bm}(▼)";
                }

                EmbedBuilder builder = new EmbedBuilder()
                    .WithTitle("현재 주식의 가격과 남은 주 수")
                    .WithColor(red,green,blue)
                    .AddField("마지막 업데이트 시각",update[0],false)
                    .AddField("HC주식회사 가격", "```" + getprice[0] + "```", true)
                    .AddField("HC주식회사 상, 하락", "```" + phc + "```", true)
                    .AddField("HC주식회사 남은 주 수", "```" + getprice[1].ToString() + "```", true)
                    .AddField("뮤트테크 가격", "```" + getprice[2] + "```", true)
                    .AddField("뮤트테크 상, 하락", $"```{pmu}```", true)
                    .AddField("뮤트테크 남은 주 수", "```" + getprice[3] + "```", true)
                    .AddField("TK전자 가격", "```" + getprice[4] + "```", true)
                    .AddField("TK전자 상, 하락", $"```{ptk}```", true)
                    .AddField("TK전자 남은 주 수", "```" + getprice[5] + "```", true)
                    .AddField("PC가전 가격", "```" + getprice[6] + "```", true)
                    .AddField("PC가전 상, 하락", $"```{ppc}```", true)
                    .AddField("PC가전 남은 주 수", "```" + getprice[7] + "```", true)
                    .AddField("피엠산업 가격", "```" + getprice[8] + "```", true)
                    .AddField("피엠산업 상, 하락", $"```{ppm}```", true)
                    .AddField("피엠산업 남은 주 수", "```" + getprice[9] + "```", true)
                    .AddField("비빔밥사 가격", "```" + getprice[10] + "```", true)
                    .AddField("비빔밥사 상, 하락", $"```{pbm}```", true)
                    .AddField("비빔밥사 남은 주 수", "```" + getprice[11] + "```", true)
                    .AddField("다음 업데이트 시각",update[1],false);
                Embed embed = builder.Build();
                await message.Channel.SendMessageAsync("",embed:embed).ConfigureAwait(false);
            }
            if (usermessage[2] == "매수")
            {

                string[] note = File.ReadAllLines("playerhave.txt");
                string[] notepadt = File.ReadAllLines("Players.txt");
                string moneywhid = message.Author.Id.ToString();
                int where = Array.IndexOf(note, moneywhid);
                int moneywh = Array.IndexOf(notepadt, moneywhid);
                int number = int.Parse(usermessage[4]);
                int moneywhmoney = int.Parse(notepadt[moneywh + 1]);
                string price = File.ReadAllText("price.txt");
                string[] pricea = price.Split(' ', '\n');


                if (usermessage[3] == "HC주식회사")
                {
                    int hprice = int.Parse(pricea[0]) * number;
                    if (moneywhmoney < hprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + hprice + "개의 빵을 투자하려 했지만... 토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 1]) + number;
                            note[where + 1] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[0]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                    if (moneywhmoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + mprice + "개의 빵을 투자하려 했지만... 토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 2]) + number;
                            note[where + 2] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[2]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                    if (moneywhmoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤 ? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + mprice + "개의 빵을 투자하려 했지만...토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 3]) + number;
                            note[where + 3] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[4]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                    if (moneywhmoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤 ? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + mprice + "개의 빵을 투자하려 했지만...토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 4]) + number;
                            note[where + 4] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[6]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                    if (moneywhmoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤 ? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + mprice + "개의 빵을 투자하려 했지만...토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 5]) + number;
                            note[where + 5] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[8]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                    if (moneywhmoney < mprice)
                    {
                        var builder = new EmbedBuilder()
                        .AddField("빵 부족", "뮤 ? 지금 뭐하냐뮤..? 그만큼에 빵은 없다뮤!\n" + mprice + "개의 빵을 투자하려 했지만...토스트 창고에는 " + moneywhmoney + "개의 빵이 있다뮤우~!")
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
                            .AddField("주식 부족", "주식이 다 팔려버렸다뮤! 현재 비빔밥사는 " + pricea[11] + "개의 주가 있지만 " + number + "개의 주를 사려고 했다뮤!")
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

                            where = Array.IndexOf(note, moneywhid);
                            int write = int.Parse(note[where + 6]) + number;
                            note[where + 6] = write.ToString();
                            File.WriteAllLines("playerhave.txt", note);

                            int pay = number * int.Parse(pricea[10]);
                            int money = int.Parse(notepadt[moneywh + 1]) - pay;
                            notepadt[moneywh + 1] = money.ToString();
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
                else { await message.Channel.SendMessageAsync("어? 그런 주식은 없는데, 이름을 확인하고 다시 해봐라뮤!"); }
            }
            else if (usermessage[2] == "매도")
            {

                string[] note = File.ReadAllLines("playerhave.txt");
                string[] notepadt = File.ReadAllLines("Players.txt");
                string moneywhid = message.Author.Id.ToString();
                int where = Array.IndexOf(note, moneywhid);
                int moneywh = Array.IndexOf(notepadt, moneywhid);
                int number = int.Parse(usermessage[4]);
                int moneywhmoney = int.Parse(notepadt[moneywh + 1]);
                string price = File.ReadAllText("price.txt");
                string[] pricea = price.Split(' ', '\n');


                if (usermessage[3] == "HC주식회사")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 1]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 1] = result.ToString();
                        int money = int.Parse(pricea[0]) * sell;
                        int wntlr = int.Parse(pricea[1]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[1] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "HC주식회사 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else if (usermessage[3] == "뮤트테크")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 2]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 2] = result.ToString();
                        int money = int.Parse(pricea[2]) * sell;
                        int wntlr = int.Parse(pricea[3]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[3] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "뮤트테크 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else if (usermessage[3] == "TK전자")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 3]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 3] = result.ToString();
                        int money = int.Parse(pricea[4]) * sell;
                        int wntlr = int.Parse(pricea[5]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[5] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "TK전자 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else if (usermessage[3] == "PC가전")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 4]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 4] = result.ToString();
                        int money = int.Parse(pricea[6]) * sell;
                        int wntlr = int.Parse(pricea[7]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[7] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "PC가전 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else if (usermessage[3] == "피엠산업")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 5]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 5] = result.ToString();
                        int money = int.Parse(pricea[8]) * sell;
                        int wntlr = int.Parse(pricea[9]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[9] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "피엠산업 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else if (usermessage[3] == "비빔밥사")
                {
                    int he = Array.IndexOf(note, message.Author.Id.ToString());
                    int have = int.Parse(note[he + 6]);
                    int sell = int.Parse(usermessage[4]);
                    if (have < sell)
                    {
                        var builder = new EmbedBuilder()
                              .AddField("주식 부족", "당신은 지금 " + have + "개의 주가 있지만 당신은" + sell + "개의 주를 팔려고 했다뮤!")
                              .WithColor(new Color(red, green, blue));

                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                    else
                    {
                        int result = have - sell;
                        note[he + 6] = result.ToString();
                        int money = int.Parse(pricea[10]) * sell;
                        int wntlr = int.Parse(pricea[11]) + sell;
                        int resultmoney = int.Parse(notepadt[moneywh + 1]) + money;
                        notepadt[moneywh + 1] = resultmoney.ToString();
                        pricea[11] = wntlr.ToString();
                        File.WriteAllText("price.txt", pricea[0] + " " + pricea[1] + "\n" + pricea[2] + " " + pricea[3] + "\n" + pricea[4] + " " + pricea[5] + "\n" + pricea[6] + " " + pricea[7] + "\n" + pricea[8] + " " + pricea[9] + "\n" + pricea[10] + " " + pricea[11]);
                        File.WriteAllLines("playerhave.txt", note);
                        File.WriteAllLines("Players.txt", notepadt);
                        var builder = new EmbedBuilder()
                            .AddField("완료", "비빔밥사 " + sell + "주 판매가 정상적으로 완료되었다뮤!")
                            .WithColor(new Color(red, green, blue));
                        var embed = builder.Build();
                        await message.Channel.SendMessageAsync(
                            "",
                            embed: embed)
                            .ConfigureAwait(false);
                    }
                }
                else
                {
                    var builder = new EmbedBuilder()
                             .AddField("명령어 틀림", "뮤...? 당신이 뭘 하려고 했는지는 모르겠지만 틀렸다뮤! 사용법을 다시 알려줄게뮤!\n(뮤!|mu!)주식투자 (매수|매도|) (회사이름) (사고 팔 주 수)")
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
}