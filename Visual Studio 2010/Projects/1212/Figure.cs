using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program
{
    //Создать абстрактный класс Figure с методами вычисления площади и периметра, а также методом, выводящим информацию о фигуре на экран.
    abstract class Figure
    {
        public abstract double Area();

        public abstract double Perimeter();

        public abstract void ShowInfo();
    }
}
