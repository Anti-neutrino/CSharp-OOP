# Behavioral patterns

### Memento

##### Мотивация
* Шаблона за дизайн Memento ни дава възможността да възвръшаме предишното състояние на обекта.
* Имплеметира се като се създадат 3 обекта:оригиналния обект,обекта който прави промяната и мементо обект.
* Оригиналния обект пази текущото състояние.
* Edit обекта прави промени по оригиналния обект,като има възможност да върне оригиналното му състояние,като първо проверява за мементо обект.Изпълнява своята функционалност и за да върне състоянието преди извършените операции връща мементо обекта.
* Мементо обекта съдържа само данни за предишното състояние на оригиналния обект.

##### Употреба
* Състоянията на крайните автомати.

##### Пример
    public class Memento
    {
        public Memento(string name, string phone, double budget)
        {
            this.Name = name;
            this.Phone = phone;
            this.Budget = budget;
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public double Budget { get; set; }
    }
    
    public class SalesProspect
    {
        private string name;
        private string phone;
        private double budget;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                Console.WriteLine("Name:   " + this.name);
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
                Console.WriteLine("Phone:  " + this.phone);
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }

            set
            {
                this.budget = value;
                Console.WriteLine("Budget: " + this.budget);
            }
        }

        public Memento SaveMemento()
        {
            return new Memento(this.name, this.phone, this.budget);
        }

        public void RestoreMemento(Memento memento)
        {
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }
    
     public class ProspectMemory
    {
        // May save more than one memento
        // (e.g. Stack for undo/redo functionality)
        public Memento Memento { get; set; }
    }
    
    public static class Test
    {
        public static void Main()
        {
            var sale = new SalesProspect { Name = "Noel van Halen", Phone = "(412) 256-0990", Budget = 25000.0 };

            var memory = new ProspectMemory();
            Console.WriteLine("\nSaving state --\n");
            memory.Memento = sale.SaveMemento();

            sale.Name = "Leo Welch";
            sale.Phone = "(310) 209-7111";
            sale.Budget = 1000000.0;

            Console.WriteLine("\nRestoring state --\n");
            sale.RestoreMemento(memory.Memento);
        }
    }
    
##### UML Diagram
 ![Pictures](http://www.dofactory.com/images/diagrams/net/memento.gif)