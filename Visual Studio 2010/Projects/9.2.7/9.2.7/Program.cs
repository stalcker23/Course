using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ещещещ
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader fileIn = new StreamReader("f.txt", Encoding.GetEncoding(1251)))
            {
                using (StreamReader fileInn = new StreamReader("g.txt", Encoding.GetEncoding(1251)))
                {
                    using (StreamWriter fileOut = new StreamWriter("h.txt", false))
                    {
                       var sw = System.Diagnostics.Stopwatch.StartNew();


                        string line1;
                        int n1 = 0;
                        while ((line1 = fileIn.ReadLine()) != null)
                        {
                            char[] mas1 = { ' ', '\n' };
                            string[] lines1 = line1.Split(mas1, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < lines1.Length; i++)
                            {
                                string p2 = lines1[i];
                                n1 = int.Parse(p2);
                                if (n1 > 0)
                                    fileOut.WriteLine(n1);
                            }
                        }
                        string line2;
                        int n2 = 0;
                        while ((line2 = fileInn.ReadLine()) != null)
                        {
                            char[] mas2 = { ' ', '\n' };
                            string[] lines2 = line2.Split(mas2, StringSplitOptions.RemoveEmptyEntries);

                            for (int i = 0; i < lines2.Length; i++)
                            {
                                string p2 = lines2[i];
                                n2 = int.Parse(p2);
                                if (n2 < 0)
                                    fileOut.WriteLine(n2);
                            }
                        
                            
                           
                        }
                        sw.Stop();

                        Console.WriteLine("затрачено времени:{0}", sw.Elapsed);

                    }
                }
            }
        }
    }
}

 