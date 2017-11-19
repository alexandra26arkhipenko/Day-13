using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixSquare.Test
{
    [TestClass]
    public class MatrixSquareTest
    {
        [TestMethod]
        public void MatrixSqureClassicTest()
        {
            var matrixSquare = new MatrixSquare<int>(3);
            var mt = new MatrixSymmetrical<int>(3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 1] = 4,
                [1, 2] = 5,
                [2, 2] = 6
            };




            var mt1 = new MatrixSquareDiagonal<int>(3)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 1] = 4,
                [1, 2] = 5,
                [2, 2] = 6
            };




            _log = false;

            matrixSquare.ChangeIndex += Reaction;
            matrixSquare[0, 0] = 125;
            Assert.IsTrue(_log);
        }

        private bool _log;

        private void Reaction(object sender, ChangeIndexEventArgs<int> e)
        {
            _log = true;
        }
    }
}
