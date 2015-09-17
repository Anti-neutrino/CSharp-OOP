using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSchool
{
    public class StudentTest
    {
        static void Main()
        {
            School PMG = new School("PMG", new List<Course>() 
                {new Course("Computer Science", new List<Student>()
                {new Student("Hahaa Nana", 81207),
                new Student("Momchil Yordanov",81175),
                new Student("Barabara Zazov",81654)}),
                new Course("Software engeneering",new List<Student>()
                {new Student("Gadimo Beichev",81176),
                new Student("Vektor Vrabchev",86234),
                new Student("Matias Kurior",81112)})});

            Student selim = new Student("Selim Kerkar", 81175);
            Course course = new Course("Computer scince", new List<Student>() { new Student("Pesho", 12332), new Student("Kolio", 81234) });

            int n = int.Parse(Console.ReadLine());
            course.AddStudent(selim);
            int m = int.Parse(Console.ReadLine());
            course.RemoveStudent(selim);
        }
    }
}
