using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14500try1
{
    internal class Program
    {
        const bool O = true;
        const bool X = false;

        struct Block
        {
            public bool[,] square; // square[x, y]
            public int sizeX;
            public int sizeY;

            public Block(bool[,] data)
            {
                square = data;
                sizeX = data.GetLength(0);
                sizeY = data.GetLength(1);
            }
        }

        static void Main(string[] args)
        {
            int result = 0;
            string[] recvLineNM = Console.ReadLine().Split(' ');
            int n = int.Parse(recvLineNM[0]);
            int m = int.Parse(recvLineNM[1]);
            int[,] map = new int[m, n];
            for (int y = 0; y < n; ++y)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                for (int x = 0; x < recvLine.Length; ++x)
                {
                    map[x, y] = int.Parse(recvLine[x]);
                }
            }

            Block[] blocks = new Block[19]
            {
                new Block(
                    new bool[1, 4]
                    {
                        { O, O, O, O }
                    }
                    ),
                new Block(
                    new bool[4, 1]
                    {
                        { O },
                        { O },
                        { O },
                        { O }
                    }
                    ),
                new Block(
                    new bool[2, 2]
                    {
                        { O, O },
                        { O, O }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { O, X },
                        { O, X },
                        { O, O }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { O, O, O },
                        { O, X, X }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { O, O },
                        { X, O },
                        { X, O }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { X, X, O },
                        { O, O, O }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { X, O },
                        { X, O },
                        { O, O }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { O, X, X },
                        { O, O, O }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { O, O },
                        { O, X },
                        { O, X }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { O, O, O },
                        { X, X, O }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { O, X },
                        { O, O },
                        { X, O }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { X, O, O },
                        { O, O, X }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { X, O },
                        { O, O },
                        { O, X }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { O, O, X },
                        { X, O, O }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { O, O, O },
                        { X, O, X }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { O, X },
                        { O, O },
                        { O, X }
                    }
                    ),
                new Block(
                    new bool[2, 3]
                    {
                        { X, O, X },
                        { O, O, O }
                    }
                    ),
                new Block(
                    new bool[3, 2]
                    {
                        { X, O },
                        { O, O },
                        { X, O }
                    }
                    )
            };

            for (int blockIndex = 0; blockIndex < 19; ++blockIndex)
            {
                // pivotX과 pivotY는 테트로미노의 왼쪽 위 포지션입니다.
                for (int pivotX = 0; pivotX < m - blocks[blockIndex].sizeX + 1; ++pivotX)
                {
                    for (int pivotY = 0; pivotY < n - blocks[blockIndex].sizeY + 1; ++pivotY)
                    {
                        int oneSum = 0;
                        
                        for (int blockIndexX = 0; blockIndexX < blocks[blockIndex].sizeX; ++blockIndexX)
                        {
                            for (int blockIndexY = 0; blockIndexY < blocks[blockIndex].sizeY; ++blockIndexY)
                            {
                                if (blocks[blockIndex].square[blockIndexX, blockIndexY])
                                    oneSum += map[pivotX + blockIndexX, pivotY + blockIndexY];
                            }
                        }

                        if (result < oneSum) result = oneSum;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
