using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class BaseCourse
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        public BaseCourse(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public BaseCourse(string name,string teacher)
        {
            this.Name = name;
            this.TeacherName = teacher;
            this.Students = new List<string>();
        }

        public BaseCourse(string name,string teacher,IList<string> student)
        {
            this.Name = name;
            this.TeacherName = teacher;
            this.Students = student;
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
