using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
namespace KP_Regex
{

    class Program
    {
        static void Main()
        {
            string p = @"1|2";
            Regex r = new Regex(p, RegexOptions.IgnoreCase);
            string a=Console.ReadLine();

            int count=0;
            Stopwatch time = new Stopwatch();
            time.Start();
            Match tel = r.Match(a);
            MatchCollection ALL = r.Matches(a);
            DateTime stop = DateTime.Now;
            time.Stop();
            Console.WriteLine("Количество символов 1 и 2 в тексте в тексте {0} {1}", ALL.Count, time.ElapsedTicks); 
           

        }

    }
}

