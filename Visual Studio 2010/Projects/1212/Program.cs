using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{


    class Program
    {
        static void Main()
        {
            Figure[] array_fig = GetArrayFigures();

            foreach (Figure fig in array_fig)
            {
                Console.WriteLine();
                fig.ShowInfo();
                Console.WriteLine("S: {0}", fig.Area());
                Console.WriteLine("P: {0}", fig.Perimeter());
            }
            Console.ReadKey();
        }

        public static Program[] GetArrayFigures()
        {
            string[] s = ReadFile().Split('\n');
            Figure[] array_fig = new Figure[s.Length];

            int a, b, c, r, i = 0, n = 0;

            while (i < s.Length)
            {
                string[] str = s[i].Split(' ');

                if (str[0] == "rectangle")
                {
                    a = Convert.ToInt32(str[1]);
                    b = Convert.ToInt32(str[2]);
                    array_fig[n] = new Rectangle(a, b);
                    n++;
                }
                if (str[0] == "circle")
                {
                    r = Convert.ToInt32(str[1]);
                    array_fig[i] = new Circle(r);
                    n++;
                }
                if (str[0] == "triangle")
                {
                    a = Convert.ToInt32(str[1]);
                    b = Convert.ToInt32(str[2]);
                    c = Convert.ToInt32(str[3]);
                    array_fig[i] = new Triangle(a, b, c);
                    n++;
                }
                i++;
            }
            return array_fig;
        }

        public static string ReadFile()
        {
            string str = string.Empty;

            try
            {
                StreamReader fin = new StreamReader("C:/file.txt");
                str = fin.ReadToEnd();
                fin.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден, поместите файл в необходимую директорию.");
                ReadFile();
            }

            return str;
        }
    }
}