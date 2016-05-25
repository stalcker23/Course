using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
namespace EPAM_Test_3
{   // Не совсем понял то, какие точки на графике могут существовать
    //Если координатная сетка задана на всей вещественной плоскости, то следующий вариант решения
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<double, double>> points = new List<Tuple<double, double>>();
            points.Add(new Tuple<double, double>(0, 0));
            points.Add(new Tuple<double, double>(0.1, 0.9));
            points.Add(new Tuple<double, double>(0.9, 0.1));
            points.Add(new Tuple<double, double>(0, 9));
            points.Add(new Tuple<double, double>(9, 0));
            points.Add(new Tuple<double, double>(0.1, 2));
            points.Add(new Tuple<double, double>(2, 0.1));
            points.Add(new Tuple<double, double>(1, 1));
            points.Add(new Tuple<double, double>(2, 2));
            points.Add(new Tuple<double, double>(9, 9));
            points.Add(new Tuple<double, double>(8, 8));
            points.Add(new Tuple<double, double>(-2, -2));
            points.Add(new Tuple<double, double>(7.9, 7.9));
            points.Add(new Tuple<double, double>(8.9, 8.9));
            double coordinate;
            foreach (var item in points)
            {

                coordinate = Math.Max(item.Item1, item.Item2);

                if ((item.Item1 + item.Item2 > coordinate * (coordinate + 1)) || ((item.Item1 * item.Item2) < 1) 
                    || (item.Item1 < item.Item2 - 1) || (coordinate > 8) || (coordinate<0))
                    
                {
                    Console.WriteLine("Точка ({0}; {1}) не попадает в область", item.Item1, item.Item2);
                    continue;

                }

                Console.WriteLine("Точка ({0}; {1}) попадает в область", item.Item1, item.Item2);

            }
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Drawing;
//namespace EPAM_Test_3
//{
//    //Если координатная сетка задана от 1 до 8 по OY и OY, то
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Tuple<double, double>> points = new List<Tuple<double, double>>();


//            points.Add(new Tuple<double, double>(1, 1));
//            points.Add(new Tuple<double, double>(2, 2));
//            points.Add(new Tuple<double, double>(8, 8));
//            points.Add(new Tuple<double, double>(1, 2));
//            points.Add(new Tuple<double, double>(2, 1));
//            points.Add(new Tuple<double, double>(3, 1));
//            points.Add(new Tuple<double, double>(1, 3));
//            points.Add(new Tuple<double, double>(7.9, 7.9));
//            points.Add(new Tuple<double, double>(1, 2.1));
//            points.Add(new Tuple<double, double>(2.1, 1));
//            points.Add(new Tuple<double, double>(3, 6));
//            points.Add(new Tuple<double, double>(1.9, 2.9));

//            foreach (var item in points)
//            {    
//               
//                if (Math.Floor(item.Item1 + 1) >= item.Item2)

//                {
//                    Console.WriteLine("Точка ({0}; {1})  попадает в область", item.Item1, item.Item2);
//                    continue;
//                }

//                Console.WriteLine("Точка ({0}; {1}) не  попадает в область", item.Item1, item.Item2);

//            }
//        }
//    }
//}
