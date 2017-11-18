using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixSquare;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {

            MatrixSquare<int> matrixSquare = new MatrixSquare<int>(4);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixSquare[i, j] = i * 3 + j;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                   Console.Write(matrixSquare[i, j] + " ");
                }
                Console.WriteLine();
            }

            matrixSquare.ChangeIndex += Reaction;
            matrixSquare[0, 0] = 125;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrixSquare[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            MatrixSquareDiagonal<int> matrixSquareDiagonal = new MatrixSquareDiagonal<int>(3)
            {
                [0, 0] = 1,
                [1, 1] = 2,
                [2, 2] = 3
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrixSquareDiagonal[i, j] + " ");
                }
                Console.WriteLine();
            }
            matrixSquareDiagonal.ChangeIndex += Reaction;
            matrixSquareDiagonal[0, 0] = 125;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrixSquareDiagonal[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            MatrixSymmetrical<int> matrixSquares = new MatrixSymmetrical<int>(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrixSquares[i, j] = i * 3 + j;
                }
            }

          
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrixSquares[i, j] + " ");
                }
                Console.WriteLine();
            }
            matrixSquareDiagonal.ChangeIndex += Reaction;
            matrixSquareDiagonal[0, 0] = 125;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrixSquares[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        private static void Reaction(object sender, ChangeIndexEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
