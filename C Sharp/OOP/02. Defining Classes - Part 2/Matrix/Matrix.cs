namespace Matrix
{
    using System;

    class Matrix<T> where T : IComparable
    {
        // field for matrix
        private readonly T[,] matrix;

        // constructor of matrix
        public Matrix(int rows, int cols)
        {
            matrix = new T[rows, cols];
        }    

        // get the rows
        public int Rows
        {
            get { return matrix.GetLength(0); }
        }

        // get the columns
        public int Cols
        {
            get { return matrix.GetLength(1); }
        }

        // Property for indexer (access the inner matrix cells)
        public T this[int row, int col]
        {
            get
            {
                if (row < 0 && row >= Rows &&
                    col < 0 && col >= Cols)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                else
                {
                    return matrix[row, col];
                }
            }
            set
            {
                if (row < 0 && row >= Rows &&
                   col < 0 && col >= Cols)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                else
                {
                    matrix[row, col] = value;
                }
            }
        }

        // Add two matrices
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows == secondMatrix.Rows &&
                firstMatrix.Cols == secondMatrix.Cols)
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows,
                                                        firstMatrix.Cols);
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

        // Subtract two matrices
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows == secondMatrix.Rows &&
                firstMatrix.Cols == secondMatrix.Cols)
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows,
                                                        firstMatrix.Cols);
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
        // Multiply two matrices
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            // check the dimensions of the two matrices
            if (firstMatrix.Cols != secondMatrix.Rows)
            {
                throw new ArgumentException("matrices with different dimensions can not multiply");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);
                for (int rowResult = 0; rowResult < resultMatrix.Rows; rowResult++)
                {
                    for (int colResult = 0; colResult < resultMatrix.Cols; colResult++)
                    {
                        for (int colFirst = 0; colFirst < firstMatrix.Cols; colFirst++)
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
