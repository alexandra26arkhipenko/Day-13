using System;

namespace MatrixSquare
{
    public class ChangeIndexEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The indices of the changed element and its old value.
        /// </summary>
        public int IndexI { get; }
        public int IndexJ { get; }
        public T OldValue { get; }

        public ChangeIndexEventArgs(int i, int j, T oldValue)
        {
            IndexI = i;
            IndexJ = j;
            OldValue = oldValue;
        }
    }
}