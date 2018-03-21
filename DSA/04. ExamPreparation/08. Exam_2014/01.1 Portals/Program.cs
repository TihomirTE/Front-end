using System;
using System.Linq;

namespace _01._1_Portals
{
    public class Program
    {
        private static int[,] matrix;
        private static int sumPower = 0;

        public static void Main()
        {
            var startLocation = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startRow = startLocation[0];
            int startCol = startLocation[1];

            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = dimensions[0];
            int c = dimensions[1];

            matrix = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < c; j++)
                {
                    if (line[j] != "#")
                    {
                        matrix[i, j] = int.Parse(line[j]);
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            BFS(new Position { Row = startRow, Col = startCol, Power = 0, CurrentState = matrix });
            Console.WriteLine(sumPower);
        }

        private static void BFS(Position position)
        {
            if (position.Power > sumPower)
            {
                sumPower = position.Power;
            }

            matrix = position.CurrentState;
            var currentPower = matrix[position.Row, position.Col];
            if (currentPower > 0)
            {
                var nextPower = position.Power + currentPower;

                // up
                var up = position.Row - currentPower;
                if (up >= 0 && matrix[up, position.Col] != -1)
                {
                    matrix[position.Row, position.Col] = 0;
                    BFS(new Position { Row = up, Col = position.Col, Power = nextPower, CurrentState = GetState(matrix) });
                    matrix[position.Row, position.Col] = currentPower;
                }

                // down
                var down = position.Row + currentPower;
                if (down < matrix.GetLength(0) && matrix[down, position.Col] != -1)
                {
                    matrix[position.Row, position.Col] = 0;
                    BFS(new Position { Row = down, Col = position.Col, Power = nextPower, CurrentState = GetState(matrix) });
                    matrix[position.Row, position.Col] = currentPower;
                }

                // left
                var left = position.Col - currentPower;
                if (left >= 0 && matrix[position.Row, left] != -1)
                {
                    matrix[position.Row, position.Col] = 0;
                    BFS(new Position { Row = position.Row, Col = left, Power = nextPower, CurrentState = GetState(matrix) });
                    matrix[position.Row, position.Col] = currentPower;
                }

                // right
                var right = position.Col + currentPower;
                if (right < matrix.GetLength(1) && matrix[position.Row, right] != -1)
                {
                    matrix[position.Row, position.Col] = 0;
                    BFS(new Position { Row = position.Row, Col = right, Power = nextPower, CurrentState = GetState(matrix) });
                    matrix[position.Row, position.Col] = currentPower;
                }
            }
        }

        private static int[,] GetState(int[,] state)
        {
            var newArray = new int[state.GetLength(0), state.GetLength(1)];
            for (int i = 0; i < state.GetLength(0); i++)
            {
                for (int j = 0; j < state.GetLength(1); j++)
                {
                    newArray[i, j] = state[i, j];
                }
            }

            return newArray;
        }

        public struct Position
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Power { get; set; }

            public int[,] CurrentState { get; set; }
        }
    }
}
