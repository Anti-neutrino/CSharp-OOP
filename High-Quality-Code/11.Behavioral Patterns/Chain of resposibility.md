# Behavioral patterns

### Chain of responsibility

##### Мотивация
* С този шаблон обработваме заявка, като я подаваме на един обект.В случай ,че този обект не може да я обработи я предава на следващия и така ,докато някой обект от йерархията обработи заявката.
* Заявката се свързва само с един обект, така че последователността е от значение.
* Този шаблон съдържа лист от обекти ,на който един по един се подава заявката,като всеки обект знае само за следващия и съдържа референция към него.
* Съшо може да се имплементира с дървовидна структура.

##### Употреба
* По подобен начин е имплементиран Exception handling.
* При игра в казино,ако клиентът иска да заложи сума,по-голяма от максимално остановения за казиното залог,той пита крупието дали това е възможно.Крупието от своя страна не може да му отговори и затова пита управителя.Ако и той не може да даде отговор се обръща към собственика на казиното,който трябва да реши създалият се проблем.

##### Пример
    internal abstract class Approver
    {
        protected Approver Successor { get; set; }
        public void SetSuccessor(Approver successor)
        {
            this.Successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }
    
    internal class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine(
                    "{0} approved request #{1}", 
                    this.GetType().Name,
                    purchase.Number);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessRequest(purchase);
            }
        }
    }
    
    internal class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine(
                    "{0} approved request #{1}",
                    this.GetType().Name,
                    purchase.Number);
            }
            else
            {
                Console.WriteLine(
                    "Request #{0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }
    
    internal class TeamLead : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine(
                    "{0} approved request #{1}",
                    this.GetType().Name,
                    purchase.Number);
            }
            else if (this.Successor != null)
            {
                this.Successor.ProcessRequest(purchase);
            }
        }
    }
    
    internal class Purchase
    {
        public Purchase(int number, double amount)
        {
            this.Number = number;
            this.Amount = amount;
        }

        public int Number { get; set; }

        public double Amount { get; set; }
    }
    
    public static class Test
    {
        public static void Main()
        {
            Approver teamLead = new TeamLead();
            Approver vp = new VicePresident();
            Approver ceo = new President();

            teamLead.SetSuccessor(vp);
            vp.SetSuccessor(ceo);

            var purchase = new Purchase(2034, 350.00);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2035, 32590.10);
            teamLead.ProcessRequest(purchase);

            purchase = new Purchase(2036, 122100.00);
            teamLead.ProcessRequest(purchase);
        }
    }
    
##### UML Diagram
![Picture](http://www.dofactory.com/images/diagrams/net/chain.gif)    