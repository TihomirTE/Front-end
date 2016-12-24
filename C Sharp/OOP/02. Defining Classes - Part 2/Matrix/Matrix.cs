
namespace Matrix
{
    using System;

    class Matrix<T> where T : IComparable<T>
    {
        // field for matrix
        private T[,] matrix;

        // constructor of matrix
        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
        }    

        // get the rows
        public int Rows
        {
            get { return this.matrix.GetLength(0); }
        }

        // get the columns
        public int Cols
        {
            get { return this.matrix.GetLength(1); }
        }

        /// <summary>
        /// Property for indexer (access the inner matrix cells)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows ||
                    col < 0 || col >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Rows ||
                   col < 0 || col >= Cols)
                {
                    throw new IndexOutOfRangeException();
                }
                this.matrix[row, col] = value;
            }
        }

        /// <summary>
        /// Add two matrices
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns> New matrix from addition of firstMatrix and secondMatrix</returns>
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) == secondMatrix.matrix.GetLength(0) &&
                firstMatrix.matrix.GetLength(1) == secondMatrix.matrix.GetLength(1))
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0),
                                                        firstMatrix.matrix.GetLength(1));
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Cols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("The two matrixes must have equal rows and columns");
            }
        }

        /// <summary>
        /// Subtract two matrices
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns> New matrix from subtraction  of firstMatrix and secondMatrix </returns>
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) == secondMatrix.matrix.GetLength(0) &&
                firstMatrix.matrix.GetLength(1) == secondMatrix.matrix.GetLength(1))
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0),
                                                        firstMatrix.matrix.GetLength(1));
                for (int row = 0; row < firstMatrix.Rows; row++)
                {
                    for (int col = 0; col < firstMatrix.Cols; col++)
                    {
                        resultMatrix[row, col] = (dynamic)firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                    }
                }
                return resultMatrix;
            }
            else
            {
                throw new ArgumentException("The two matrixes must have equal rows and columns");
            }
        }
        /// <summary>
        /// Multiply two matrices
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            // check the dimensions of the two matrices
            if (firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(1))
            {
                throw new ArgumentException("matrices with different dimensions can not multiply");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0), secondMatrix.matrix.GetLength(1));
                for (int rowResult = 0; rowResult < resultMatrix.matrix.GetLength(0); rowResult++)
                {
                    for (int colResult = 0; colResult < resultMatrix.matrix.GetLength(1); colResult++)
                    {
                        for (int colFirst = 0; colFirst < firstMatrix.matrix.GetLength(1); colFirst++)
                        {
                            resultMatrix[rowResult, colResult] += (dynamic)firstMatrix[rowResult, colFirst] * (dynamic)secondMatrix[colFirst, colResult];
                        }
                    }
                }
                return resultMatrix;
            }
        }

        // check for non-zero elements in matrix
        public static bool operator true(Matrix<T> matrix)
        {
            bool isNonZero = false;

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        isNonZero = true;
                    }
                }
            }
            return isNonZero;
        }

        // operator "true" has to be compared with opeartor "true"
        public static bool operator false(Matrix<T> matrix)
        {
            bool isNonZero = false;

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        isNonZero = true;
                    }
                }
            }
            return isNonZero;
        }

    }
}
