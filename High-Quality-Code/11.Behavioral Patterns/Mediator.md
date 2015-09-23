# Behavioral patterns

### Mediator pattern

##### Мотивация
* Mediator pattern е шаблон ,с който максимално се разкачат връзките между класовете,като така те няма нужда да знаят за сушествуването си един с друг.
* Вместо това се използва медиатор(посредник),който енкапсулира данните и чрез който може да свързваме класовете и да съставяме нова функционалнсот.
* Чрез медиатора класовете изграждат връзките помежду си, с което се намаля свързаността.
* Често се представя с три обекта:Mediator,ConcreteMediator,ConcreteCollegue
* Mediator: дефинира интерфейс за комуниация между класовете.
* Concrete mediator: имплементира Mediator интерфейс и прави връзката между Collegue обектите.
* Concrete collegue: комуникира с другите колеги чрез медиатора.

##### Употреба
* Чат ,в който имаме много участници.Ние използваме чат стая(медиатор) за да свържем всички участници един с друг.В противен случай трябва да създадем множество класове за връязкта между 2 души,на който броят им нараства експоненциално.

##### Пример
    public abstract class AbstractChatRoom
    {
        public abstract void Register(Participant participant);

        public abstract void Send(string from, string to, string message);

        public abstract void SendToAll(string from, string message);
    }
    
     public abstract class Participant
    {
        private readonly string name;
        private ChatRoom chatRoom;

        protected Participant(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public ChatRoom ChatRoom
        {
            get { return this.chatRoom; }
            set { this.chatRoom = value; }
        }

        public void Send(string to, string message)
        {
            this.chatRoom.Send(this.name, to, message);
        }

        public void SendToAll(string message)
        {
            this.chatRoom.SendToAll(this.name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, message);
        }
    }
    
     public class Beetle : Participant
    {
        public Beetle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beetle: ");
            base.Receive(from, message);
        }
    }
    
    public class NonBeetle : Participant
    {
        public NonBeetle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beetle: ");
            base.Receive(from, message);
        }
    }
    
    public class ChatRoom : AbstractChatRoom
    {
        private readonly Dictionary<string, Participant> participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!this.participants.ContainsValue(participant))
            {
                this.participants[participant.Name] = participant;
            }

            participant.ChatRoom = this;
        }

        public override void Send(string from, string to, string message)
        {
            var participant = this.participants[to];

            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }

        public override void SendToAll(string @from, string message)
        {
            foreach (var participant in this.participants)
            {
                if (participant.Key != @from)
                {
                    participant.Value.Receive(from, message);
                }
            }
        }
    }
    
    public static class Test
    {
        public static void Main()
        {
            var chatRoom = new ChatRoom();

            Participant george = new Beetle("George"); // new Beetle("George", chatRoom);
            chatRoom.Register(george);

            Participant paul = new Beetle("Paul");
            chatRoom.Register(paul);

            Participant ringo = new Beetle("Ringo");
            chatRoom.Register(ringo);

            Participant john = new Beetle("John");
            chatRoom.Register(john);

            Participant yoko = new NonBeetle("Yoko");
            chatRoom.Register(yoko);

            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");

            yoko.SendToAll("Hi, all!");
        }
    }

##### UML Diagram
![Mediator Diagram](http://www.dofactory.com/images/diagrams/net/mediator.gif)