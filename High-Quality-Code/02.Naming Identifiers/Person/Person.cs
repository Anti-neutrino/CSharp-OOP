using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class PersonID
    {
        enum Sex { Male, Female };
        class Person
        {
            public Sex Sex { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void CreatePerson(int years)
        {
            Person newPerson = new Person();
            newPerson.Age = years;

            if (years % 2 == 0)
            {
                newPerson.Name = "John";
                newPerson.Sex = Sex.Male ;
            }
            else
            {
                newPerson.Name = "Sara";
                newPerson.Sex = Sex.Female;
            }
        }
    }
}
