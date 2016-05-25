using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {


            string str = Console.ReadLine();
            Console.WriteLine("Дана строка: {0}", str);
            string X = Console.ReadLine();
            string Y = Console.ReadLine();
            int i = 0;
            int j = 0;
            int n1 = -1;
            int n2 = -1;
            Stopwatch time = new Stopwatch();
            time.Start();
            int count1 = -1; 
            int count2 = -1; 
            while (i != -1)
            {
                i = str.IndexOf(X, n1 + 1); // получаем индекс первого вхождения  х+1 говорит, что начинать нужно с 0-го индекса, тоесть с буквы "П"
                n1 = i; // соответственно присваиваем номер индекса первого значения, что б потом (х+1) начать со следующего
                count1++;  
                while (j != -1)
                {
                    j = str.IndexOf(Y, n2 + 1); // получаем индекс первого вхождения  y+1 говорит, что начинать нужно с 0-го индекса
                    n2 = j; // соответственно присваиваем номер индекса первого значения, что б потом (х+1) начать со следующего
                    count2++;  
                }
            }

            time.Stop();


            Console.WriteLine("Символы {0} и {1}  встречаются в ней {2} раз   {3}", X, Y, count1 + count2, time.ElapsedTicks);
        }
    }
}