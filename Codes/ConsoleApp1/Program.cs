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

            a:
            Thread.Sleep(1000);
            while (hour != uphour || minute != upminute)
            {
                time = DateTime.Now;
                hour = (byte)time.Hour;
                minute = (byte)time.Minute;
                Thread.Sleep(10000);
            }
            upminute += 5;
            if (upminute >= 60)
            {
                uphour += 1;
                upminute -= 60;
            }
            if (uphour >= 24)
            {
                uphour -= 24;
            }

            string[] notepad = File.ReadAllLines("price.txt");
            string[] har = notepad[0].Split(' ');
            int h = int.Parse(har[0]);
            int 원래 = h;
            byte ha = (byte)random.Next(45,58);
            byte hb = (byte)random.Next(1, 101);
            byte hc = (byte)random.Next(1, 41);
            if (hb <= ha) h += hc;
            else h -= hc;
            if (h < 0) { h = 원래; hc = 0; }
            har[0] = h.ToString();
            string hf = har[0] + " " + har[1];
            notepad[0] = hf;

            string[] mar = notepad[1].Split(' ');
            int m = int.Parse(mar[0]);
            int 뮤 = m;
            byte ma = (byte)random.Next(44,57);
            byte mb = (byte)random.Next(1, 101);
            byte mc = (byte)random.Next(1, 33);
            if (mb <= ma) m += mc;
            else m -= mc;
            if (m < 0) { m = 뮤; mc = 0; }
            mar[0] = m.ToString();
            string mf = mar[0] + " " + mar[1];
            notepad[1] = mf;

            string[] tar = notepad[2].Split(' ');
            int t = int.Parse(tar[0]);
            int TK = t;
            byte ta = (byte)random.Next(35,46);
            byte tb = (byte)random.Next(1, 101);
            byte tc = (byte)random.Next(1, 101);
            if (tb <= ta) t += tc;
            else t -= tc;
            if (t < 0) { t = TK; tc = 0; }
            tar[0] = t.ToString();
            string tf = tar[0] + " " + tar[1];
            notepad[2] = tf;

            string[] par = notepad[3].Split(' ');
            int p = int.Parse(par[0]);
            int PC = p;
            byte pa = (byte)random.Next(43,56);
            byte pb = (byte)random.Next(1, 101);
            byte pc = (byte)random.Next(1, 26);
            if (pb <= pa) p += pc;
            else p -= pc;
            if (p < 0) { p = PC; pc = 0; }
            par[0] = p.ToString();
            string pf = par[0] + " " + par[1];
            notepad[3] = pf;

            string[] pmar = notepad[4].Split(' ');
            int pm = int.Parse(pmar[0]);
            int PM = pm;
            byte pma = (byte)random.Next(42,54);
            byte pmb = (byte)random.Next(1, 101);
            byte pmc = (byte)random.Next(1, 21);
            if (pmb <= pma) pm += pmc;
            else pm -= pmc;
            if (pm < 0) { pm = PM; pmc = 0; }
            pmar[0] = pm.ToString();
            string pmf = pmar[0] + " " + pmar[1];
            notepad[4] = pmf;

            string[] bar = notepad[5].Split(' ');
            int bm = int.Parse(bar[0]);
            int BM = bm;
            byte ba = (byte)random.Next(41,53);
            byte bb = (byte)random.Next(1, 101);
            byte bc = (byte)random.Next(1, 13);
            if (bb <= ba) bm += bc;
            else bm -= bc;
            if (bm < 0) { bm = BM; bc = 0; }
            bar[0] = bm.ToString();
            string bmf = bar[0] + " " + bar[1];
            notepad[5] = bmf;

            Console.WriteLine("\n\n" + time.Day + "일 " + hour + "시 " + minute + "분 " + time.Second + "초 업데이트 완료");
            Console.WriteLine("\n다음 업데이트 시각: " + uphour + "시 " + upminute + "분");
            File.WriteAllText("time.txt",hour+"시 " + minute+"분\n" + uphour+"시 " + upminute+"분");
            File.WriteAllLines("price.txt", notepad);

            goto a;
        }
    }
}
