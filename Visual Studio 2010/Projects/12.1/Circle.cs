using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program
{
    class Circle : Figure
    {
        const double pi = 3.14;

        int r;

        public Circle(int r)
        {
            this.r = r;
        }

        public override double Area()
        {
            return pi * r * r;
        }

        public override double Perimeter()
        {
            return 2 * pi * r;
        }

        public override double Area() { return a * b; }

        public override double Perimeter() { return (a + b) * 2; }

        public override void ShowInfo()
        {
            Console.WriteLine("Круг радиусом {0}.", r);
        }
    }

}
