using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student : ICloneable, IComparable<Student>
    {
        public string firstName { get; private set; }
        public string secondName { get; private set; }
        public string lastName { get; private set; }
        public string SSN { get; private set; }
        public string permanentAddress { get; private set; }
        public string Mobile { get; private set; }
        public string Course { get; private set; }
        public Speciality Spec { get; private set; }
        public University Uni { get; private set; }
        public Faculty Fac { get; private set; }
        public Student()
        {
        }
        public Student(string first, string second, string last, string s, string add, string mob, string course, Speciality spec, University uni, Faculty fac)
        {
            this.firstName = first;
            this.secondName = second;
            this.lastName = lastName;
            this.SSN = s;
            this.permanentAddress = add;
            this.Mobile = mob;
            this.Course = course;
            this.Spec = spec;
            this.Uni = uni;
            this.Fac = fac;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }
            Student stud = obj as Student;

            if (!Object.Equals(this.firstName, stud.firstName))
            {
                return false;
            }
            if (!Object.Equals(this.secondName, stud.secondName))
            {
                return false;
            }
            if (!Object.Equals(this.lastName, stud.lastName))
            {
                return false;
            }
            if (!Object.Equals(this.SSN, stud.SSN))
            {
                return false;
            }
            if (!Object.Equals(this.permanentAddress, stud.permanentAddress))
            {
                return false;
            }
            if (!Object.Equals(this.Course, stud.Course))
            {
                return false;
            }
            if (!Object.Equals(this.Mobile, stud.Mobile))
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            build.Append("Name: " + firstName + " " + secondName + " " + lastName + "\n");
            build.Append("SSN: " + SSN + "\n");
            build.Append("Address: " + permanentAddress + "\n");
            build.Append("Mobile" + Mobile.ToString() + "\n");
            build.Append("Course: " + Course + "\n");
            build.Append("Specialy: " + Spec + "\n");
            build.Append("University: " + Uni + "\n");
            build.Append("Faculty: " + Fac + "\n");
            return build.ToString();
        }
        public override int GetHashCode()
        {
            Random generator = new Random();
            return generator.Next(101);
        }
        public static bool operator ==(Student s1, Student s2)
        {
            return Student.Equals(s1, s2);
        }
        public static bool operator !=(Student s1, Student s2)
        {
            return !Student.Equals(s1, s2);
        }

        public Student Clone()
        {
            return new Student(this.firstName, this.secondName, this.lastName, this.SSN, this.permanentAddress, this.Mobile, this.Course, this.Spec, this.Uni, this.Fac);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }


        public int CompareTo(Student other)
        {
            if (this.firstName.CompareTo(other.firstName) != 0)
            {
                return this.firstName.CompareTo(other.firstName);
            }
            else
            {
                if (this.secondName.CompareTo(other.secondName) != 0)
                {
                    return this.secondName.CompareTo(other.secondName);
                }
                else
                {
                    if (this.lastName.CompareTo(other.lastName) != 0)
                    {
                        return this.lastName.CompareTo(other.lastName);
                    }
                    else
                    {
                        if (this.SSN.CompareTo(other.SSN) != 0)
                        {
                            return this.SSN.CompareTo(other.SSN);
                        }
                    }
                }
            }
            return 0;
        }
    }
}
