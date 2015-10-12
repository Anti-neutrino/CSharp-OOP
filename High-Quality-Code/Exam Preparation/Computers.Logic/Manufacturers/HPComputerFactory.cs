namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class HPComputerFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(2);
            var videoCard = new MonochromeVideoCard();
            var pc = new PersonalComputer(new Cpu32(2, ram, videoCard), ram, new[] { new SingleHardDrive(500) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var videoCard = new MonochromeVideoCard();
            var ram = new Ram(4);
            var laptop = new Laptop(
                new Cpu64(2, ram, videoCard),
                ram,
                new[] { new SingleHardDrive(500) },
                videoCard,
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(32);
            var videoCard = new MonochromeVideoCard();
            var server = new Server(
                new Cpu32(4, ram, videoCard),
                ram,
                new List<HardDrive>
                    {
                            new RaidArray(new List<SingleHardDrive> { new SingleHardDrive(1000), new SingleHardDrive(1000) })
                    },
                videoCard);

            return server;
        }
    }
}
