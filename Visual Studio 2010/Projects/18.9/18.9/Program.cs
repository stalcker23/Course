using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace _18._9
{
    class Program
    {

        static void Main()
        {

            string p = @"((^|[\s])((((0[1-9]|[1-2][0-9])\.([0][2]))|((0[1-9]|[1-2][0-9]|[3][0])\.(0[468]|([1][1])))|(0[1-9]|[1-2][0-9]|3[0-1])\.(0[13579]|([1][0]])|([1][2])))\.((19[0-9][0-9])|(2010)|(200[0-9])))($|[\W]))";
            Regex r = new Regex(p, RegexOptions.IgnoreCase);
            string line;
            using (StreamReader inStream = new StreamReader("C:/f.txt", Encoding.GetEncoding(1251)))
            {



                while ((line = inStream.ReadLine()) != null)
                {
                    Match tel = r.Match(line);
                    while (tel.Success)
                    {
                        string s = tel.Value;
                        if ((char.IsWhiteSpace(s[0])) && (!char.IsDigit(s[s.Length - 1])))
                        {
                            s = s.Remove(0, 1);
                            s = s.Remove(s.Length - 1, 1);
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
