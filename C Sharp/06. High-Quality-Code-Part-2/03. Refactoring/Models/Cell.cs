﻿using System;

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
            return new Cell(currentCell.X + nextCell.X, currentCell.Y + nextCell.Y);
        }
    }
}