using HelloApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace HelloWorld.Models
{
    public class Collection
    {
        public static  Vertex vertex { get; set; } = new Vertex();
        static Collection()
        {
            string[] q = System.IO.File.ReadAllLines(ConfigurationManager.AppSettings["filePath"]);
            foreach (string line in q)
            {
                var myArray = line.Split(' ');
                var pair = Tuple.Create(Convert.ToInt32(myArray[1]), Convert.ToInt32(myArray[2]));
                List<Tuple<int, int>> list = new List<Tuple<int, int>>();

                if (!vertex.arrayWeighted.ContainsKey(Convert.ToInt32(myArray[0])))
                {
                    list.Add(pair);
                    vertex.arrayWeighted.Add(Convert.ToInt32(myArray[0]), list);
                }
                else
                {

                    vertex.arrayWeighted.TryGetValue(Convert.ToInt32(myArray[0]), out list);
                    list.Add(pair);
                }
            }  

        }
       
        
            
        

    }
}