using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Student
{
    class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;


            static List<Student> students = new List<Student>
{
   new Student {First="Svetlana", Last="Omelchenko", ID=130, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
   new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
   new Student {First="Fadi", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
   new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
   new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
   new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
   new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
   new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
};







            static void Main(string[] args)
            {

                // Create the query.
                // The first line could also be written as "var studentQuery ="
                /*IEnumerable<Student> studentQuery =
                    from student in students
                    //where student.Scores[0] > 70 
                    //where student.Scores[0] > 70 && student.Scores[0]<80
                    //where (student.Scores.Min()>80)
                    //orderby student.ID
                    //orderby student.First descending, student.Last descending
                    //select student;
                                   foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }*/
                /*var studentQuery2 =
                from student in students
                group student by student.Scores[student.Scores.Count-1];
                foreach (var studentGroup in studentQuery2)
                {
                    Console.WriteLine(studentGroup.Key);
                    foreach (Student student in studentGroup)
                    {
                        Console.WriteLine("   {0}, {1}",
                                  student.Last, student.First);
                    }
                }*/
                /*var studentQuery3 =
    from student in students
    group student by student.Scores[student.Scores.Count - 1] into studentGroup
    orderby studentGroup.Key
    select studentGroup;

                foreach (var groupOfStudents in studentQuery3)
                {
                    Console.WriteLine(groupOfStudents.Key);
                    foreach (var student in groupOfStudents)
                    {
                        Console.WriteLine("   {0}, {1}",
                            student.Last, student.First);
                    }
                }
                */
                /*IEnumerable<string> studentQuery7 =
    from student in students
    orderby student.First
    select student.First;

                //studentQuery7 = studentQuery7.Distinct();
                foreach (string s in studentQuery7)
                {
                    Console.WriteLine(s);
                }

                */
            }

        }

    }
}