using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSchool
{
    public class Student
    {
        public string Name { get; set; }

        public int StudentID { get; set; }

        public Student(string name,int uniqueNumber)
        {         
            if(name.Equals(String.Empty))
            {
                throw new ArgumentException("You should enter a correct name.");
            }

            this.Name = name;

            if (uniqueNumber < 10000 || uniqueNumber > 99999)
            {
                throw new ArgumentException("Enter a valid unique number that is between 10000 and 99999.");
            }

            this.StudentID = uniqueNumber;
        }
    }



    public class Course
    {
        public string Name { get; set; }
        public List<Student> StudentClass { get; set; }

        public Course(string name,List<Student> studList)
        {
            this.Name = name;
            this.StudentClass = studList;
        }

        public void AddStudent(Student student)
        {
            if (StudentClass.Count < 30)
            {
                this.StudentClass.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            if(this.StudentClass.Contains(student))
            {
                this.StudentClass.Remove(student);
            }
            else
            {
                throw new ArgumentException("{0} is not in this class.", student.Name);
            }
        }
    }



    public class School
    {
        public string Name { get; set; }
        public List<Course> CourseList { get; set; }

        public School(string name, List<Course> courseList)
        {
            this.Name = name;
            this.CourseList = courseList;
        }

        public void AddCourse(Course newCourse)
        {
            this.CourseList.Add(newCourse);
        }

        public void RemoveCourse(Course removeCourse)
        {
            if(this.CourseList.Contains(removeCourse))
            {
                this.CourseList.Remove(removeCourse);
            }
        }
    }


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
            Course course = new Course("Computer scince", new List<Student>() { new Student("Pesho", 12332),new Student("Kolio",81234)});

            int n = int.Parse(Console.ReadLine());
            course.AddStudent(selim);
            int m = int.Parse(Console.ReadLine());
            course.RemoveStudent(selim);
        }
    }
}
