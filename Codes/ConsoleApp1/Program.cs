using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            DateTime time = DateTime.Now;
            byte hour = (byte)time.Hour;
            byte minute = (byte)time.Minute;
            byte uphour = hour;
            byte upminute = minute;
            string notepadout;

            a:
            Thread.Sleep(1000);
            while (hour < uphour || minute < upminute)
            {
                time = DateTime.Now;
                hour = (byte)time.Hour;
                minute = (byte)time.Minute;
                Thread.Sleep(10000);
            }
            notepadout = "마지막 업데이트 시각: " + uphour + ":" + upminute + "\n\n회사명    원래 가격    현재 가격    상, 하락 폭    남은 주 수";
            upminute += 5;
            if (upminute >= 60)
            {
                uphour += 1;
                upminute -= 60;
            }
            if (uphour >= 23)
            {
                uphour -= 24;
            }


            string[] notepad = File.ReadAllLines("price.txt");
            string[] har = notepad[0].Split(' ');
            int h = int.Parse(har[0]);
            int 원래 = h;
            byte ha = (byte)random.Next(55,76);
            byte hb = (byte)random.Next(1, 101);
            byte hc = (byte)random.Next(1, 41);
            if (hb <= ha) h += hc;
            else h -= hc;
            if (h < 0) { h = 원래; hc = 0; }
            har[0] = h.ToString();
            string hf = har[0] + " " + har[1];
            notepad[0] = hf;
            Console.WriteLine("\n\n\nHC원래: "+ 원래 + "\n상승 확률: " + ha + "\n상 하락 폭: " + hc + "\n결과: " + h);
            notepadout += "\nHC주식회사   " + 원래 + "       " + h + "              " + hc + "             " + har[1];

            string[] mar = notepad[1].Split(' ');
            int m = int.Parse(mar[0]);
            int 뮤 = m;
            byte ma = (byte)random.Next(50,71);
            byte mb = (byte)random.Next(1, 101);
            byte mc = (byte)random.Next(1, 33);
            if (mb <= ma) m += mc;
            else m -= mc;
            if (m < 0) { m = 뮤; mc = 0; }
            mar[0] = m.ToString();
            string mf = mar[0] + " " + mar[1];
            notepad[1] = mf;
            Console.WriteLine("\n\n\nMU원래: " + 뮤 + "\n상승 확률: " + ma + "\n상 하락 폭: " + mc + "\n결과: " + m);
            notepadout += "\n뮤트테크        " + 뮤 + "       " + m + "              " + mc + "            " + mar[1];

            string[] tar = notepad[2].Split(' ');
            int t = int.Parse(tar[0]);
            int TK = t;
            byte ta = (byte)random.Next(10,51);
            byte tb = (byte)random.Next(1, 101);
            byte tc = (byte)random.Next(1, 101);
            if (tb <= ta) t += tc;
            else t -= tc;
            if (t < 0) { t = TK; tc = 0; }
            tar[0] = t.ToString();
            string tf = tar[0] + " " + tar[1];
            notepad[2] = tf;
            Console.WriteLine("\n\n\nTK원래: " + TK + "\n상승 확률: " + ta + "\n상 하락 폭: " + tc + "\n결과: " + t);
            notepadout += "\nTK전자           " + TK + "          " + t + "           " + tc + "          " + tar[1];

            string[] par = notepad[3].Split(' ');
            int p = int.Parse(par[0]);
            int PC = p;
            byte pa = (byte)random.Next(40,60);
            byte pb = (byte)random.Next(1, 101);
            byte pc = (byte)random.Next(1, 26);
            if (pb <= pa) p += pc;
            else p -= pc;
            if (p < 0) { p = PC; pc = 0; }
            par[0] = p.ToString();
            string pf = par[0] + " " + par[1];
            notepad[3] = pf;
            Console.WriteLine("\n\n\nPC원래: " + PC + "\n상승 확률: " + pa + "\n상 하락 폭: " + pc + "\n결과: " + p);
            notepadout += "\nPC가전          " + PC + "         " + p + "             " + pc + "           " + par[1];

            string[] pmar = notepad[4].Split(' ');
            int pm = int.Parse(pmar[0]);
            int PM = pm;
            byte pma = (byte)random.Next(35,55);
            byte pmb = (byte)random.Next(1, 101);
            byte pmc = (byte)random.Next(1, 21);
            if (pmb <= pma) pm += pmc;
            else pm -= pmc;
            if (pm < 0) { pm = PM; pmc = 0; }
            pmar[0] = pm.ToString();
            string pmf = pmar[0] + " " + pmar[1];
            notepad[4] = pmf;
            Console.WriteLine("\n\n\nPM원래: " + PM + "\n상승 확률: " + pma + "\n상 하락 폭: " + pmc + "\n결과: " + pm);
            notepadout += "\n피엠산업        " + PM + "          " + pm + "             " + pmc + "            " + pmar[1];

            string[] bar = notepad[5].Split(' ');
            int bm = int.Parse(bar[0]);
            int BM = bm;
            byte ba = (byte)random.Next(35,50);
            byte bb = (byte)random.Next(1, 101);
            byte bc = (byte)random.Next(1, 13);
            if (bb <= ba) bm += bc;
            else bm -= bc;
            if (bm < 0) { bm = BM; bc = 0; }
            bar[0] = bm.ToString();
            string bmf = bar[0] + " " + bar[1];
            notepad[5] = bmf;
            Console.WriteLine("\n\n\n비빔원래: " + BM + "\n상승 확률: " + ba + "\n상 하락 폭: " + bc + "\n결과: " + bm);
            notepadout += "\n비빔밥사         " + BM+ "            " + bm + "              " + bc + "          " + bar[1];


            Console.WriteLine("\n다음 업데이트 시각: " + uphour + "시 " + upminute + "분");
            notepadout += "\n\n다음 업데이트 시각: " + uphour + "시 " + upminute + "분";
            File.WriteAllLines("price.txt", notepad);
            File.WriteAllText("변등.txt",notepadout);

            goto a;
        }
    }
}
