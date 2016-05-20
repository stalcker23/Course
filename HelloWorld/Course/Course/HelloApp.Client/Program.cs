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
                
                var response = await client.GetAsync("http://localhost:52566/api/Note");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var note = await response.Content.ReadAsAsync<Vertex>();


                    Console.WriteLine($"Note successfully read:");
                    foreach (var item in note.arrayWeighted)
                    {
                        Console.WriteLine(item.Key.ToString(), String.Join(" ",item.Value));
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