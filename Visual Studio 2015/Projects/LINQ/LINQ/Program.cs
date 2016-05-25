using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            public Student()
            {
            }
            public Student(string First, string Last, int ID, List<int> Scores)
            {
                this.ID = ID;
                this.First = First;
                this.Last = Last;
                this.Scores = Scores;
            }
            public Student(string Name)
            {
                string[] allLines = File.ReadAllLines(Name, Encoding.GetEncoding(1251));

                var query =
                    from students in allLines
                    select students.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) into x
                    select new Student(x[0], x[1], int.Parse(x[2]), x.Skip(3).Select(int.Parse).ToList());
            }

            static List<Student> students = new List<Student>
{
   new Student {First="Svetlana", Last="Omelchenko", ID=130, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Svetlana", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
   new Student {First="Svetlana", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
   new Student {First="Svetlana", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
   new Student {First="Svetlana", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
   new Student {First="Svetlana", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
   new Student {First="Svetlana", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
   new Student {First="Svetlana", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
   new Student {First="Svetlana", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
   new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
   new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
   new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
};


            public void Student1()
            {

                IEnumerable<Student> studentQuery =
                    from student in students
                    where student.Scores[0] > 70
                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.Where(student => student.Scores[0] > 70);
                foreach (var i in result)
                {
                    Console.WriteLine("{1}, {0}", i.Last, i.First);
                }
                Console.WriteLine("\n" + "\n");
            }
            public void Student2()
            {

                IEnumerable<Student> studentQuery =
                    from student in students
                    where student.Scores[0] > 70 && student.Scores[0] < 80

                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.Where(student => (student.Scores[0] > 70 && student.Scores[0] < 80));
                foreach (var i in result)
                {
                    Console.WriteLine("{1}, {0}", i.Last, i.First);
                }
                Console.WriteLine("\n" + "\n");
            }
            public void Student3()
            {

                IEnumerable<Student> studentQuery =
                    from student in students
                    where (student.Scores.Min() > 80)
                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.Where(student => (student.Scores.Min() > 80));
                foreach (var i in result)
                {
                    Console.WriteLine("{1}, {0}", i.Last, i.First);
                }
                Console.WriteLine("\n" + "\n");
            }
            public void Student4a()
            {

                IEnumerable<Student> studentQuery =
                    from student in students

                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.OrderBy(student => student.ID);
                foreach (var i in result)
                {
                    Console.WriteLine("{1}, {0}", i.Last, i.First);
                }
                Console.WriteLine("\n" + "\n");
            }
            public void Student4b()
            {

                IEnumerable<Student> studentQuery =
                    from student in students
                    orderby student.First descending, student.Last descending
                    select student;
                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{1}, {0}", student.Last, student.First);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.OrderByDescending(student => (student.First)).ThenByDescending(student => (student.Last));
                foreach (var i in result)
                {
                    Console.WriteLine("{1}, {0}", i.Last, i.First);
                }
                Console.WriteLine("\n" + "\n");
            }
            public void Student5()
            {

                var studentQuery2 =
                from student in students
                group student by student.Scores[student.Scores.Count - 1];
                foreach (var studentGroup in studentQuery2)
                {
                    Console.WriteLine(studentGroup.Key);
                    foreach (Student student in studentGroup)
                    {
                        Console.WriteLine("   {0}, {1}",
                                  student.Last, student.First);
                    }
                }
                Console.WriteLine("\n" + "\n");

                var result = students.GroupBy(student => student.Scores[student.Scores.Count - 1]);
                foreach (var studentGroup in result)
                {
                    Console.WriteLine(studentGroup.Key);
                    foreach (Student student in studentGroup)
                    {
                        Console.WriteLine("   {0}, {1}",
                                  student.Last, student.First);
                    }
                }
                Console.WriteLine("\n" + "\n");

            }
            public void Student6()
            {
                var studentQuery3 =
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
                Console.WriteLine("\n" + "\n");
                var result = students.OrderBy(student => student.Scores[student.Scores.Count - 1]).GroupBy(student => student.Scores[student.Scores.Count - 1]);
                foreach (var groupOfStudents in result)
                {
                    Console.WriteLine(groupOfStudents.Key);
                    foreach (var student in groupOfStudents)
                    {
                        Console.WriteLine("   {0}, {1}",
                            student.Last, student.First);
                    }

                }
                Console.WriteLine("\n" + "\n");

            }
            public void Student7()
            {
                IEnumerable<string> studentQuery7 =
                from student in students
                orderby student.First
                select student.First;

                studentQuery7 = studentQuery7.Distinct();
                foreach (string s in studentQuery7)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("\n" + "\n");
                var result = students.OrderBy(student => student.First).Select(student => student.First)/*.Distinct()*/;
                foreach (var s in result)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("\n" + "\n");
            }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", First, Last, ID, String.Join(" ", Scores));
            }
            static void Main(string[] args)
            {

                string[] allLines = File.ReadAllLines(@"input.txt", Encoding.GetEncoding(1251));

                Student student1 = new Student(@"input.txt");

                Student student = new Student();

                //student1.Student1();
                //student.Student1();
                //
                //student1.Student2();
                //student.Student2();
                //
                //student1.Student3();
               //student.Student3();
               
               //student1.Student4a();
                //student.Student4a();
               
                //student1.Student4b();
                //student.Student4b();
                //
                //student1.Student5();
                //student.Student5();
            
                //student.Student6();
                //student1.Student6();
               
                student.Student7();
                student1.Student7();
            }

        }

    }
}