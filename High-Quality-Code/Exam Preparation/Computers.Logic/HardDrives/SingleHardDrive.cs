namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SingleHardDrive : HardDrive
    {
        private Dictionary<int, string> data;

        public SingleHardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
