using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen.Models
{
    public class Matrix
    {
        private int rows;
        private int cols;

        public Matrix(int size)
        {
            this.Rows = size;
            this.Cols = size;
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                this.cols = value;
            }
        }


    }
}
