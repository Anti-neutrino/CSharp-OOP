namespace Computers.Logic
{
    using System;

    public abstract class VideoCard
    {
        public void Draw(string result)
        {
            var color = this.GetColor();   
            Console.ForegroundColor = ConsoleColor.Green;    
            Console.WriteLine(result);
            Console.ResetColor();
        }

        public abstract ConsoleColor GetColor();
    }
}