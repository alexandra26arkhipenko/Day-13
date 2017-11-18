using System;

namespace MatrixSquare
{
    public class ChangeIndexEventArgs : EventArgs
    {
        public int IIndex { get; }
        public int JIndex { get; }
        public string Message { get; }
      

        public ChangeIndexEventArgs(int iIndex, int jIndex)
        {
            IIndex = iIndex;
            JIndex = jIndex;
            Message = String.Format("Element [ {0}, {1} ] was changed", iIndex, jIndex);
        }
    }
}