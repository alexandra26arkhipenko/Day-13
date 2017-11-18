namespace MatrixSquare
{
    public class MatrixSymmetrical<T> : MatrixSquare<T>
    {
        private readonly int _size;
        private readonly T[] _array;
        public MatrixSymmetrical(int size) : base(size)
        {
            _array = new T[(size*size + size)/2];
        }
        public override T this[int indexI, int indexJ]
        {
            set
            {
                if (indexJ < indexI)
                {
                    var k = indexJ;
                    indexJ = indexI;
                    indexI = k;
                }
                    _array[indexI*_size +indexJ -Sum(indexI)] = value;
                    OnChangeIndex(new ChangeIndexEventArgs(indexI, indexJ));
            }
            get
            {

                if (indexJ < indexI)
                {
                    var k = indexJ;
                    indexJ = indexI;
                    indexI = k;
                }
                return _array[indexI * _size + indexJ - Sum(indexI)];
            }
        }
        private static int Sum(int index)
        {
            var sum = 0;
            for (int i = 0; i <= index; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}