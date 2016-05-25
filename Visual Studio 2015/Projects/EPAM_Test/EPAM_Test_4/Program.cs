using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Test_4
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int integers=0;
            //for (int i = 0; i < 1001; i++)
            //{
            //    if ((i % 3 == 0) || (i % 5 == 0))
            //        integers += i;
            //}
            integers = (3+999)*(999/3)/2+(5+1000)*(1000/5)/2-(15+990)*(1000/15/2);
            Console.WriteLine(integers);
        }
        
    }
}
