namespace Computers.UI
{
    using System;
    using System.Collections.Generic;

    public static class Computers
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            CreateComputers();
            ProccessCommand();           
        }

        private static void CreateComputers()
        {
            var manufacturer = Console.ReadLine();
            IComputersFactory computerFactory;
            if (manufacturer == "HP")
            {
                computerFactory = new HPComputerFactory();
            }
            else if (manufacturer == "Dell")
            {
                computerFactory = new DellComputersFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreatServer();
        }

        private static void ProccessCommand()
        {
            while (true)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    break;
                }

                if (c.StartsWith("Exit"))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = cp[0];
                var commanArgument = int.Parse(cp[1]);
                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commanArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commanArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commanArgument);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}
