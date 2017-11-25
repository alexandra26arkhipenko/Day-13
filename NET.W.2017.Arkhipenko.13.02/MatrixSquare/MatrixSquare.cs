using System;

namespace MatrixSquare
{
    public class MatrixSquare<T>
    {
        #region public

        /// <summary>
        ///     Indexer. Return the element of the diagonal matrix.
        /// </summary>
        /// <param name="i">The row number in the matrix.</param>
        /// <param name="j">The column number in the matrix.</param>
        /// <returns>Element of the matrix</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size)
                    throw new ArgumentOutOfRangeException();

                if (j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();
                return arrayMatrix[Size * i + j];
            }

            set
            {
                if (i < 0 || i >= Size)
                    throw new ArgumentOutOfRangeException();

                if (j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();
                if (!arrayMatrix[Size * i + j].Equals(value))
                {
                    var oldValue = arrayMatrix[Size * i + j];
                    arrayMatrix[Size * i + j] = value;
                    OnChangeIndex(new ChangeIndexEventArgs<T>(i, j, arrayMatrix[Size * i + j]));
                }
            }
        }

        #endregion

        #region field

        public int Size { get; }
        private readonly T[] arrayMatrix;

        #endregion

        #region ctor

        /// <summary>
        ///     Protected ctor
        /// </summary>
        /// <param name="matrixSize">The size of square matrix</param>
        /// <param name="arraySize">The size of the array representing the matrix.</param>
        public MatrixSquare(int matrixSize, int arraySize)
        {
            if (matrixSize <= 0)
                throw new ArgumentOutOfRangeException();
            if (arraySize <= 0)
                throw new ArgumentOutOfRangeException();
            arrayMatrix = new T[arraySize];
            Size = matrixSize;
        }

        public MatrixSquare(int size) : this(size, size * size)
        {
        }

        #endregion

        #region Event

        /// <summary>
        ///     Publish event
        /// </summary>
        public event EventHandler<ChangeIndexEventArgs<T>> ChangeIndex;

        /// <summary>
        ///     Event processing
        /// </summary>
        /// <param name="e">Event parameters.</param>
        protected virtual void OnChangeIndex(ChangeIndexEventArgs<T> e)
        {
            ChangeIndex?.Invoke(this, e);
        }

        #endregion
    }
}