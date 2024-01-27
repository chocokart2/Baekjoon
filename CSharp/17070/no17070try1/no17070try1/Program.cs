using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17070try1
{
    internal class Program
    {
        class SetQueue
        {
            public int Count { get => positionQueue.Count; }

            Queue<(int x, int y)> positionQueue;
            HashSet<(int x, int y)> registeredElement;

            public SetQueue()
            {
                positionQueue = new Queue<(int x, int y)>();
                registeredElement = new HashSet<(int x, int y)>();
            }

            public bool Add((int x, int y) item)
            {
                if (registeredElement.Contains(item)) return false;
                positionQueue.Enqueue(item);
                registeredElement.Add(item);
                return true;
            }
            public (int x, int y) Out()
            {
                (int x, int y) one = positionQueue.Dequeue();
                registeredElement.Remove(one);
                return one;
            }
        }


        static void Main(string[] args)
        {
            int sizeN = int.Parse(Console.ReadLine());

            SetQueue nextPosition = new SetQueue();
            bool[,] isWall = new bool[sizeN, sizeN];
            ulong[,] caseCountRightDirection = new ulong[sizeN, sizeN];
            ulong[,] caseCountDiagonalDirection = new ulong[sizeN, sizeN];
            ulong[,] caseCountDownDirection = new ulong[sizeN, sizeN];

            // 지도 init
            for (int y = 0; y < sizeN; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; (x << 1) < recvLine.Length; ++x)
                {
                    isWall[x, y] = recvLine[(x << 1)] == '1';
                }
            }

            caseCountRightDirection[1, 0] = 1;
            nextPosition.Add((1, 0));

            while (nextPosition.Count > 0)
            {
                (int x, int y) = nextPosition.Out();

                bool isInsideX = (x + 1) < sizeN;
                bool isInsideY = (y + 1) < sizeN;

                ulong toRight = caseCountRightDirection[x, y] +
                            caseCountDiagonalDirection[x, y];
                ulong toDiagonal = caseCountRightDirection[x, y] +
                            caseCountDiagonalDirection[x, y] +
                            caseCountDownDirection[x, y];
                ulong toDown = caseCountDiagonalDirection[x, y] +
                        caseCountDownDirection[x, y];

                if (x != sizeN - 1 || y != sizeN - 1)
                {
                    caseCountRightDirection[x, y] = 0;
                    caseCountDiagonalDirection[x, y] = 0;
                    caseCountDownDirection[x, y] = 0;
                }


                if (isInsideX && (toRight > 0))
                {
                    if (isWall[x + 1, y] == false)
                    {
                        caseCountRightDirection[x + 1, y] += toRight;
                        nextPosition.Add((x + 1, y));
                    }
                }
                if (isInsideY && (toDown > 0))
                {
                    if (isWall[x, y + 1] == false)
                    {
                        caseCountDownDirection[x, y + 1] += toDown;
                        nextPosition.Add((x, y + 1));
                    }
                }
                if (isInsideX && isInsideY && (toDiagonal > 0))
                {
                    if (!(isWall[x + 1, y] || isWall[x, y + 1] || isWall[x + 1, y + 1]))
                    {
                        caseCountDiagonalDirection[x + 1, y + 1] += toDiagonal;
                        nextPosition.Add((x + 1, y + 1));
                    }
                }

            }

            ulong result = caseCountRightDirection[sizeN - 1, sizeN - 1] +
                caseCountDiagonalDirection[sizeN - 1, sizeN - 1] +
                caseCountDownDirection[sizeN - 1, sizeN - 1];
            Console.WriteLine(result);
        }
    }
}
