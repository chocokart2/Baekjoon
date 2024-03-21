using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1577try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int xSize = int.Parse(size[0]) + 1;
            int ySize = int.Parse(size[1]) + 1;
            ulong[,] dp = new ulong[xSize, ySize];
            dp[0, 0] = 1;
            bool[,] downBlocked = new bool[xSize, ySize]; // 기준은 출발점 기준
            bool[,] rightBlocked = new bool[xSize, ySize]; // 기준은 출발점 기준
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] one = Console.ReadLine().Split(' ');
                int x1 = int.Parse(one[0]);
                int y1 = int.Parse(one[1]);
                int x2 = int.Parse(one[2]);
                int y2 = int.Parse(one[3]);

                int oneX = (x1 <= x2) ? x1 : x2;
                int oneY = (y1 <= y2) ? y1 : y2;
                (x1 == x2 ? downBlocked : rightBlocked)[oneX, oneY] = true;
                //Console.WriteLine($">> [{oneX}, {oneY}] {(x1 == x2 ? "아랫쪽" : "오른쪽")} blocked");
            }
            for (int step = 0; step < xSize + ySize; ++step)
            {
                //Console.WriteLine($"step = {step}");
                for (int xPos = 0; xPos < xSize && xPos <= step; ++xPos)
                {
                    int yPos = step - xPos;

                    if (xPos >= xSize) continue;
                    if (yPos < 0 || yPos >= ySize) continue;
                    //Console.WriteLine($"[{xPos}, {yPos}]");

                    if ((!downBlocked[xPos, yPos]) && (yPos + 1 < ySize)) dp[xPos, yPos + 1] += dp[xPos, yPos];
                    if ((!rightBlocked[xPos, yPos]) && (xPos + 1 < xSize)) dp[xPos + 1, yPos] += dp[xPos, yPos];
                }
            }
            Console.WriteLine(dp[xSize - 1, ySize - 1]);
        }
    }
}