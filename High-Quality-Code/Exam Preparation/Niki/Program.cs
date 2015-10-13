namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public static class Computers
    {
        private const string HP = "HP";
        private const string DELL = "Dell";
        private const string Lenovo = "Lenovo";
        private const string InvalidManufacturer = "Invalid Manufacturer";
        private const string Exit = "Exit";
        private const string InvalidCommand = "Invalid command!";
        private const string Charge = "Charge";
        private const string Play = "Play";
        private const string Proccess = "Proccess";

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
            if (manufacturer == HP)
            {
                computerFactory = new HPComputerFactory();
            }
            else if (manufacturer == DELL)
            {
                computerFactory = new DellComputersFactory();
            }
            else if (manufacturer == Lenovo)
            {
                computerFactory = new LenovoComputersFactory();
            }
            else
            {
                throw new InvalidArgumentException(InvalidManufacturer);
            }

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
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

                if (c.StartsWith(Exit))
                {
                    break;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    throw new ArgumentException(InvalidCommand);
                }

                var commandName = cp[0];
                var commanArgument = int.Parse(cp[1]);
                if (commandName == Charge)
                {
                    laptop.ChargeBattery(commanArgument);
                }
                else if (commandName == Proccess)
                {
                    server.Process(commanArgument);
                }
                else if (commandName == Play)
                {
                    pc.Play(commanArgument);
                }
                else
                {
                    Console.WriteLine(InvalidCommand);
                }
            }
        }
    }
}
