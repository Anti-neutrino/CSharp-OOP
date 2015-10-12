namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class DellComputersFactory : IComputersFactory
    {
        public PersonalComputer CreatePersonalComputer()
        {
            var ram = new Ram(8);
            var videoCard = new VideoCard { IsMonochrome = false };
            var pc = new PersonalComputer(new Cpu(4, 64, ram, videoCard), ram, new[] { new HardDrive(1000, false, 0) }, videoCard);

            return pc;
        }

        public Laptop CreateLaptop()
        {
            var ram2 = new Ram(8);
            var videoCard1 = new VideoCard() { IsMonochrome = false };
            var laptop = new Laptop(
                new Cpu(4, 32, ram2, videoCard1),
                ram2,
                new[] { new HardDrive(1000, false, 0) },
                videoCard1,
                new LaptopBattery());

            return laptop;
        }

        public Server CreateServer()
        {
            var ram1 = new Ram(64);
            var card = new VideoCard();
            var server = new Server(
                 new Cpu(8, 64, ram1, card),
                 ram1,
                 new List<HardDrive>
                     {
                            new HardDrive(0, true, 2, new List<HardDrive> { new HardDrive(2000, false, 0), new HardDrive(2000, false, 0) })
                     },
                 card);

            return server;
        }
    }
}
