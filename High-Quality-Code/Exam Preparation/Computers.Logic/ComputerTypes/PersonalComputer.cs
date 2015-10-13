namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class PersonalComputer : Computer
    {
        private const string WinMessage = "You win!";
        private const string WrongNumber = "You didn't guess the number {0}.";

        internal PersonalComputer(
           Cpu cpu,
           Ram ram,
           IEnumerable<HardDrive> hardDrives,
           VideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            Cpu.Rand(1, 10);
            var number = this.Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format(WrongNumber, number));
            }
            else
            {
                this.VideoCard.Draw(WinMessage);
            }
        }
    }
}
