namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public abstract class Computer
    {
        private MotherBoard motherBoard;

        internal Computer(
            Cpu cpu,
            Ram ram,
            IEnumerable<HardDrive> hardDrives,
            VideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.motherBoard = new MotherBoard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected Cpu Cpu { get; set; }

        protected IEnumerable<HardDrive> HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Ram Ram { get; set; }
    }
}
