namespace Mines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Mine
    {        
        public static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayingField();
            char[,] bombs = SetBombs();
            int counter = 0;
            bool isBoombed = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool isAlive = true;
            const int MAX = 35;
            bool isOver35 = false;

            do
            {
                if (isAlive)
                {
                    Console.WriteLine("Let's play Mines”. Try your luck as find the peace fields.\n" +
                    " Command 'top' displays ranking, \n 'restart'-start new game,\n 'exit' -exit the game ");
                    DrawField(field);
                    isAlive = false;
                }

                Console.Write("Set row and col : ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;

                    case "restart":
                        field = CreatePlayingField();
                        bombs = SetBombs();
                        DrawField(field);
                        isBoombed = false;
                        isAlive = false;
                        break;

                    case "exit":
                        Console.WriteLine("Bye,Bye!");
                        break;

                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                YourTurn(field, bombs, row, col);
                                counter++;
                            }

                            if (MAX == counter)
                            {
                                isOver35 = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            isBoombed = true;
                        }

                        break;

                    default:
                        Console.WriteLine("\nInvalid command! Enter again!\n");
                        break;
                }

                if (isBoombed)
                {
                    DrawField(bombs);

                    Console.Write("\nHeoical dead wit {0} points. " + "nickname : ", counter);

                    string nickname = Console.ReadLine();
                    Player newPoint = new Player(nickname, counter);

                    if (champions.Count < 5)
                    {
                        champions.Add(newPoint);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < newPoint.Points)
                            {
                                champions.Insert(i, newPoint);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(champions);

                    field = CreatePlayingField();
                    bombs = SetBombs();
                    counter = 0;
                    isBoombed = false;
                    isAlive = true;
                }

                if (isOver35)
                {
                    Console.WriteLine("\nCongratulations!You open 35 field without loosing a life.");

                    DrawField(bombs);

                    Console.WriteLine("Name : ");

                    string newName = Console.ReadLine();
                    Player newPoints = new Player(newName, counter);

                    champions.Add(newPoints);
                    Ranking(champions);

                    field = CreatePlayingField();
                    bombs = SetBombs();

                    counter = 0;
                    isOver35 = false;
                    isAlive = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("C'moooon");
            Console.Read();
        }

        private static void Ranking(List<Player> point)
        {
            Console.WriteLine("\nPoints:");

            if (point.Count > 0)
            {
                for (int i = 0; i < point.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes ", i + 1, point[i].Name, point[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void YourTurn(char[,] field, char[,] bombs, int rol, int col)
        {
            char bombCount = SymbolSelection(bombs, rol, col);

            bombs[rol, col] = bombCount;
            field[rol, col] = bombCount;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingField()
        {
            int boardRows = 5;
            int boardColumns = 10;

            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> newList = new List<int>();

            while (newList.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!newList.Contains(randomNumber))
                {
                    newList.Add(randomNumber);
                }
            }

            foreach (int item in newList)
            {
                int col = (item / cols);
                int row = (item % cols);

                if ((row == 0) && (item != 0))
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[col, row - 1] = '*';
            }

            return playField;
        }

        private static void Record(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char symbol = SymbolSelection(field, i, j);
                        field[i, j] = symbol;
                    }
                }
            }
        }

        private static char SymbolSelection(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}