# Шаблони за структуриране на обекти ( Structural Patterns)

## Flyweight

### Мотивация
* Шаблона Flyweight създава обект,който намалява използваната памет,като споделя своята информация с останалите подобни обекти.
* Flyweight обекта се използва,когато имаме често повтарящи се обекти.Създаването на голям брой еднакви обекти води до използването на голямо количество памет,което е скъпа операция.Затова използваме Flyweight обект.
* Общите неща за група от обекти се изкарват в един Flyweight обект,на който във функциите просто подаваме различните параметри на различните обекти.

### Употреба
* В текстов файл представянето на буквите използват точно такива обекти.
* String.Intern 

### Пример

    public abstract class Character
    {
        protected char Symbol { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }
        protected int Ascent { get; set; }
        protected int Descent { get; set; }
        public abstract void Display(int pointSize);
    }
    
    public class CharacterA : Character
    {
        public CharacterA()
        {
            this.Symbol = 'A';
            this.Height = 100;
            this.Width = 120;
            this.Ascent = 70;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            Console.WriteLine("{0} (point size {1})", this.Symbol, pointSize);
        }
    }
    
    public class CharacterB : Character
    {
        public CharacterB()
        {
            this.Symbol = 'B';
            this.Height = 100;
            this.Width = 140;
            this.Ascent = 72;
            this.Descent = 0;
        }

        public override void Display(int pointSize)
        {
            Console.WriteLine("{0} (point size {1})", this.Symbol, pointSize);
        }
    }
    
    public class CharacterFactory
    {
        private readonly Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public int NumberOfObjects
        {
            get
            {
                return this.characters.Count;
            }
        }

        public Character GetCharacter(char key)
        {
            Character character = null;
            if (this.characters.ContainsKey(key))
            {
                character = this.characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;
                }

                this.characters.Add(key, character);
            }

            return character;
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            FlyweightDemo();

            Console.WriteLine(new string('-', 60));
        }

        private static void FlyweightDemo()
        {
            
            const string Document = "AAABBBAB";

            var characterFactory = new CharacterFactory();

            var pointSize = 10;

            foreach (var c in Document)
            {
                pointSize++;
                var character = characterFactory.GetCharacter(c);
                character.Display(pointSize);
            }

            Console.WriteLine(
                "Total number of character objects: {0}",
                characterFactory.NumberOfObjects);
        }
    }

### UML Diagram

![UML Diagram](http://www.coderanch.com/t/493146/a/1059/flywe050.gif)