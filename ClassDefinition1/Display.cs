using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GSMProperties
{
    class Display
    {
        private double displaySize;
        private string displayColors;

        public Display(double displaySize, string displayColors)
        {
            this.displaySize = displaySize;
            this.displayColors = displayColors;
        }

        public double DisplaySize
        {
            get { return displaySize; }
            set { displaySize = value; }
        }

        public string DisplayColors
        {
            get { return displayColors; }
            set { displayColors = value; }
        }
    }
}
