namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class LenovoComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu64(2),
                new Ram(4),
                new[] { new SingleHardDrive(2000) },
                new ColorfulVideoCard());

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu64(2),
                new Ram(16),
                new[] { new SingleHardDrive(1000) },
                new ColorfulVideoCard(),
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var server = new Server(
                new Cpu128(2),
                new Ram(8),
                new List<HardDrive>
                    {
                            new RaidArray(new List<SingleHardDrive> { new SingleHardDrive(500), new SingleHardDrive(500) })
                    },
                new MonochromeVideoCard());

            return server;
        }
    }
}
