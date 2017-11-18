using System;
using System.Drawing;

namespace MatrixSquare
{
    public class MatrixSymmetrical<T> : MatrixSquare<T>
    {
        #region ctor
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="size">size of square matrix</param>
        public MatrixSymmetrical(int size) : base(size, (size*size + size)/2)
        {
        }
        #endregion

        #region public
        /// <summary>
        /// Indexer. Return the element of the symmetrical matrix.
        /// </summary>
        /// <param name="i">The row number in the matrix.</param>
        /// <param name="j">The column number in the matrix.</param>
        /// <returns>Element of the matrix</returns>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Size)
                    throw new ArgumentOutOfRangeException();

                if (j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();

                if (i > j)
                {
                    var k = i;
                    i = j;
                    j = k;
                }
                return arrayMatrix[i * Size + j - Sum(i)];
            }
            set
            {
                if (i < 0 || i >= Size)
                    throw new ArgumentOutOfRangeException();

                if (j < 0 || j >= Size)
                    throw new ArgumentOutOfRangeException();

                if (i > j)
                {
                    var k = i;
                    i = j;
                    j = k;
                }

                if (!arrayMatrix[i * Size + j - Sum(i)].Equals(value))
                {
                    var oldVAlue = arrayMatrix[i * Size + j - Sum(i)];
                    arrayMatrix[i * Size + j - Sum(i)] = value;
                    OnChangeIndex(new ChangeIndexEventArgs<T>(i, j, oldVAlue));
                }
            }
        }
        #endregion

        #region private
        
        private int Sum(int i)
        {
            var sum = 0;
            for (var j = 0; j <= i; j++)
            {
                sum += j;
            }
            return sum;
        }
#endregion
    }
}
}