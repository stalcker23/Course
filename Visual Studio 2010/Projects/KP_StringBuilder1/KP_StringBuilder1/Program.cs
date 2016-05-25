using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KP_StringBuilder1
{
    class Program
    {

        static int IndexOf(StringBuilder str, StringBuilder str2, int n)
        {
            int i, j;
            for (i = n; i < str.Length; )
            {
                if (str[i] == str2[0])
                {
                    for (j = 1; j < str2.Length && i + j < str.Length; j++)
                    {
                        if (str2[j] != str[i + j])
                        {
                            break;
                        }
                    }
                    if (j == str2.Length)
                    {
                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder(Console.ReadLine()); 
            Console.WriteLine("Дана строка: {0}", str);
            StringBuilder X = new StringBuilder(Console.ReadLine());
            StringBuilder Y = new StringBuilder(Console.ReadLine());
            int i = 0;
            int j = 0;// Числовая переменная, контролирующая итерации цикла
            int n1 = -1;
            int n2 = -1;
            Stopwatch time = new Stopwatch();
            time.Start();
            int count1 = -1; 
            int count2 = -1; 
            while (i != -1)
            {
                i = IndexOf(str, X, n1 + 1);
                n1 = i; // соответственно присваиваем номер индекса первого значения, что б потом (n1+1) начать со следующего
                count1++;  // Увеличиваем на единицу наше количество
                while (j != -1)
                {
                    j = IndexOf(str, Y, n2 + 1);
                    n2 = j; // соответственно присваиваем номер индекса первого значения, что б потом (n2+1) начать со следующего
                    count2++;  // Увеличиваем на единицу наше количество
                }
            }
            time.Stop();


            Console.WriteLine("Символы {0} и {1}  встречаются в ней {2} раз   {3}", X, Y, count1 + count2, time.ElapsedTicks);

        }
    }
}
