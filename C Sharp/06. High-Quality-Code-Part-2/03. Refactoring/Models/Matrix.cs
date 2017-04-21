namespace RotatingWalkInMatrix
{
    using GameFifteen.Models;
    using System;
    using System.Text;

    public class Matrix
    {
        private readonly Cell[] targetCells;

        private int currentTargetCellIndex;

        public Matrix(int size)
        {
            this.Field = new int[size, size];
            this.targetCells = new[]
            {
                new Cell(1, 1), new Cell(1, 0), new Cell(1, -1), new Cell(0, -1), new Cell(-1, -1),
                new Cell(-1, 0), new Cell(-1, 1), new Cell(0, 1)
            };
            this.currentTargetCellIndex = 0;
            this.FillMatrix();
        }

        public int[,] Field { get; }

        public override string ToString()
        {
            var printedMatrix = new StringBuilder();
            for (int i = 0; i < this.Field.GetLength(0); i++)
            {
                for (int j = 0; j < this.Field.GetLength(0); j++)
                {
                    printedMatrix.AppendFormat("{0,3}", this.Field[i, j]);
                }

                printedMatrix.Append(Environment.NewLine);
            }

            return printedMatrix.ToString();
        }

        private Cell FindFirstEmptyCell()
        {
            Cell result = new Cell(0, 0);

            for (int i = 0; i < this.Field.GetLength(0); i++)
            {
                for (int j = 0; j < this.Field.GetLength(0); j++)
                {
                    if (this.Field[i, j] == 0)
                    {
                        this.currentTargetCellIndex = 0;
                        result.X = i;
                        result.Y = j;
                        return result;
                    }
                }
            }

            return null;
        }

        private Cell Move(Cell cell)
        {
            for (int i = this.currentTargetCellIndex; i < this.targetCells.Length + this.currentTargetCellIndex; i++)
            {
                Cell nextCell = cell + this.targetCells[i % this.targetCells.Length];
                if (this.IsValidDestination(nextCell))
                {
                    this.currentTargetCellIndex = i % this.targetCells.Length;
                    return nextCell;
                }
            }

            return null;
        }

        private bool IsValidDestination(Cell cellToCheck)
        {
            return cellToCheck.X >= 0 && cellToCheck.X < this.Field.GetLength(0) && cellToCheck.Y >= 0
                   && cellToCheck.Y < this.Field.GetLength(0) && this.Field[cellToCheck.X, cellToCheck.Y] == 0;
        }

        private void FillMatrix()
        {
            var currentCell = new Cell(0, 0);
            var currentCellValue = 1;

            while (currentCell != null)
            {
                this.Field[currentCell.X, currentCell.Y] = currentCellValue;

                // The ?? operator is called the null-coalescing operator. 
                // It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
                currentCell = this.Move(currentCell) ?? this.FindFirstEmptyCell();

                currentCellValue++;
            }
        }
    }
}