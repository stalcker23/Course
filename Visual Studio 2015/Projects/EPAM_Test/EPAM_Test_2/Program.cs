using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Test_2
{
    //Можно просто запустить цикл и сравнивать элемент требуемый со всеми внутри; так же Linq, лямбда-выражение, событие.
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            

            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(100);
            }
            Array.Sort(array);
            Console.WriteLine("Массив: " + String.Join(" ", array));
            Console.Write("Введите искомый элемент массива  = ");
            int question = int.Parse(Console.ReadLine());
            BinSearch(array, question);
        }
        static void BinSearch(int[]array,int question)
        {
            int a = 0;
            int b = array.Length;
            int m = 0;
            do
            {
                while (a != b)
                {
                    m = (a + b) / 2;
                    if (array[m] == question)
                    {
                        Console.WriteLine("Искомый элемент найден в массиве");
                        return;
                    }
                    else
                    {
                        if (array[m] < question)
                        {
                            a = m + 1;
                        }
                        else
                        {
                            b = m;
                        }
                    }
                }

            }
            while (m != 0);
            Console.WriteLine("Искомый элемент не найден в массиве");
        }

    }
}
   
