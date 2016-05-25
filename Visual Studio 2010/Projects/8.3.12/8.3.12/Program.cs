
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
 
namespace _8._3._12
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите сообщение");
            string[]vvod = Console.ReadLine().Split(' ','.',',','!','?');
            int max=0;
           
            for (int i = 0; i < vvod.GetLength(0); i++)
            {
                if (vvod[i].Length > max)
                {
                    max = vvod[i].Length;
                }
            }
            Console.WriteLine("Самое(-ые) длинное(-ые) слово(-а): ");
            for (int i = 0; i < vvod.GetLength(0); i++)
            {
                if (vvod[i].Length == max)
                {
                    Console.WriteLine(" {0} ", vvod[i]);
                }
            }

 
            Console.ReadKey();
 
 
        }
    }
}
