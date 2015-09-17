using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_Statements
{
    class Program
    {

        static void VisitCell()
        {
            //...
        }
        
        static void Main()
        {
            int x=int.Parse(Console.ReadLine());
            int y=int.Parse(Console.ReadLine());
            int minX=Int32.MinValue;
            int minY=Int32.MinValue;
            int maxX=Int32.MaxValue;
            int maxY=Int32.MaxValue;
            bool shouldVisitCell = true;

            bool checkY = minY <= y && y <= maxY;
            bool checkX = minX <= x && x <= maxX;
            bool checkXAndYAndVisitCell=checkX&&checkY&&shouldVisitCell;

            if (checkXAndYAndVisitCell)
            {
                VisitCell();
            }
        }
    }
}
