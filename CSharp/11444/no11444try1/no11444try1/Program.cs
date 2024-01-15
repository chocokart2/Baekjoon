using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11444try1
{
    internal class Program
    {
        const ulong REMAINDER = 1_000_000_007;

        class Matrix2
        {
            public ulong[,] data; // data[x, y]
            public long SizeX { private set; get; }
            public long SizeY { private set; get; } // 7.3은 init 못쓰네, 9.0 쓰는 사람들은 좋겠다.

            public Matrix2() { }
            
            public void Set(ulong[,] setData)
            {
                data = setData;
                SizeX = data.GetLongLength(0);
                SizeY = data.GetLongLength(1);
            }
            static public Matrix2 Multiply(Matrix2 left, Matrix2 right)
            {
                if (left.SizeX != right.SizeY) return null;
                Matrix2 result = new Matrix2()
                {
                    data = new ulong[right.SizeX, left.SizeY],
                    SizeX = right.SizeX,
                    SizeY = left.SizeY
                };

                for (int x = 0; x < right.SizeX; x++)
                {
                    for (int y = 0; y < left.SizeY; ++y)
                    {
                        for (int i = 0; i < right.SizeY; ++i) // right.Y인덱스이자 left.x인덱스이다.
                        {
                            result.data[x, y] += (right.data[x, i] * left.data[i, y]) % REMAINDER;
                        }
                        result.data[x, y] %= REMAINDER;
                    }
                }

                return result;
            }
            static public Matrix2 GetPower(Matrix2 squareMatrix, ulong exponent) // exponent = n
            {
                if (squareMatrix.data.GetLength(0) != squareMatrix.data.GetLength(1)) return null;
                return mPower(squareMatrix, exponent);
            }
            static private Matrix2 mPower(Matrix2 squareMatrix, ulong exponent)
            {
                if (exponent == 1) return squareMatrix;
                Matrix2 half = mPower(squareMatrix, exponent >> 1);
                if ((exponent & 1) == 1)
                {
                    return Multiply(Multiply(half, half), squareMatrix);
                }
                return Multiply(half, half);
            }
        }



        static void Main(string[] args)
        {
            Matrix2 startMatrix = new Matrix2();
            startMatrix.Set(new ulong[2, 2]
                {
                    { 1, 1 },
                    { 1, 0 }
                }
                );

            ulong n = ulong.Parse(Console.ReadLine());

            Console.WriteLine(Matrix2.GetPower(startMatrix, n).data[1, 0]);
            


        }
    }
}
