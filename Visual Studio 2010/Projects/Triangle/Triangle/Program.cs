using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_10
{
    class Line 
    {
        double a;
        double b;
        double c;

      
        Line(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        Line(Line T)
        {
            this.a = T.a;
            this.b = T.b;
            this.c = T.c;
        }
         public void Show()
        {
            Console.WriteLine("a={0} b={1} c={2}", a, b, c);
        }
         public double Perimetr() //расстояние от начала координат
         {
             double perimetr = a+b+c;
             return perimetr;
         }
         public double Square()
         {
             double half = (a + b + c) / 2;
             double square = Math.Sqrt(half * (half - a) * (half - b) * (half - c));
             return square;
         }

         public double A ///Свойство: получить/установить значение "х" точки
         {
             get
             {
                 return a;
             }
             set
             {
                 a = value;
             }
         }
         public double B /// Свойство: получить/установить значение "у" точки
         {
             get
             {
                 return b;
             }
             set
             {
                 b = value;
             }
         }
         public double C /// Свойство: получить/установить значение "у" точки
         {
             get
             {
                 return c;
             }
             set
             {
                 c = value;
             }
         }


         public string Existance
         {
             get
             {
                 string str1="Допустимые длины";
                 string str2 = "Допустимые длины";
                 if ((a < b + c) && (b < a + c) && (c < a + b))
                     return str1;
                 else
                     return str2;
             }
         }
         public double this[int i]
         {
             get
             {
                 if (i == 0)
                 {
                     return a;
                 }
                 else
                 {
                     if (i == 1)
                     {
                         return b;
                     }

                     else
                     {
                         if (i == 2)
                         {
                             return c;
                         }
                         else
                         {
                             Console.WriteLine("Недопустимые стороны");
                             return 0;
                         }
                     }
                 }
             }
         }
         public static Line operator ++(Line pnt)
         {

            Line tmp = new Line(pnt);
             tmp.a += 1;
             tmp.b += 1;
             tmp.c += 1;
             return tmp;
         }
         public static Line operator --(Line pnt)
         {

             Line tmp = new Line(pnt);
             tmp.a -= 1;
             tmp.b -= 1;
             tmp.c -= 1;
             return tmp;
         }
         public static Line operator *(Line t, double scal)
         {
             
             Line tmp = new Line(t);
             tmp.a *=  scal ;
             tmp.b *= scal  ;
             tmp.c *=  scal ;
             return tmp;
         }
         public static bool operator true(Line t)
         {
             if  ((t.a < t.b+t.c) && (t.b < t.a+t.c) && (t.c < t.a+t.b))
             {
                 return true;
             }
             else
             {
                 return false;
             }
         }
         public static bool operator false(Line t)
         {
             if ((t.a >= t.b + t.c) || (t.b >= t.a + t.c) || (t.c >= t.a + t.b))
             {
                 return false;
             }
             else
             {
                 return true;
             }
         }
        
        static void Main()
        {
           
            Console.WriteLine("Ввод координат");
            string[] line = Console.ReadLine().Split(' ');
            double one = int.Parse(line[0]);
            double two = int.Parse(line[1]);
            double three = int.Parse(line[2]);
            Console.WriteLine("Конструктор с заданными координатами");
            Line ln = new Line(one, two, three);
            ln.Show();

            Console.WriteLine("установление координат через свойства");
            ln.A = 1;
            ln.B = 2;
            ln.C = 2;
            ln.Show();
            Console.WriteLine("Существование", ln.Existance);
            Console.WriteLine("Инкремент");
            ln++;
            ln.Show();
            Console.WriteLine("Дикремент");
            ln--; 
            ln.Show();
            Console.WriteLine("индексатор, переменная a");
            Console.WriteLine(ln[0]);
           
            Console.WriteLine("Периметр {0}",ln.Perimetr());
            Console.WriteLine("Площадь {0}", ln.Square());
            Console.WriteLine("умножение на скаляр"); 
            int x = int.Parse(Console.ReadLine());
            ln=ln*x; 
            ln.Show();

            Console.WriteLine("Новые координаты точки");
            ln.A = 5;
            ln.B = 5;
            ln.C = 5;
            ln.Show();
            Console.WriteLine("Проверка на существование");
            if (ln)
            {
                Console.WriteLine("Существование");
            }
            else
            {
                Console.WriteLine("Не существует");
            }

          
        }

        
    }
}
