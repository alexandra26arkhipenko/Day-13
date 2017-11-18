using System;
using System.ComponentModel;

namespace MatrixSquare
{
    public class MatrixSquareDiagonal<T> : MatrixSquare<T>
    {
        private int size;
        private readonly T[] array;
        public MatrixSquareDiagonal(int size) : base(size)
        {
            array = new T[size];
            
        }

        public override T this[int indexI, int indexJ]
        {
            set
            {
                if (indexJ == indexI)
                {
                    array[indexI] = value;
                    OnChangeIndex(new ChangeIndexEventArgs(indexI, indexJ));
                }
               
            }
            get
            {
                if (indexJ == indexI)
                    return array[indexI];
                return default(T);
            }
        }

    }
}