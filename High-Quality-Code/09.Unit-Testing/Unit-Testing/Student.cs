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

        public Student(string name, int uniqueNumber)
        {
            if (name.Equals(String.Empty))
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
}
