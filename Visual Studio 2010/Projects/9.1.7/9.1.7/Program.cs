using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _9._1._7
{
    class Program
    {
        static void Main()
        {
            char a = char.Parse(Console.ReadLine());
            foreach (string s in File.ReadAllLines("text.txt"))
            {
                if (s[0]==a)
                    Console.WriteLine(s);
            }
        }
    }
}
