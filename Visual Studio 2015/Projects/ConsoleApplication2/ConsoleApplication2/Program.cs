using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataAccess.DataAccessFactory factory = new DataAccess.DataAccessFactory();
            DataAccess.Interfaces.IDataAccess i;
            try
            {
               i = factory.GetSqlDataAccess();
               Entities.SqlRequest rec = new Entities.SqlRequest();   
               i.RetrieveDataObject(rec);
            }
            catch 
            {
               i = factory.GetTextFileDataAccess();
                Entities.TextFileRequest rec = new Entities.TextFileRequest();
                rec.PathToFile = "text.txt";
                i.RetrieveDataObject(rec);
            }
            string str = String.Join("",i);
            Console.WriteLine(str); 
        }
    }
}
