using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10656try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sizeStr = Console.ReadLine().Split(' ');
            int xSize = int.Parse(sizeStr[1]);
            int ySize = int.Parse(sizeStr[0]);

            bool[,] puzzle = new bool[xSize + 2, ySize + 2]; // 바깥 여부를 판단하는 함수 만들기가 너무 귀찮습니다.
            // 모서리와 빈칸은 false로 표현할 것
            StringBuilder result = new StringBuilder();
            int resultCount = 0;
            for (int y = 1; y <= ySize; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 1; x <= xSize; ++x)
                {
                    puzzle[x, y] = (recvLine[x - 1] == '.');
                }
            }

            for (int startY = 1; startY <= ySize; ++startY)
            {
                for (int startX = 1; startX <= xSize; ++startX)
                {
                    bool isFound = false;
                    for (int i = -1; i < 3; ++i)
                    {
                        if (puzzle[startX + i, startY] == (i == -1)) break;
                        if (i == 2) isFound = true;
                    }
                    for (int i = -1; i < 3; ++i)
                    {
                        if (puzzle[startX, startY + i] == (i == -1)) break;
                        if (i == 2) isFound = true;
                    }

                    if (isFound)
                    {
                        result.AppendLine($"{startY} {startX}");
                        resultCount++;
                    }
                }
            }

            Console.Write($"{resultCount}\n{result}");
        }
    }
}
