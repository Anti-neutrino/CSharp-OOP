using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfPersons
{
    public class Person:IComparable
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }


        public int CompareTo(object obj)
        {
            Person person = obj as Person;
            return this.Email.CompareTo(person.Email);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Email: " + this.Email + '\n');
            builder.Append("Name: " + this.Name + '\n');
            builder.Append("Age: " + this.Age + '\n');
            builder.Append("Town: " + this.Town + '\n');

            return builder.ToString();

        }
    }
}
