namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class Server : Computer
    {
        internal Server(
           Cpu cpu,
           Ram ram,
           IEnumerable<HardDrive> hardDrives,
           MonochromeVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {   
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);

            // TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}