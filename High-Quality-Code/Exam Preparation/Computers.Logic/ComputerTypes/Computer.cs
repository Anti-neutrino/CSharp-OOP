namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public abstract class Computer
    {    
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
        }

        protected Cpu Cpu { get; set; }

        protected IEnumerable<HardDrive> HardDrives { get; set; }

        protected VideoCard VideoCard { get; set; }

        protected Ram Ram { get; set; }
    }
}
