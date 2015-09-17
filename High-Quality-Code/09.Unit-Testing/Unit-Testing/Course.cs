using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSchool
{
    public class Course
    {
        public string Name { get; set; }
        public List<Student> StudentClass { get; set; }

        public Course(string name, List<Student> studList)
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
            if (this.StudentClass.Contains(student))
            {
                this.StudentClass.Remove(student);
            }
            else
            {
                throw new ArgumentException("{0} is not in this class.", student.Name);
            }
        }
    }
}
