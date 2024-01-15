using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2029try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] map = new bool[7, 7];
            int a = 24;

            for (int y = 0; y < 10; ++y)
            {
                string recvLine = Console.ReadLine();

                for (int x = 0; x < 10; ++x)
                {
                    // 세로 성nyang을 구한다.
                    if ((x % 3 == 0) && (y % 3 == 1) && (recvLine[x] != '.'))
                    {
                        map[x / 3 * 2, y / 3 * 2 + 1] = true;
                        a--;
                    }
                    // 가로 성nyang을 구한다.
                    if ((x % 3 == 1) && (y % 3 == 0) && (recvLine[x] != '.'))
                    {
                        map[x / 3 * 2 + 1, y / 3 * 2] = true;
                        a--;
                    }
                }
            }

            int b = 0;
            for (int size = 2; size <= 6; size += 2)
            {
                for (int startY = 0, endY = startY + size; endY < 7; startY += 2, endY += 2)
                {
                    for (int startX = 0, endX = startX + size; endX < 7; startX += 2, endX += 2)
                    {
                        bool isConnected = true;
                        // 정사각형의 가로 체크
                        for (int indexX = startX + 1; indexX < endX; indexX += 2)
                        {
                            if (map[indexX, startY] == false)
                            {
                                isConnected = false; break;
                            }
                            if (map[indexX, endY] == false)
                            {
                                isConnected = false; break;
                            }
                        }
                        for (int indexY = startY + 1; indexY < endY; indexY += 2)
                        {
                            if (map[startX, indexY] == false)
                            {
                                isConnected = false; break;
                            }
                            if (map[endX, indexY] == false)
                            {
                                isConnected = false; break;
                            }
                        }

                        if (isConnected)
                        {
                            b++;
                        }
                    }
                }
            }

            Console.WriteLine($"{a} {b}");
        }
    }
}
