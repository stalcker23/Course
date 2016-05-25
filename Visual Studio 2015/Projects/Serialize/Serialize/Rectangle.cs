using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figure
{

    class Rectangle : Figure
    {
        int a, b;

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public override double Area()
        {
            return a * b;
        }

        public override double Perimeter()
        {
            return (a + b) * 2;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Прямоугольник со сторонами {0} и {1}", a, b);
        }
    }



}
