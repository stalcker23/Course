using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{

    class Program
    {
        static void Main(string[] args)
        
        {
            double a = 0;
            double b = 40;
            double h = 1;

            int index = 0;
            int size = (int)Math.Ceiling((Math.Abs(a-b) / h));
            double[] x = new double[size+1];
            double[] RESULT = new double[size+1];
            double[] NUMBER = new double[size+1];
            for (double i=a;i<b;i+=h)
            {
                
                double n = 2;
                double f = 1;
                double res = 0;
                int stepen = 2;
                int count = 2;
                while (Math.Abs(f) >= Math.Pow(10, -10))
                {
                    
                   
                    f = Math.Pow(-1, count) * Math.Pow(i, stepen) / n;
                    n*= (count*2 - 1) * 2*count;
                    res += f;
                    stepen += 2;
                    count++;

                }

                x[index] = i;
                RESULT[index] = Math.Round(res,5);
                NUMBER[index] = count-1;
                index++;
                }
            
            for (int i = 0; i < size; i ++)
                Console.Write("{0} ", x[i]);
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.Write("{0} ", RESULT[i]);
            Console.WriteLine();
            for (int i = 0; i < size; i++)
                Console.Write("{0} ", NUMBER[i]);

        }
    }
}
