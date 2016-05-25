using HelloApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press");
            Console.ReadLine();
            DoJob().Wait();
            Console.ReadLine();
        }
        static async Task DoJob()
        {

            using (var client = new HttpClient())
            {
                
                var response = await client.GetAsync("http://localhost:52566/api/Notes");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var note = await response.Content.ReadAsAsync<AllVertices>();
                    

                    Console.WriteLine($"Note successfully read:");
                    foreach (var item in note.allVertices)
                    {
                        Console.Write(item.Key.ToString()+":");
                        foreach (var item1 in item.Value.ListOfRealted)
                        {
                            Console.Write(" "+item1.To+"("+ item1.Weight+") ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine($"Error:{response.StatusCode}.{response.ReasonPhrase}");
                }

            }
        }
    }
}