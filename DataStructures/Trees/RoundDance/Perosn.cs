using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundDance
{
    public class Person
    {
        public int Name { get; set; }
        public Person HasParent { get; set; }
        public List<Person> Friend { get; set; }

        public Person(int name)
        {
            this.Name = name;
            this.Friend = new List<Person>();
        }
    }
}
