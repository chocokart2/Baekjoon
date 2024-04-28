using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace no7569try1
{
    internal class Program
    {
        const int GREEN = -10;
        const int WALL = -20;

        class Index
        {
            public int x;
            public int y;
            public int z;

            public Index() { }
            public Index(int ix, int iy, int iz) { x = ix; y = iy; z = iz; }
            public static Index operator+(Index left, Index right)
                => new Index(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        static bool IsMiddleIndex(int input, int size) => (input > -1) && (input < size);

        static void Main(string[] args)
        {
            string[] sizeString = Console.ReadLine().Split(' ');
            int xSize = int.Parse(sizeString[0]);
            int ySize = int.Parse(sizeString[1]);
            int zSize = int.Parse(sizeString[2]);

            int[,,] box = new int[xSize, ySize, zSize];
            int remainGreenTomato = 0;
            int answer = 0;

            Index[] queue = new Index[xSize * ySize * zSize];
            int queueHead = 0;
            int queueRear = 0;

            Index[] delta = new Index[6]
            {
                new Index(1, 0, 0),
                new Index(0, 1, 0),
                new Index(0, 0, 1),
                new Index(-1, 0, 0),
                new Index(0, -1, 0),
                new Index(0, 0, -1),
            };

            // input
            for (int z = 0; z < zSize; ++z)
            {
                for (int y = 0; y < ySize; ++y)
                {
                    string[] oneLine = Console.ReadLine().Split(' ');
                    for (int x = 0; x < xSize; ++x)
                    {
                        switch (oneLine[x])
                        {
                            case "0":
                                box[x, y, z] = GREEN;
                                remainGreenTomato++;
                                break;
                            case "1":
                                box[x, y, z] = 0;
                                queue[queueHead] = new Index(x, y, z);
                                queueHead++;
                                break;
                            case "-1":
                                box[x, y, z] = WALL;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            while (queueRear < queueHead)
            {
                Index one = queue[queueRear];
                queueRear++;

                for (int deltaIndex = 0; deltaIndex < delta.Length; ++deltaIndex)
                {
                    Index next = one + delta[deltaIndex];
                    if (IsMiddleIndex(next.x, xSize) == false) continue;
                    if (IsMiddleIndex(next.y, ySize) == false) continue;
                    if (IsMiddleIndex(next.z, zSize) == false) continue;
                    if (box[next.x, next.y, next.z] != GREEN) continue;

                    box[next.x, next.y, next.z] = box[one.x, one.y, one.z] + 1;
                    answer = Math.Max(answer, box[next.x, next.y, next.z]);
                    remainGreenTomato--;
                    queue[queueHead] = next;
                    queueHead++;
                }
            }

            Console.WriteLine((remainGreenTomato != 0) ? "-1" : answer.ToString());
        }
    }
}
