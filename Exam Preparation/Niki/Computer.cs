namespace Computers.UI
{
    using System;
    using System.Collections.Generic;

    public class Computer
    {
        private readonly LaptopBattery battery;

        public Cpu Cpu { get; set; }

        public IEnumerable<HardDriver> HardDrives { get; set; }

        public HardDriver VideoCard { get; set; }

        public Rammstein Ram { get; set; }
        
        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
        }

        public void Play(int guessNumber)
        {
            Cpu.rand(1, 10);
            var number = this.Ram.LoadValue();
            if (number + 1 != guessNumber + 1)
            {
                this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.VideoCard.Draw("You win!");
            }
        }

        internal Computer(ComputerType type,
            Cpu cpu,
            Rammstein ram,
            IEnumerable<HardDriver> hardDrives,
            HardDriver videoCard,
            LaptopBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;

            if ((type != ComputerType.LAPTOP) && (type != ComputerType.PC))
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        internal void Process(int data)
        {
            this.Ram.SaveValue(data);

            // TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
