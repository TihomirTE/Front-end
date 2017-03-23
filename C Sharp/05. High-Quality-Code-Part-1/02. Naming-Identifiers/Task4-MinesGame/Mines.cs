using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Mines
    {
        public static void Main()
        {
            const int MAX_OPENED_CELLS = 35;

            string command = string.Empty;
            char[,] field = CreatePlayField();
            char[,] bombs = PutBombs();
            int counterOpenCells = 0;
            bool isBomb = false;
            List<TotalPoints> champions = new List<TotalPoints>(6);
            int row = 0;
            int column = 0;

            bool isStart = true;
            bool isAlive = false;

            do
            {
                if (isStart)
                {
                    Console.WriteLine("Let play “Mines”. Try to find the field cells without mines." +
                    " Command: 'top' show ranking, 'restart' starts new game, 'exit' exit from the game");

                    DrawField(field);
                    isStart = false;
                }

                Console.Write("Enter command : ");
                command = Console.ReadLine().Trim();

                var turn = command.Split(' ');

                if (turn.Length == 3)
                {
                    if (int.TryParse(turn[1].ToString(), out row) &&
                        int.TryParse(turn[2].ToString(), out column) &&
                        row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        RankPlayers(champions);
                        break;
                    case "restart":
                        field = CreatePlayField();
                        bombs = PutBombs();
                        DrawField(field);
                        isBomb = false;
                        isStart = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                MakeMove(field, bombs, row, column);
                                counterOpenCells++;
                            }
                            if (MAX_OPENED_CELLS == counterOpenCells)
                            {
                                isAlive = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }

                        else
                        {
                            isBomb = true;
                        }
                        break;

                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isBomb)
                {
                    DrawField(bombs);
                    Console.Write("\nBoom! Game Over! \nScore: {0} points. " +
                        "Enter your nickname: ", counterOpenCells);
                    string nickname = Console.ReadLine();
                    TotalPoints t = new TotalPoints(nickname, counterOpenCells);

                    if (champions.Count < 5)
                    {
                        champions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < t.Points)
                            {
                                champions.Insert(i, t);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((TotalPoints firstPlayer, TotalPoints secondPlayer) =>
                                    secondPlayer.Name.CompareTo(firstPlayer.Name));

                    champions.Sort((TotalPoints firstPlayer, TotalPoints secondPlayer) =>
                                    secondPlayer.Points.CompareTo(firstPlayer.Points));

                    RankPlayers(champions);

                    field = CreatePlayField();
                    bombs = PutBombs();
                    counterOpenCells = 0;

                    isBomb = false;
                    isStart = true;
                }

                if (isAlive)
                {
                    Console.WriteLine("\nCongratulation! You opened 35 cells without aiming single mine.");

                    DrawField(bombs);

                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();

                    TotalPoints points = new TotalPoints(name, counterOpenCells);
                    champions.Add(points);

                    RankPlayers(champions);

                    field = CreatePlayField();
                    bombs = PutBombs();
                    counterOpenCells = 0;

                    isAlive = false;
                    isStart = true;
                }

            } while (command != "exit");
        }

        private static void RankPlayers(List<TotalPoints> points)
        {
            Console.WriteLine("\nPoints:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("empty rating!\n");
            }
        }

        private static void MakeMove(char[,] field, char[,] bombs, int row, int col)
        {
            char quanityOfBombs = GetBombs(bombs, row, col);
            bombs[row, col] = quanityOfBombs;
            field[row, col] = quanityOfBombs;
        }

        private static void DrawField(char[,] fieldSize)
        {
            int rows = fieldSize.GetLength(0);
            int cols = fieldSize.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", fieldSize[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
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

        private static char[,] PutBombs()
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

            List<int> listOfBombs = new List<int>();

            while (listOfBombs.Count < 15)
            {
                Random random = new Random();
                int bombCell = random.Next(50);

                if (!listOfBombs.Contains(bombCell))
                {
                    listOfBombs.Add(bombCell);
                }
            }

            foreach (int currentBomb in listOfBombs)
            {
                int col = (currentBomb / cols);
                int row = (currentBomb % cols);

                if (row == 0 && currentBomb != 0)
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

        private static void Calculations(char[,] field)
        {
            int row = field.GetLength(0);
            int col = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char numberOfBombs = GetBombs(field, i, j);
                        field[i, j] = numberOfBombs;
                    }
                }
            }
        }

        private static char GetBombs(char[,] field, int row, int col)
        {
            int numberOfBombs = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    numberOfBombs++;
                }
            }

            return char.Parse(numberOfBombs.ToString());
        }
    }
}
