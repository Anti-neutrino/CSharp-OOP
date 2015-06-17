using System;

namespace Battle
{     
    class Test
    {
        static void Main()
        {
            Warrior first = new Warrior("Tiny",10,120,14,"Sentinel");
            Wizzard second = new Wizzard("Viper", 8, 150, 32, "Scorge");
            Game newGame = new Game(first, second);
            newGame.Run();
        }
    }
}
