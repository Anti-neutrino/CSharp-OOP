using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionOfPersons
{
    public class PlayWithCollectionOfPersons
    {
        static void Main()
        {
            PersonCollection collection = new PersonCollection();
            collection.AddPerson("aztigabe@abv.bg", "Momo", 19, "Burgas");
            collection.AddPerson("masd@gmail.com", "Kolio", 20, "Sofia");
            collection.AddPerson("demo@yahoo.com", "Dimo", 18, "Kyustendil");
            collection.AddPerson("asdad@abv.bg", "Momo", 123, "Burgas");
            collection.DeletedPerson("aztigabe@abv.bg");

            IEnumerable<Person> list= collection.FindPersons(1,1000,"Burgas");
            foreach(var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
