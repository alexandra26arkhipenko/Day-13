using System;
using System.Diagnostics.Tracing;

namespace MatrixSquare
{
    public class MatrixSquare<T>
    {
        private readonly int size;
        private readonly T[] arrayHelper;
       

        public MatrixSquare(int size)
        {
            this.size = size;
            arrayHelper = new T[size*size];
        }
        
        public virtual T this[int indexI, int indexJ]
        {
            set
            { 
                arrayHelper[indexI * size + indexJ] = value;
                OnChangeIndex(new ChangeIndexEventArgs(indexI, indexJ));
            }
            get => arrayHelper[indexI * size + indexJ];
        }

        public EventHandler<ChangeIndexEventArgs> ChangeIndex = delegate{};
        
        public virtual void OnChangeIndex(ChangeIndexEventArgs e)
        {
            ChangeIndex?.Invoke(this, e);
        }

    }
}
