using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Pract16.II
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph g = new Graph("C:/h.txt");
            Console.WriteLine("Graph: ");
            g.Show();
        }
    }
}
