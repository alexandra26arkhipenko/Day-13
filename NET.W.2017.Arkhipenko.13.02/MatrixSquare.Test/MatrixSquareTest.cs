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
            MatrixSquare<int> matrixSquare = new MatrixSquare<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixSquare[i, j] = i * 1 + j;
                    
                }
            }

            log = false;
            matrixSquare.ChangeIndex += Reaction;
            matrixSquare[0, 0] = 125;
            Assert.IsTrue(log);
        }
        private bool log;

        private void Reaction(object sender, ChangeIndexEventArgs e)
        {
            log = true;
        }
        [TestMethod]
        public void MatrixSqureDiagonalTest()
        {
            MatrixSquareDiagonal<int> matrixSquareDiagonal = new MatrixSquareDiagonal<int>(3);

            log = false;
            matrixSquareDiagonal.ChangeIndex += Reaction;
            matrixSquareDiagonal[0, 0] = 125;
            Assert.IsTrue(log);
        }


    }
}
