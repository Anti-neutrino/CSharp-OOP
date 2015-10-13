namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class DellComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(new Cpu64(4), new Ram(8), new[] { new SingleHardDrive(1000) }, new MonochromeVideoCard());

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu32(4),
                new Ram(8),
                new[] { new SingleHardDrive(1000) },
                new MonochromeVideoCard(),
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var server = new Server(
                 new Cpu64(8),
                 new Ram(64),
                 new List<HardDrive>
                     {
                            new RaidArray(new List<SingleHardDrive> { new SingleHardDrive(2000), new SingleHardDrive(2000) })
                     },
                 new MonochromeVideoCard());

            return server;
        }
    }
}
