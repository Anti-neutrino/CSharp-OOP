namespace Computers.Logic
{
    using System;

    public class MonochromeVideoCard : VideoCard
    {
        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }
    }
}
