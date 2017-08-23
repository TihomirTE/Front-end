using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._3D_Labyrinth
{
    public class Labyrinth
    {
        

        public static void Main()
        {
            var start = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var startCell = new Cell<int>(start[0], start[1], start[2], 0);

            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var lev = dimensions[0];
            var r = dimensions[1];
            var c = dimensions[2];

            var labyrinth = new char[lev, r, c];

            for (int i = 0; i < lev; i++)
            {
                for (int row = 0; row < r; row++)
                {
                    var line = Console.ReadLine().ToArray();

                    for (int col = 0; col < c; col++)
                    {
                        labyrinth[i, row, col] = line[col];
                    }
                }
            }

            var used = new HashSet<Cell<int>>();
            var queue = new Queue<Cell<int>>();
            queue.Enqueue(startCell);
            used.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                // Left
                if (cell.Column > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column - 1, cell.NumOfMoves + 1);

                    if (!used.Contains(newCell) && 
                        labyrinth[cell.Level, cell.Row, cell.Column - 1] != '#')
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Right
                if (cell.Column < c - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row, cell.Column + 1, cell.NumOfMoves + 1);

                    if (!used.Contains(newCell) &&
                        labyrinth[cell.Level, cell.Row, cell.Column + 1] != '#')
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Backward
                if (cell.Row > 0)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row - 1, cell.Column, cell.NumOfMoves + 1);

                    if (!used.Contains(newCell) &&
                        labyrinth[cell.Level, cell.Row - 1, cell.Column] != '#')
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Forward
                if (cell.Row < r - 1)
                {
                    var newCell = new Cell<int>(cell.Level, cell.Row + 1, cell.Column, cell.NumOfMoves + 1);

                    if (!used.Contains(newCell) &&
                        labyrinth[cell.Level, cell.Row + 1, cell.Column] != '#')
                    {
                        queue.Enqueue(newCell);
                        used.Add(newCell);
                    }
                }

                // Up
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'U')
                {
                    if (cell.Level == lev - 1)
                    {
                        Console.WriteLine(cell.NumOfMoves + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level + 1, cell.Row, cell.Column, cell.NumOfMoves + 1);

                        if (!used.Contains(newCell) &&
                            labyrinth[cell.Level + 1, cell.Row, cell.Column] != '#')
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }

                // Down
                if (labyrinth[cell.Level, cell.Row, cell.Column] == 'D')
                {
                    if (cell.Level == 0)
                    {
                        Console.WriteLine(cell.NumOfMoves + 1);
                        Environment.Exit(0);
                    }
                    else
                    {
                        var newCell = new Cell<int>(cell.Level - 1, cell.Row, cell.Column, cell.NumOfMoves + 1);

                        if (!used.Contains(newCell) &&
                            labyrinth[cell.Level - 1, cell.Row, cell.Column] != '#')
                        {
                            queue.Enqueue(newCell);
                            used.Add(newCell);
                        }
                    }
                }
            }
        }

        public class Cell<T>
        {
            public Cell(T level, T row, T column, int numOfMoves)
            {
                this.Level = level;
                this.Row = row;
                this.Column = column;
                this.NumOfMoves = numOfMoves;
            }
            public T Level { get; set; }

            public T Row { get; set; }

            public T Column { get; set; }

            public int NumOfMoves { get; set; }

            public override bool Equals(object obj)
            {
                var otherCell = obj as Cell<T>;
                if (otherCell == null)
                {
                    return false;
                }

                return this.Level.Equals(otherCell.Level) 
                    && this.Row.Equals(otherCell.Row)
                    && this.Column.Equals(otherCell.Column);
            }

            public override int GetHashCode()
            {
                return this.Level.GetHashCode() ^
                    this.Row.GetHashCode() ^
                    this.Column.GetHashCode();
            }
        }
    }
}
