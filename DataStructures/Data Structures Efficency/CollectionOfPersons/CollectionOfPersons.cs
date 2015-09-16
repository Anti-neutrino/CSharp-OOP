using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CollectionOfPersons
{
    public class PersonCollection
    {
        private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

        public Person FindPerson(string email)
        {
            Person person;
            var newPerson = personsByEmail.TryGetValue(email, out person);
            return person;
        }

        public bool AddPerson(string email,string name,int age,string town)
        {
            if(personsByEmail.ContainsKey(email))
            {
                return false;
            }

            Person person = new Person() { Email = email, Name = name, Age = age, Town = town };

            //Add by email
            this.personsByEmail.Add(email, person);

            //Add by email domain
            string emailDomain = this.ExtractEmailDomain(email);
            if(!personsByEmailDomain.ContainsKey(emailDomain))
            {
                personsByEmailDomain.Add(emailDomain, new SortedSet<Person>());
            }

            personsByEmailDomain[emailDomain].Add(person);

            //Add by name and town
            string nameAndTown = this.CombineNameAndTown(name, town);
            if(!personsByNameAndTown.ContainsKey(nameAndTown))
            {
                personsByNameAndTown.Add(nameAndTown, new SortedSet<Person>());
            }

            personsByNameAndTown[nameAndTown].Add(person);

            //Add by age
            if(!personsByAge.ContainsKey(age))
            {
                personsByAge.Add(age, new SortedSet<Person>());
            }

            personsByAge[age].Add(person);

            //Add by town and age
            OrderedDictionary<int, SortedSet<Person>> personsByTown;

            if(!personsByTownAndAge.TryGetValue(town,out personsByTown))
            {
                personsByTown = new OrderedDictionary<int, SortedSet<Person>>();
                personsByTownAndAge.Add(town, personsByTown);
            }

            if(!personsByTown.ContainsKey(age))
            {
                personsByTown.Add(age, new SortedSet<Person>());
            }
            personsByTown[age].Add(person);

            return true;
        }

        public bool DeletedPerson(string email)
        {
            var person = this.FindPerson(email);
            if (person == null)
            {
                return false;
            }

            //Delete by email
            this.personsByEmail.Remove(email);

            //Delete by email domain
            string emailDomain = this.ExtractEmailDomain(email);
            this.personsByEmailDomain.Remove(emailDomain);

            //Delete by name and town
            string nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
            this.personsByNameAndTown.Remove(nameAndTown);

            //Delete by age
            this.personsByAge.Remove(person.Age);

            //delete person by age and town
            this.personsByTownAndAge[person.Town][person.Age].Remove(person);

            return true;
        }

        private string ExtractEmailDomain(string email)
        {
            string emailDomain = email.Split('@')[1];
            return emailDomain;
        }

        private string CombineNameAndTown(string name,string town)
        {
            const string separator = "|!|";
            return name + separator + town;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            SortedSet<Person> collection;
            if(this.personsByEmailDomain.TryGetValue(emailDomain,out collection))
            {
                return collection;
            }

            return Enumerable.Empty<Person>();   
        }

        public IEnumerable<Person> FindPersons(string name,string town)
        {
            string nameAndTown = this.CombineNameAndTown(name, town);
            SortedSet<Person> collection;
            if(personsByNameAndTown.TryGetValue(nameAndTown,out collection))
            {
                return collection;
            }

            return Enumerable.Empty<Person>();
        }

        public IEnumerable<Person> FindPersons(int startAge,int endAge)
        {
            var personInRange = this.personsByAge.Range(startAge, true, endAge, true);
            foreach(var elements in personInRange)
            {
                foreach(var element in elements.Value)
                {
                    yield return element;
                }
            }
        }

        public IEnumerable<Person> FindPersons(int startAge,int endAge,string town)
        {
            if(!this.personsByTownAndAge.ContainsKey(town))
            {
                yield break;
            }

            var personInRange = this.personsByTownAndAge[town].Range(startAge, true, endAge, true);
            foreach(var elements in personInRange)
            {
                foreach(var element in elements.Value)
                {
                    yield return element;
                }
            }
        }
    }
}
