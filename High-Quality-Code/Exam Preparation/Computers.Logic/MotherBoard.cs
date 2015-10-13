namespace Computers.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MotherBoard : IMotherBoard
    {
        public MotherBoard(Cpu cpu, Ram ram, VideoCard videoCard)
        {
            cpu.AttachTo(this);
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        private Ram Ram { get; set; }

        private VideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
