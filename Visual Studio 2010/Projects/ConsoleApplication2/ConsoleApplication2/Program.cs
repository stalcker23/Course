using System;
using System.Collections;
namespace Example
{
    class Program
    {
        public static void Main()
        {
            Console.Write("n= ");
            int n = int.Parse(Console.ReadLine());
            Queue intQ = new Queue();
            for (int i = 1; i <= n; i++)
            {
                intQ.Enqueue(i);
            }
            Console.WriteLine("Размерность очереди {0}", intQ.Count);
            Console.Write("n= ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                intQ.Enqueue(i);
            }
            Console.WriteLine("Размерность очереди {0}", intQ.Count);
        }
    }
}