using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Test_5
{   //Пройти двумя форами можно, сравнивая элементы. Можно XOR-ом.
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayForSearch = new int[] { 2, 5, 3, 8, 0, 5, 2, 0, 8 ,3 , 1, 7, 7, 1, 9 };
            var p = arrayForSearch.Where(a => arrayForSearch.Count(x => x == a) == 1);
            foreach (var k in p)
            Console.WriteLine(k);
        }
    }
}
