using System;
using System.IO;


namespace Figure
{

    abstract class Figure : IComparable
    {
        public abstract double Area();

        public abstract double Perimeter();

        public abstract void ShowInfo();

        public int CompareTo(object figure)
        {
            Figure b = (Figure)figure;
            if (this.Area() == b.Area())
            {
                return 0;
            }
            else
            {
                if (this.Area() > b.Area())
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}

   