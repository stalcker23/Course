using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._3._20
{
    class Program
    {
       
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0,5} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Input(out int[,] a)
        {
            Console.Write("n= ");
           int n = int.Parse(Console.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static void F(int[,] a)
        {
            int min = 0;

            for (int j = 0; j < a.GetLength(1); j++)
            {
                min = a[0,j];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < min)
                    min = a[i, j];
                }

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] == min)
                    {
                        a[i, j] = 0;

                    }
                }
            }
        }
        
        static void Main()
        {
            int[,] a;
            Input(out a);
            F(a);
            Console.WriteLine("Исходный двумерный массив:");
            Print(a);

        }
    }
}

