using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4963try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                string[] sizeString = Console.ReadLine().Split(' ');
                if (sizeString[0][0] == '0' && sizeString[1][0] == '0') break;

                int width = int.Parse(sizeString[0]);
                int height = int.Parse(sizeString[1]);
                bool[,] map = new bool[width, height]; // true == 땅, map[x, y]

                int islandCount = 0;

                for (int y = 0; y < height; ++y)
                {
                    string singleLine = Console.ReadLine();

                    for (int x = 0; x < width; ++x)
                    {
                        map[x, y] = singleLine[(x << 1)] == '1';
                    }
                }

                for (int x = 0; x < width; ++x)
                {
                    for (int y = 0; y < height; ++y)
                    {
                        // 지도의 땅 부분을 바다로 만듭니다. 인접한 땅이 있다면 그 땅도 바다로 만들어버립니다.
                        if (map[x, y] == true)
                        {
                            islandCount++;
                            (int nextX, int nextY)[] queueData = new (int, int)[2500];

                            queueData[0] = (x, y);
                            map[x, y] = false;

                            for (int queueHead = 1, queueRear = 0; queueRear < queueHead; ++queueRear)
                            {
                                (int x, int y) one = queueData[queueRear];

                                for (int dx = -1; dx < 2; ++dx)
                                {
                                    int xIndex = one.x + dx;
                                    if (xIndex >= width || xIndex < 0) continue;

                                    for (int dy = -1; dy < 2; ++dy)
                                    {
                                        int yIndex = one.y + dy;
                                        if (yIndex >= height || yIndex < 0) continue;

                                        if (map[xIndex, yIndex] == true)
                                        {
                                            queueData[queueHead] = (xIndex, yIndex);
                                            ++queueHead;
                                            map[xIndex, yIndex] = false;
                                        }

                                    }
                                }
                            }




                        }
                    }
                }

                result.AppendLine(islandCount.ToString());
            }

            Console.Write(result);
        }
    }
}
