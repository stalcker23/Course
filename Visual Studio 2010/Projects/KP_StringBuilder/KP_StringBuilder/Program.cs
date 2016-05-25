using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KP_StringBuilder
{

    class Program
    {
        static void Main()
        {
            StringBuilder a = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Дана строка: {0}", a);

            char[] chars = new char[2];
            for (int i = 0; i < 2 ; i++ )
            {
              chars[i] = char.Parse(Console.ReadLine());
            }
            int count = 0;
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int x = 0; x < a.Length; x++)
            {
                if ((a[x] == chars[0]) || (a[x] == chars[1]))
                {
                    count++;
                }
            }
            time.Stop();
            Console.WriteLine("Символы {0} и {1}  встречаются в ней {2} раз   {3}", chars[0], chars[1], count, time.ElapsedTicks);

        }

    }
}
            
          
            