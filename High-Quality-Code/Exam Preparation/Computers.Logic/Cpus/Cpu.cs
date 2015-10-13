namespace Computers.Logic
{
    using System;

    public abstract class Cpu : IMotherBoardComponent
    {
       public const string NumberToHigh = "Number too high.";
        public const string NumberToLow = "Number too low.";
        private const string SquareInfo = "Square of {0} is {1}.";
        private static readonly Random Random = new Random();
        private IMotherBoard motherBoard;

        internal Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            var data = this.motherBoard.LoadRamValue();
            if (data < 0)
            {
                this.motherBoard.DrawOnVideoCard(NumberToLow);
            }
            else if (data > this.GetMaxValue())
            {
                this.motherBoard.DrawOnVideoCard(NumberToHigh);
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.motherBoard.DrawOnVideoCard(string.Format(SquareInfo, data, value));
            }
        }

        public void AttachTo(IMotherBoard motherBoard)
        {
            this.motherBoard = motherBoard;
        }

        internal void Rand(int minValue, int maxValue)
        {
            int randomNumber = Random.Next(minValue, maxValue + 1);
            this.motherBoard.SaveRamValue(randomNumber);
        }
        
        protected abstract int GetMaxValue();
    }
}
