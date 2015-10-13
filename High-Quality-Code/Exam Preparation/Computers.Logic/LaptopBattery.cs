namespace Computers.Logic
{
    public class LaptopBattery
    {
        private const int UpperPercentageValue = 100;
        private const int BottomPercentageValue = 0;

        public LaptopBattery()
        { 
            this.Percentage = UpperPercentageValue / 2;
        } 

        public int Percentage { get; set; }

        public void Charge(int points)
        {
            this.Percentage += points;
            if (this.Percentage > UpperPercentageValue)
            {
                this.Percentage = UpperPercentageValue;
            }

            if (this.Percentage < BottomPercentageValue)
            {
                this.Percentage = BottomPercentageValue;
            }
        }
    }
}
