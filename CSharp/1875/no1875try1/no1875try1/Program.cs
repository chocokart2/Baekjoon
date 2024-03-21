using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1875try1
{
    internal class Program
    {
        class Tiles
        {
            public Block[] blocks;
            public int length;

        }
        class Block
        {
            public int start; // 빈 공간의 블럭의 갯수
            public int size; // 연속하는 블럭의 두께
        }
        // T자 타일은 {1, 1}, {0, 2}, {1, 1}으로 표현할 수 있습니다.
        // 90도로 시계방향으로 회전한 경우, {1, 1}, {0, 3}으로 표현이 가능합니다.
        // Situation이 {2, 0, 7}이고, 첫째, 둘째 칸에 위치한 경우, 그 인덱스의 값인 {2, 0}을 추출할 수 있습니다.
        // 그러면 위치 지점은 각각 위치의 start를 제거하면 {1, 0}이 되며, 그 각 값의 최대값인 1을 뽑아냅니다.
        // 그렇다면 그 이후의 Situation 값은 {1(position) + 1(start) + 1(size), 1(position) + 0(start) + 3(size), 7}이 됩니다.

        // 기준은 왼쪽부터 시작해서 오른쪽 방향으로
        static Block[][][] tiles = new Block[7][][] // [블럭][방향][각 세로 칸] 상황에 따라 크기가 다르므로, 가변 배열을 사용한다.
        {
            // 1번
            new Block[1][] {
                new Block[1] {
                    new Block { start = 0, size = 4 }
                }
            },
            // 2번
            new Block[4][] {
                new Block[2] {
                    new Block { start = 0, size = 3 },
                    new Block { start = 2, size = 1 }
                },
                new Block[3] {
                    new Block { start = 1, size = 1 },
                    new Block { start = 1, size = 1 },
                    new Block { start = 0, size = 2 }
                },
                new Block[2] {
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 3 }
                },
                new Block[3] {
                    new Block { start = 0, size = 2 },
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 1 }
                },
            },
            // 3번
            new Block[4][] {
                new Block[2] {
                    new Block { start = 2, size = 1 },
                    new Block { start = 0, size = 3 }
                },
                new Block[3] {
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 2 }
                },
                new Block[2] {
                    new Block { start = 0, size = 3 },
                    new Block { start = 0, size = 1 }
                },
                new Block[3] {
                    new Block { start = 0, size = 2 },
                    new Block { start = 1, size = 1 },
                    new Block { start = 1, size = 1 }
                }
            },
            // 4번
            new Block[4][] {
                new Block[3] {
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 2 },
                    new Block { start = 0, size = 1 }
                },
                new Block[2] {
                    new Block { start = 0, size = 3 },
                    new Block { start = 1, size = 1 }
                },
                new Block[3] {
                    new Block { start = 1, size = 1 },
                    new Block { start = 0, size = 2 },
                    new Block { start = 1, size = 1 }
                },
                new Block[2] {
                    new Block { start = 1, size = 1 },
                    new Block { start = 0, size = 3 }
                }
            },
            // 5번
            new Block[2][] {
                new Block[3] {
                    new Block { start = 0, size = 1 },
                    new Block { start = 0, size = 2 },
                    new Block { start = 1, size = 1 }
                },
                new Block[2] {
                    new Block { start = 1, size = 2 },
                    new Block { start = 0, size = 2 }
                }
            },
            // 6번
            new Block[2][] {
                new Block[3] {
                    new Block { start = 1, size = 1 },
                    new Block { start = 0, size = 2 },
                    new Block { start = 0, size = 1 }
                },
                new Block[2] {
                    new Block { start = 0, size = 2 },
                    new Block { start = 1, size = 2 }
                }
            },
            new Block[1][] {
                new Block[2] {
                    new Block { start = 0, size = 2 },
                    new Block { start = 0, size = 2 }
                }
            },
        };

        static int[] spin = { 1, 4, 4, 4, 2, 2, 1 };
        static int[][] width = new int[7][]
        {
            new int[] { 1 },
            new int[] { 2, 3, 2, 3 },
            new int[] { 2, 3, 2, 3 },
            new int[] { 3, 2, 3, 2 },
            new int[] { 3, 2 },
            new int[] { 3, 2 },
            new int[] { 2 }
        };

        class Situation
        {
            public int[] highestBlocks;
            public int Height
            {
                get => Math.Max(Math.Max(highestBlocks[0], highestBlocks[1]), highestBlocks[2]);
            }

            public Situation()
            {
                highestBlocks = new int[3];
            }
        }

        static void Main(string[] args)
        {
            // 1. 위치(3개)
            // 2. 각도(4개)
            // 상황 : 각 3칸의 가장 높은 블록의 위치

            // DP
            Situation[,] situations = new Situation[4, 3]; // [회전 상황, 가장 왼쪽의 위치]
            situations[0, 0] = new Situation() { highestBlocks = new int[3] { 0, 0, 0 } };
            // 높이

            for (int count = int.Parse(Console.ReadLine()); count > 0; --count)
            {
                // DP
                Situation[,] next = new Situation[4, 3];
                int tileNumber = Console.ReadLine()[0] - '1';

                for (int spinIndex = 0; spinIndex < spin[tileNumber]; spinIndex++)
                {
                    for (int position = 0; position <= 3 - width[tileNumber][spinIndex]; ++position)
                    {
                        //Console.WriteLine($">> spin = {spinIndex} (너비 = {width[tileNumber][spinIndex]}), position = {position}");

                        // 각 상황의 situations에서 가져와서 next[spinIndex, position] 값을 설정함



                        for (int prevSpinIndex = 0; prevSpinIndex < 4; prevSpinIndex++)
                        {
                            for (int prevPosIndex = 0; prevPosIndex < 3; prevPosIndex++)
                            {
                                if (situations[prevSpinIndex, prevPosIndex] == null) continue;

                                Situation one = new Situation()
                                {
                                    highestBlocks = new int[3]
                                    {
                                        situations[prevSpinIndex, prevPosIndex].highestBlocks[0],
                                        situations[prevSpinIndex, prevPosIndex].highestBlocks[1],
                                        situations[prevSpinIndex, prevPosIndex].highestBlocks[2]
                                    }
                                };

                                int yPosition = 0;
                                for (int index = 0; index < width[tileNumber][spinIndex]; ++index)
                                {
                                    yPosition = Math.Max(yPosition, one.highestBlocks[position + index] - tiles[tileNumber][spinIndex][index].start);
                                }
                                for (int index = 0; index < width[tileNumber][spinIndex]; ++index)
                                {
                                    one.highestBlocks[position + index] =
                                        yPosition
                                        + tiles[tileNumber][spinIndex][index].start
                                        + tiles[tileNumber][spinIndex][index].size;
                                }

                                if (next[spinIndex, position] == null)
                                {
                                    //Console.WriteLine("!!");
                                    next[spinIndex, position] = one;
                                    continue;
                                }
                                if (next[spinIndex, position].Height > one.Height)
                                {
                                    //Console.WriteLine("!!");

                                    next[spinIndex, position] = one;
                                    continue;
                                }
                            }
                        }
                    }
                }

                situations = next;
            }

            int result = int.MaxValue;
            for (int spinIndex = 0; spinIndex < 4; spinIndex++)
            {
                for (int potisionIndex = 0; potisionIndex < 3; potisionIndex++)
                {
                    if (situations[spinIndex, potisionIndex] == null) continue;
                    //Console.WriteLine($">> situations[{spinIndex}, {potisionIndex}].Height = {situations[spinIndex, potisionIndex].Height}");

                    result = Math.Min(result, situations[spinIndex, potisionIndex].Height);
                }
            }
            Console.WriteLine(result);
        }
    }
}
