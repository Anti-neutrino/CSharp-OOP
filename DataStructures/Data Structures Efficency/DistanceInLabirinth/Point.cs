using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceInLabirinth
{
    public class Point
    {
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public Point(int x, int y)
        {
            this.xCoord = x;
            this.yCoord = y;
        }

    }
}
