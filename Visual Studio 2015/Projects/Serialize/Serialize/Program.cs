using System;
using System.IO;
namespace Figure
{

    class Program
    {
        static void Main()
        {
            Figure[] figures = GetFigures();
            Array.Sort(figures);
            foreach (Figure figure in figures)
            {
                Console.WriteLine();
                figure.ShowInfo();
                Console.WriteLine("S: {0}", figure.Area());
                Console.WriteLine("P: {0}", figure.Perimeter());
            }
            Console.ReadKey();
        }

        public static Figure[] GetFigures()
        {
            string[] s = ReadFile().Split('\n');
            Figure[] figures = new Figure[s.Length];

            int a, b, c, r, i = 0, n = 0;

            while (i < s.Length)
            {
                string[] str = s[i].Split(' ');

                if (str[0] == "rectangle")
                {
                    a = Convert.ToInt32(str[1]);
                    b = Convert.ToInt32(str[2]);
                    figures[n] = new Rectangle(a, b);
                    n++;

                }
                if (str[0] == "circle")
                {
                    r = Convert.ToInt32(str[1]);
                    figures[n] = new Circle(r);
                    n++;

                }
                if (str[0] == "triangle")
                {
                    a = Convert.ToInt32(str[1]);
                    b = Convert.ToInt32(str[2]);
                    c = Convert.ToInt32(str[3]);
                    figures[n] = new Triangle(a, b, c);
                    n++;

                }
                i++;
            }
            return figures;
        }

        public static string ReadFile()
        {
            string str = string.Empty;
            StreamReader fig = new StreamReader(@"F:\Visual Studio 2013\serialize.txt");
            str = fig.ReadToEnd();
            fig.Close();
            return str;
        }



    }
}
