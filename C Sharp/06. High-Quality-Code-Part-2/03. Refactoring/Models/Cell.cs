using System;

namespace GameFifteen.Models
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public static Cell operator +(Cell currentCell, Cell nextCell)
        {
            if (currentCell == null || nextCell == null)
            {
                throw new ArgumentNullException("Cells can not be null");
            }

            return new Cell(currentCell.X + nextCell.X, currentCell.Y + nextCell.Y);
        }
    }
}