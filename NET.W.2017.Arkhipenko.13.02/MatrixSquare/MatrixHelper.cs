using System;

namespace MatrixSquare
{
    public static class MatrixHelper
    {
        /// <summary>
        /// Expansion method for the sum of two matrices.
        /// </summary>
        /// <typeparam name="T">Type of number in matrix</typeparam>
        /// <param name="matrix">Matrix to which add.</param>
        /// <param name="addMatrix">The matrix that is added.</param>
        /// <returns>The sum of two matrices </returns>
        public static MatrixSquare<T> Sum<T>(this MatrixSquare<T> matrix, MatrixSquare<T> addMatrix)
        {
            if (matrix.Size != addMatrix.Size)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (var i = 0; i < matrix.Size; i++)
            {
                for (var j = 0; j < matrix.Size; j++)
                {
                    dynamic a = matrix[i, j];
                    dynamic b = addMatrix[i, j];
                    matrix[i, j] = a + b;
                }
            }

            return matrix;
        }
    }
}