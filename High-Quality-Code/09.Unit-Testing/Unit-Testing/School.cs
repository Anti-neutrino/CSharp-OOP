using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSchool
{
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
}
