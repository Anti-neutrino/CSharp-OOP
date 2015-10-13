namespace Computers.Logic
{
    using System;

    public abstract class Cpu : IMotherBoardComponent
    {
        private static readonly Random Random = new Random();
        private readonly Ram ram;
        private readonly VideoCard videoCard;
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
                this.motherBoard.DrawOnVideoCard("Number too low.");
            }
            else if (data > this.GetMaxValue())
            {
                this.motherBoard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.motherBoard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        internal void Rand(int a, int b)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));

            this.motherBoard.SaveRamValue(randomNumber);
        }

        protected abstract int GetMaxValue();

        public void AttachTo(IMotherBoard motherBoard)
        {
            this.motherBoard = motherBoard;
        }
    }
}
