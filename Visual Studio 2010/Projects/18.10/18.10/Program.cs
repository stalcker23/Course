using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace _18._10
{
    class Program
    {

        static void Main()
        {

            string p = @"(^|\s)(([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.){3}" + @"([0-9]|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])($|\W)";
            Regex r = new Regex(p, RegexOptions.IgnoreCase);
            string line;
            using (StreamReader inStream = new StreamReader("C:/Users/Artyom/Documents/Visual Studio 2010/Projects/18.10/18.10/bin/Debug/f.txt", Encoding.GetEncoding(1251)))
            {
               
                    while ((line = inStream.ReadLine()) != null)
                    {
                        Match tel = r.Match(line);
                        while (tel.Success)
                        {
                            string s = tel.Value;
                            if ((char.IsWhiteSpace(s[0])) && (!char.IsDigit(s[s.Length - 1])))
                            {
                                 s = s.Remove(0,1);
                                 s = s.Remove(s.Length-1, 1);
                                Console.Write(s);
                                Console.WriteLine();
                            }
                            else if ((!char.IsDigit(s[s.Length - 1])))
                            {
                          
                                s = s.Remove(s.Length - 1, 1);
                                Console.Write(s);
                                Console.WriteLine();
                            }
                            else if (char.IsWhiteSpace(s[0]))
                            {
                                s = s.Remove(0, 1);
                               
                                Console.Write(s);
                                Console.WriteLine();
                            }
                            else
                            {
                               
                                Console.Write(s);
                                Console.WriteLine();
                            }
                            tel = tel.NextMatch();

                        }
                    }

                }
            }
        }
    }
