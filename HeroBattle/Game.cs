using System;

namespace Battle
{
    class Game
    {
        private Hero firstHero;
        private Hero secondHero;

        public Game(Hero one, Hero second)
        {
            this.firstHero = one;
            this.secondHero = second;
        }

        public void Run()
        {
            Random generator = new Random();
            bool firstCheck = false;
            bool secondCheck = false;
            bool check = false;
            if (generator.Next(2) == 0)
            {
                Console.WriteLine("First player attack!");
                secondHero.takeDemage(firstHero.getAttack());
                Console.WriteLine("First player BaseAttack:{0} ", firstHero.BaseAttack);
                Console.WriteLine("Second player Health: {0}", secondHero.Health);
                Console.WriteLine();
                check = true;
                if(secondHero.Health<=0)
                {
                    Console.WriteLine("First player win!");
                    System.Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine("Second player attack!");
                firstHero.takeDemage(secondHero.getAttack());
                Console.WriteLine("Second player BaseAttack:{0} ", secondHero.BaseAttack);
                Console.WriteLine("First player Health: {0}", firstHero.Health);
                Console.WriteLine();
                if(firstHero.Health<=0)
                {
                    Console.WriteLine("Second player win!");
                    System.Environment.Exit(1);
                }
            }
            while (firstHero.Health > 0 || secondHero.Health > 0)
            {
                if (check)
                {
                    firstHero.takeDemage(secondHero.getAttack());
                    check = !check;
                    if (firstHero.Health <= 0)
                    {
                        Console.WriteLine("Second player attack!");
                        Console.WriteLine("Second player BaseAttack:{0} ", secondHero.BaseAttack);
                        Console.WriteLine("First player Health: 0");
                        Console.WriteLine();
                        Console.WriteLine("Second player win!");
                        System.Environment.Exit(1);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Second player attack!");
                    Console.WriteLine("Second player BaseAttack:{0} ", secondHero.BaseAttack);
                    Console.WriteLine("First player Health: {0}", firstHero.Health);
                    Console.WriteLine();
                }
                else
                {
                    secondHero.takeDemage(firstHero.getAttack());
                    check = !check;
                    if (secondHero.Health <= 0)
                    {
                        Console.WriteLine("First  player attack!");
                        Console.WriteLine("First player BaseAttack:{0} ", firstHero.BaseAttack);
                        Console.WriteLine("Second player Health: 0");
                        Console.WriteLine();
                        Console.WriteLine("First player win!");
                        System.Environment.Exit(1);
                    }
                    Console.WriteLine();
                    Console.WriteLine("First player attack!");
                    Console.WriteLine("First player BaseAttack:{0} ", firstHero.BaseAttack);
                    Console.WriteLine("Second player Health: {0}", secondHero.Health);
                    Console.WriteLine();
                }
            }
        }
    }
}
