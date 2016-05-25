using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            int length = 5;
            int[,] mas = new int[length, length];
            for (int i = 0; i < length; i++)
            {

                for (int j = 0; j < length; j++)
                {
                    mas[i, j] = 0;

                }

            }
            for (int i = 0; i < length; i++)
            {
                int count = 0;
                for (int j = i; j < length; j++)
                {
                    if (count < 3)
                    {
                        if (j - 1 != -1) mas[i, j - 1] = j;
                        mas[i, j] = j + 1;
                        if (j + 1 != length) mas[i, j + 1] = j + 2;
                    }
                    count++;
                }

            }
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(mas[i, j] + " ");

                }
                Console.WriteLine();

            }
            System.Threading.Thread.Sleep(5000);
        }
    }
