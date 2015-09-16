using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceInLabirinth
{
 
    class Labirinth
    {
        

        static void Main()
        {
            string[,] matrix = new string[,] 
        { 
        {"0","0","0","x","0","x"},
        {"0","x","0","x","0","x"},
        {"0","0","x","0","x","0"},
        {"0","x","0","0","0","0"},
        {"0","0","0","x","x","0"},
        {"0","0","0","x","0","x"}
        };

            bool[,] usedCell = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            if(row>=0&&row<matrix.GetLength(0)&&col>=0&&col<matrix.GetLength(1))
            {
                matrix[row, col] = "1";
            }

            Queue<Point> queue = new Queue<Point>();
            Point startPoint = new Point(row, col);
            queue.Enqueue(startPoint);
            while(queue.Count>0)
            {
                Point currentPoint = queue.Dequeue();
                usedCell[currentPoint.xCoord, currentPoint.yCoord] = true;

                if (currentPoint.xCoord + 1 < matrix.GetLength(0) && matrix[currentPoint.xCoord + 1, currentPoint.yCoord] != "x" && !usedCell[currentPoint.xCoord + 1, currentPoint.yCoord])
                {
                    Point newPoint = new Point(currentPoint.xCoord + 1, currentPoint.yCoord);
                    matrix[newPoint.xCoord, newPoint.yCoord] = ((int.Parse(matrix[currentPoint.xCoord, currentPoint.yCoord])) + 1).ToString();                 
                    queue.Enqueue(newPoint);
                }

                if (currentPoint.xCoord - 1 >= 0 && matrix[currentPoint.xCoord - 1, currentPoint.yCoord] != "x" && !usedCell[currentPoint.xCoord - 1, currentPoint.yCoord])
                {
                    Point newPoint = new Point(currentPoint.xCoord - 1, currentPoint.yCoord);
                    int number = int.Parse(matrix[currentPoint.xCoord, currentPoint.yCoord])+1;
                    string numberToString = number.ToString();
                    matrix[newPoint.xCoord, newPoint.yCoord] = numberToString;                 
                    queue.Enqueue(newPoint);
                }

                if (currentPoint.yCoord - 1 >= 0 && matrix[currentPoint.xCoord, currentPoint.yCoord - 1] != "x" && !usedCell[currentPoint.xCoord , currentPoint.yCoord-1])
                {
                    Point newPoint = new Point(currentPoint.xCoord, currentPoint.yCoord - 1);
                    int number = int.Parse(matrix[currentPoint.xCoord, currentPoint.yCoord]);
                    string numberToString = number.ToString();
                    matrix[newPoint.xCoord, newPoint.yCoord] = numberToString;               
                    queue.Enqueue(newPoint);
                }

                if (currentPoint.yCoord + 1 < matrix.GetLength(1) && matrix[currentPoint.xCoord, currentPoint.yCoord + 1] != "x" && !usedCell[currentPoint.xCoord , currentPoint.yCoord+1])
                {
                    Point newPoint = new Point(currentPoint.xCoord, currentPoint.yCoord + 1);
                    matrix[newPoint.xCoord, newPoint.yCoord] = ((int.Parse(matrix[currentPoint.xCoord, currentPoint.yCoord].ToString()) + 1)).ToString();
                    queue.Enqueue(newPoint);
                }
            }

            matrix[row, col] = "*";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                     if(matrix[i,j]=="0")
                     {
                         matrix[i, j] = "u";
                     }
                }
            }


            for(int i=0;i<matrix.GetLength(0);i++)
            {
                for(int j=0;j<matrix.GetLength(1);j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
