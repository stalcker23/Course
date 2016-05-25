using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parse
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int,List<Tuple<int, int>>> arrayWeighted = new SortedDictionary<int, List<Tuple<int, int>>>();
            foreach (string line in System.IO.File.ReadAllLines(@"rome99.txt"))
            {
                var myArray = line.Split(' ');
                var pair = Tuple.Create(Convert.ToInt32(myArray[1]), Convert.ToInt32(myArray[2]));
                List<Tuple<int, int>> list = new List<Tuple<int, int>>();

                if (!arrayWeighted.ContainsKey(Convert.ToInt32(myArray[0])))
                {
                    list.Add(pair);
                    arrayWeighted.Add(Convert.ToInt32(myArray[0]), list);
                }
                else
                {

                    arrayWeighted.TryGetValue(Convert.ToInt32(myArray[0]), out list);
                    list.Add(pair);
                }
            }
            foreach(var item in arrayWeighted)
            {
                Console.Write(String.Join("",item.Key)+": ");
                foreach(var list in item.Value)
                {
                    Console.Write("{0}({1}) ",list.Item1,list.Item2);
                    
                }
                Console.WriteLine();
            }
            
        }
    }
}
