namespace Computers.Logic
{
    public class Cpu64 : Cpu
    {
        public Cpu64(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return 1000;
        }
    }
}
