using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseMove
{
    public class HorseMove
    {
        static int rows;
        static int cols;
        static int increaseNumber = 1;
        static Queue<Coordinates> coords = new Queue<Coordinates>();

        static void BFS(int[,] matrix, Coordinates coord)
        {
            coords.Enqueue(coord);

            while (coords.Count > 0)
            {
                var currentNode = coords.Dequeue();
                if (currentNode.X >= 0 && currentNode.X < rows && currentNode.X >= 0 && currentNode.Y < cols)
                {
                    if (currentNode.X + 1 < rows && currentNode.Y + 2 < cols)
                    {
                        if (matrix[currentNode.X + 1, currentNode.Y + 2] == 0)
                        {
                            matrix[currentNode.X + 1, currentNode.Y + 2] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X + 1, currentNode.Y + 2);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X + 1 < rows && currentNode.Y - 2 >= 0)
                    {
                        if (matrix[currentNode.X + 1, currentNode.Y - 2] == 0)
                        {
                            matrix[currentNode.X + 1, currentNode.Y - 2] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X + 1, currentNode.Y - 2);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X + 2 < rows && currentNode.Y - 1 >= 0)
                    {
                        if (matrix[currentNode.X + 2, currentNode.Y - 1] == 0)
                        {
                            matrix[currentNode.X + 2, currentNode.Y - 1] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinate = new Coordinates(currentNode.X + 2, currentNode.Y - 1);
                            coords.Enqueue(newCoordinate);
                        }
                    }

                    if (currentNode.X - 2 >= 0 && currentNode.Y - 1 >= 0)
                    {
                        if (matrix[currentNode.X - 2, currentNode.Y - 1] == 0)
                        {
                            matrix[currentNode.X - 2, currentNode.Y - 1] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X - 2, currentNode.Y - 1);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X - 1 >= 0 && currentNode.Y - 2 >= 0)
                    {
                        if (matrix[currentNode.X - 1, currentNode.Y - 2] == 0)
                        {
                            matrix[currentNode.X - 1, currentNode.Y - 2] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X - 1, currentNode.Y - 2);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X - 2 >= 0 && currentNode.Y + 1 < cols)
                    {
                        if (matrix[currentNode.X - 2, currentNode.Y + 1] == 0)
                        {
                            matrix[currentNode.X - 2, currentNode.Y + 1] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X - 2, currentNode.Y + 1);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X + 2 < rows && currentNode.Y + 1 < cols)
                    {
                        if (matrix[currentNode.X + 2, currentNode.Y + 1] == 0)
                        {
                            matrix[currentNode.X + 2, currentNode.Y + 1] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X + 2, currentNode.Y + 1);
                            coords.Enqueue(newCoordinates);
                        }
                    }

                    if (currentNode.X - 1 >= 0 && currentNode.Y + 2 < cols)
                    {
                        if (matrix[currentNode.X - 1, currentNode.Y + 2] == 0)
                        {
                            matrix[currentNode.X - 1, currentNode.Y + 2] = matrix[currentNode.X, currentNode.Y] + increaseNumber;
                            Coordinates newCoordinates = new Coordinates(currentNode.X - 1, currentNode.Y + 2);
                            coords.Enqueue(newCoordinates);
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Console.Write("Matrix rows: ");
            rows = int.Parse(Console.ReadLine());
            Console.Write("Matrix cols: ");
            cols = int.Parse(Console.ReadLine());
            Console.Write("Starting point X coord: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Starting point Y coord: ");
            int y = int.Parse(Console.ReadLine());
            Coordinates coord = new Coordinates(x, y);
            int[,] matrix = new int[rows, cols];

            matrix[x, y] = 1;
            BFS(matrix,coord);

            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("{0}   ", matrix[i, cols/2]);
            }
        }
    }
}
