namespace Computers.Logic
{
    using System;

    public class ColorfulVideoCard : VideoCard
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }
    }
}
