using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14503try1
{
    internal class Program
    {
        enum EDirection
        {
            north = 0,
            east = 1,
            south = 2,
            west = 3,
        }
        enum EBlock
        {
            dirty = 0,
            wall = 1,
            cleaned = 2
        }

        static EDirection botDirection;
        static int xPos;
        static int yPos;
        static EBlock[,] map;
        static int xSize;
        static int ySize;

        static (int x, int y) GetMove(int coefficient) // 전진은 +1, 후진은 -1
        {
            int dx = 0;
            int dy = 0;

            switch (botDirection)
            {
                case EDirection.north:
                    dy = -1;
                    break;
                case EDirection.east:
                    dx = 1;
                    break;
                case EDirection.south:
                    dy = 1;
                    break;
                case EDirection.west:
                    dx = -1;
                    break;
                default:
                    break;
            }

            dx *= coefficient;
            dy *= coefficient;

            return (xPos + dx, yPos + dy);
        }
        static void Turn()
        {
            switch (botDirection)
            {
                case EDirection.north:
                    botDirection = EDirection.west;
                    break;
                case EDirection.east:
                    botDirection = EDirection.north;
                    break;
                case EDirection.south:
                    botDirection = EDirection.east;
                    break;
                case EDirection.west:
                    botDirection = EDirection.south;
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int result = 0; // 청소를 할 때마다 1씩 늘어납니다.
            string[] recvLineNM = Console.ReadLine().Split(' ');
            ySize = int.Parse(recvLineNM[0]);
            xSize = int.Parse(recvLineNM[1]);
            map = new EBlock[xSize, ySize];

            string[] recvLineRCD = Console.ReadLine().Split(' ');
            xPos = int.Parse(recvLineRCD[1]);
            yPos = int.Parse(recvLineRCD[0]);
            botDirection = (EDirection)int.Parse(recvLineRCD[2]);

            // 지도 초기화
            for (int yIndex = 0; yIndex < ySize; ++yIndex)
            {
                // length = xSize * 2 - 1
                string recvLine = Console.ReadLine();
                for (int xIndex = 0; xIndex < xSize; ++xIndex)
                {
                    map[xIndex, yIndex] = (EBlock)(recvLine[xIndex * 2] - '0');
                }
            }

            // whileLoop 돌면서 해당 조건에 도달하면 행동 및 종료
            do
            {

                if (map[xPos, yPos] == EBlock.dirty)
                {
                    result++;
                    map[xPos, yPos] = EBlock.cleaned;
                }

                // 블럭의 끝의 경계가 벽이라는 것이 보장되므로, 주변의 블럭이 범위 밖으로 나가 IndexOutOfRangeException로부터 안전합니다.
                bool isNearDirtyBlockExist =
                    (map[xPos + 1, yPos] == EBlock.dirty) ||
                    (map[xPos - 1, yPos] == EBlock.dirty) ||
                    (map[xPos, yPos + 1] == EBlock.dirty) ||
                    (map[xPos, yPos - 1] == EBlock.dirty);
                if (isNearDirtyBlockExist)
                {
                    Turn();
                    (int x, int y) nextPos = GetMove(1);
                    if (map[nextPos.x, nextPos.y] == EBlock.dirty)
                    {
                        // 전진
                        xPos = nextPos.x;
                        yPos = nextPos.y;
                    }
                    //continue;
                }
                else
                {
                    (int x, int y) movePos = GetMove(-1);
                    if (map[movePos.x, movePos.y] == EBlock.wall) break;
                    xPos = movePos.x;
                    yPos = movePos.y;
                    //continue;
                }

                //// 표현
                //StringBuilder printValue = new StringBuilder();
                //printValue.AppendLine($"현재 청소한 블럭 갯수 : {result}");
                //for (int line = 0; line < ySize; ++line)
                //{
                //    for (int xIndex = 0; xIndex < xSize; ++xIndex)
                //    {
                //        char one = '?';

                //        if (xPos != xIndex || yPos != line)
                //        {
                //            switch (map[xIndex, line])
                //            {
                //                case EBlock.dirty: one = '@'; break;
                //                case EBlock.wall: one = '#'; break;
                //                case EBlock.cleaned: one = '='; break;
                //                default: break;
                //            }
                //        }
                //        else
                //        {
                //            switch (botDirection)
                //            {
                //                case EDirection.north:
                //                    one = '^';
                //                    break;
                //                case EDirection.east:
                //                    one = '>';
                //                    break;
                //                case EDirection.south:
                //                    one = 'V';
                //                    break;
                //                case EDirection.west:
                //                    one = '<';
                //                    break;
                //                default:
                //                    break;
                //            }
                //        }

                //        printValue.Append($"{one} ");
                //    }
                //    printValue.Append('\n');
                //}
                //Console.WriteLine(printValue);
            }
            while (true);

            Console.WriteLine(result);
        }
    }
}
