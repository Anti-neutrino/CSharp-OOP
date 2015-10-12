namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class HardDrive
    {
        protected int capacity;    

        public abstract int Capacity { get; }

        public abstract void SaveData(int address, string newData);
      
        public abstract string LoadData(int address);     
    }
}
