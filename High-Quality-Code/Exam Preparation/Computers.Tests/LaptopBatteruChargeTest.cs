namespace Computers.Tests
{  
    using System;
    using Computers.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class LaptopBatteruChargeTest
    {
        [TestMethod]
        public void ChargeShouldAddToPercentage()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            var initChargeValue = battery.Percentage;
            battery.Charge(10);
            var deference = battery.Percentage - initChargeValue;
            Assert.AreEqual(10, deference);
        }

        [TestMethod]
        public void ChargeShouldSubstractFromPersentageWhenGivenNegativeNumber()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            var initChargeValue = battery.Percentage;
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldSubstractFromPersentageWhenGivenNumber()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 0;
            var initChargeValue = battery.Percentage;
            battery.Charge(-10);
            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void ChargeShouldSubstractFromPersentageWhenGivenZero()
        {
            var battery = new LaptopBattery();
            battery.Percentage = 50;
            var initChargeValue = battery.Percentage;
            battery.Charge(0);
            Assert.AreEqual(50, battery.Percentage);
        }
    }
}
