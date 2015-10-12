namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class DellComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(8);
            var videoCard = new MonochromeVideoCard();
            var pc = new PersonalComputer(new Cpu64(4, ram, videoCard), ram, new[] { new SingleHardDrive(1000) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram2 = new Ram(8);
            var videoCard = new MonochromeVideoCard();
            var laptop = new Laptop(
                new Cpu32(4, ram2, videoCard),
                ram2,
                new[] { new SingleHardDrive(1000) },
                videoCard,
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram = new Ram(64);
            var card = new MonochromeVideoCard();
            var server = new Server(
                 new Cpu64(8, ram, card),
                 ram,
                 new List<HardDrive>
                     {
                            new RaidArray(new List<SingleHardDrive> { new SingleHardDrive(2000), new SingleHardDrive(2000) })
                     },
                 card);

            return server;
        }
    }
}
