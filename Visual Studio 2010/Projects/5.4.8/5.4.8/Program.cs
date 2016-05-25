using System;
namespace _5._4._9
{
    class Program
    {
       static double recurcy(int n, int x)
        {

            if (n == 0)
                return 1;
            else if (n < 0)

                return (1/(double)Math.Pow(x, Math.Abs(n)));

            else
                return (x * recurcy(n - 1, x));


        }


        static void Main()
        {

            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            Console.Write("x=");
            int x = int.Parse(Console.ReadLine());
            double z = recurcy(n,x);
            Console.WriteLine("{0}", z);
        }
    }
}
