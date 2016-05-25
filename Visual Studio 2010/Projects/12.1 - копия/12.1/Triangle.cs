using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figure
{

    class Triangle : Figure
    {
        int a, b, c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.c = c;
            this.b = b;
        }
        public override double Perimeter()
        {
            if (a < b + c && b < a + c && c < b + a)
            {
                return a + b + c;
            }
            else return 0;
        }


        public override double Area()
        {
            double p = Perimeter() / 2;
            if (a < b + c && b < a + c && c < b + a)
            {
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else return 0;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("Треугольник со сторонами {0}, {1}, {2}", a, b, c);
        }
    }
}
