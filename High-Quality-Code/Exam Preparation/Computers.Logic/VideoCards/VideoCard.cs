namespace Computers.Logic
{
    using System;

    public abstract class VideoCard
    {
        public void Draw(string a)
        {
            var color = this.GetColor();   
            Console.ForegroundColor = ConsoleColor.Green;    
            Console.WriteLine(a);
            Console.ResetColor();
        }

        public abstract ConsoleColor GetColor();
    }
}