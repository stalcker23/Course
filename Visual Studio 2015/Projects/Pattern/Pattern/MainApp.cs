using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern
{
    class MainApp
    {
        static void Main()
        {
            Console.WriteLine("Введите число в виде римских цифр(цифры в верхнем регистре)");
            string roman = Console.ReadLine();
            Context context = new Context(roman);

            // Строим дерево распарсивания
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            // Интерпретатор
            foreach (Expression exp in tree)
            {
                exp.Interpretator(context);
            }

            Console.WriteLine("{0} = {1}",
              roman, context.Output);

            
            Console.ReadKey();
        }
    }
}
