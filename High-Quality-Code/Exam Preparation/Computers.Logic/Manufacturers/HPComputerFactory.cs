namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class HPComputerFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(new Cpu32(2), new Ram(2), new[] { new SingleHardDrive(500) }, new MonochromeVideoCard());

            return pc;
        }

        public Laptop CreateLaptop()
        {
                var laptop = new Laptop(
                new Cpu64(2),
                new Ram(4),
                new[] { new SingleHardDrive(500) },
                new MonochromeVideoCard(),
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var server = new Server(
                new Cpu32(4),
                new Ram(32),
                new List<HardDrive>
                    {
                            new RaidArray(new List<SingleHardDrive> { new SingleHardDrive(1000), new SingleHardDrive(1000) })
                    },
               new MonochromeVideoCard());

            return server;
        }
    }
}
