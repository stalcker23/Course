using HelloApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace HelloWorld.Models
{
    public class Collection
    {
        public static  AllVertices massive_vertex { get; set; } = new AllVertices();
        static Collection()
        {
            string[] q = System.IO.File.ReadAllLines(ConfigurationManager.AppSettings["filePath"]);
            foreach (string line in q)
            {
                var myArray = line.Split(' ');
                var pair = new  Pair(Convert.ToInt32(myArray[1]), Convert.ToInt32(myArray[2]));
                Vertex list = new Vertex();

                if (!massive_vertex.allVertices.ContainsKey(Convert.ToInt32(myArray[0])))
                {
                    list.ListOfRealted.Add(pair);
                    massive_vertex.allVertices.Add(Convert.ToInt32(myArray[0]), list);
                }
                else
                {

                    massive_vertex.allVertices.TryGetValue(Convert.ToInt32(myArray[0]), out list);
                    list.ListOfRealted.Add(pair);
                }
            }  

        }
       
        
            
        

    }
}