# Шаблони за структуриране на обекти ( Structural Patterns)

## Proxy pattern

### Мотивация
* Proxy pattern е обект представящ друг обект.
* Този обект играе ролята на интерфейс към оригиналния обект.
* Създава се такъв обект за да се защити оригиналния от повишаване на сложността му.

### Видове
* Remote proxy: Локално представяне на обекти,имащи раличен адрес.
* Virtual proxy: При поискване създава обект заемащ повече памет
* Protection proxy: Изплозва се за да се контролира достъпа до обекта ,базиран на някакви правила

### Употреба
* WPF(decouple networking details)
* Entity Framework
* Bank account validation

### Пример
    public interface IBankAccount
    {
        bool Deposit(decimal amount);

        bool Withdraw(decimal amount);

        decimal CurrentBallance();
    }

    public class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            this.Ballance = 2500;
        }

        private decimal Ballance { get; set; }

        public bool Deposit(decimal amount)
        {
            this.Ballance += amount;

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            this.Ballance -= amount;

            return true;
        }

        public decimal CurrentBallance()
        {
            return this.Ballance;
        }
    }
    
    public class BankAccountProxy : IBankAccount
    {
        private readonly bool userIsAuthorized;

        private BankAccount realAccount;

        public BankAccountProxy(string userName, string secretKey)
        {
            if (userName != null && secretKey != null)
            {
                this.userIsAuthorized = true;
            }
        }

        public bool Deposit(decimal amount)
        {
            if (amount < 25)
            {
                Console.WriteLine("Minimum deposit amount is 25!");
                return false;
            }

            if (amount > 1000)
            {
                Console.WriteLine("Maximum deposit amount is 1000!");
                return false;
            }

            if (!this.userIsAuthorized)
            {
                Console.WriteLine("You are not authorized!");
                Console.WriteLine("Redirecting you to login screen...");
                return false;
            }

            this.CheckIfAccountIsActive();

            this.realAccount.Deposit(amount);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            this.CheckIfAccountIsActive();

            this.realAccount.Withdraw(amount);
            return true;
        }

        public decimal CurrentBallance()
        {
            this.CheckIfAccountIsActive();

            return this.realAccount.CurrentBallance();
        }

        private void CheckIfAccountIsActive()
        {
            if (this.realAccount == null)
            {
                this.realAccount = new BankAccount();
            }
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            IBankAccount account = new BankAccountProxy("it's me", "for real");

            DisplayBallance(account);
            Deposit(25, account);
            DisplayBallance(account);
            Withdraw(250, account);
            DisplayBallance(account);
            Deposit(700, account);
            DisplayBallance(account);
        }

        private static void DisplayBallance(IBankAccount account)
        {
            Console.WriteLine("{0:C}", account.CurrentBallance());
        }

        private static void Withdraw(decimal amount, IBankAccount account)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine("Withdrawal complete: {0:C}", amount);
            }
        }

        private static void Deposit(decimal amount, IBankAccount account)
        {
            if (account.Deposit(amount))
            {
                Console.WriteLine("Deposit complete: {0:C}", amount);
            }
        }
    }
    
    
   

### UML Diagram

![UML Diagram](https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Proxy_pattern_diagram.svg/400px-Proxy_pattern_diagram.svg.png)