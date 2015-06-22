using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        private int? age;
        public string Name { get; private set; }
        public int? Age
        {
            get { return age; }
            private set
            {
                if (Age <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative!");
                }
            }
        }
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            build.Append("Name: " + this.Name + "\n");
            if (this.Age == null)
            {
                build.Append("Age: null");
            }
            else
            {
                build.Append("Age: " + this.Age + "\n");
            }
            return build.ToString();
        }
    }
}
