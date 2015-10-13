namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;

    public class Laptop : Computer
    {
        private const string BatteryStatusStringFormat = "Battery status: {0}%";
        private readonly LaptopBattery battery;  

        public Laptop(
           Cpu cpu,
           Ram ram,
           IEnumerable<HardDrive> hardDrives,
           VideoCard videoCard,
            LaptopBattery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format(BatteryStatusStringFormat, this.battery.Percentage));
        }
    }
}
