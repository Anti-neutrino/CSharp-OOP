# Behavioral patterns

### Iterator pattern

##### Мотивация
Този шаблон се използва за обхождане и достъпване на елементи от дадена колекция. 

##### Употреба
foreach цикъла в .NET : foreach(var item in collection)

##### Пример
    public interface IIterator
    {
        void Next();

        bool IsDone();

        object CurrentItem();
    }
    
    public abstract class Aggregate
    {
        public abstract IIterator CreateIterator();
    }
    
    public class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList items = new ArrayList();

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public object this[int index]
        {
            get
            {
                return this.items[index];
            }

            set
            {
                this.items.Insert(index, value);
            }
        }

        public override IIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }
    
    public class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate aggregate;

        private int current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public void Next()
        {
            this.current++;
        }

        public object CurrentItem()
        {
            return this.aggregate[this.current];
        }

        public bool IsDone()
        {
            return this.current >= this.aggregate.Count;
        }
    }
    
     public static class Test
    {
        public static void Main()
        {
            ClearImplementationDemo();
            Console.WriteLine(new string('-', 60));
            ImplementationInDotNet();
            Console.WriteLine(new string('-', 60));
            YieldExample();
        }

        private static void ClearImplementationDemo()
        {
            var aggregate = new ConcreteAggregate();
            aggregate[0] = "Item A";
            aggregate[1] = "Item B";
            aggregate[2] = "Item C";
            aggregate[3] = "Item D";

            // Create Iterator and provide aggregate
            IIterator iterator = new ConcreteIterator(aggregate);

            Console.WriteLine("Iterating over collection:");

            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.CurrentItem());
                iterator.Next();
            }
        }

        private static void ImplementationInDotNet()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void YieldExample()
        {
            var evenNumbers = EvenNumbersInRange(1, 10);
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine(evenNumber);
            }
        }

        private static IEnumerable<int> EvenNumbersInRange(int lowerBound, int upperBound)
        {
            if (lowerBound % 2 != 0)
            {
                lowerBound++;
            }

            for (int i = lowerBound; i <= upperBound; i += 2)
            {
                yield return i;
            }
        }
    }
##### UML Diagram
![Picture](http://blog.lukaszewski.it/wp-content/uploads/2013/10/iterator_diagram.png)