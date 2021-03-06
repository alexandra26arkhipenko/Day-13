﻿using System;


namespace MatrixSquare
{
    public class MatrixSquareDiagonal<T> : MatrixSquare<T>
    {

        private readonly T[] _arrayMatrix;
        #region ctor
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="size">size of square matrix</param>
        public MatrixSquareDiagonal(int size) : base(size, size)
        {
            _arrayMatrix = new T[size];
        }
        #endregion

        #region public
        /// <summary>
        /// Indexer. Return the element of the diagonal matrix.
        /// </summary>
        /// <param name="i">The row number in the matrix.</param>
        /// <param name="j">The column number in the matrix.</param>
        /// <returns>Element of the matrix</returns>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (i == j)
                {
                    return _arrayMatrix[i];
                }

                return default(T);
            }
            set
            {
                if (i < 0 || i >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (j < 0 || j >= Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (i == j)
                {
                    if (!_arrayMatrix[i].Equals(value))
                    {
                        var oldVAlue = _arrayMatrix[i];
                        _arrayMatrix[i] = value;
                        OnChangeIndex(new ChangeIndexEventArgs<T>(i, j, oldVAlue));

                    }

                }
            }
        }
#endregion 

    }
}