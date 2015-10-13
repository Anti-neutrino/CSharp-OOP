namespace Computers.Logic
{
    public class Cpu32 : Cpu
    {
        private const int MaxValue = 500;

        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return MaxValue;
        }
    }
}
