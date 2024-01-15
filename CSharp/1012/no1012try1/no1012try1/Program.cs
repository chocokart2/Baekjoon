using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1012try1
{
    internal class Program
    {
        static void Display(int[,] farm)
        {
            for (int y = 0; y < farm.GetLength(0); ++y)
            {
                for (int x = 0; x < farm.GetLength(1); ++x)
                {
                    switch(farm[y, x])
                    {
                        case 0: Console.Write("__  "); break;
                        case 1: Console.Write("OO  "); break;
                        case 2: Console.Write("XX  "); break;
                        default: Console.Write("??  "); break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        static int TestCase()
        {
            int result = 0;

            const int VOID = 0;
            const int NAPA_CABBAGE = 1;
            const int INFESTED_CABBAGE = 2;
            

            string[] recvLine = Console.ReadLine().Split(' ');
            // farm[y,x] 0 = void; 1 = empty; 2 = infected
            int m = int.Parse(recvLine[0]); // m == farmLengthX
            int n = int.Parse(recvLine[1]); // n == farmLengthY
            int k = int.Parse(recvLine[2]);
            int[,] farm = new int[n, m];
            //farm init
            for (int i = 0; i < k; ++i)
            {
                string[] pos = Console.ReadLine().Split(' ');
                farm[int.Parse(pos[1]), int.Parse(pos[0])] = NAPA_CABBAGE;
            }

            // 깊이 우선 탐색
            (int x, int y)[] stackData = new (int x, int y)[2500];
            int stackCursor = -1;

            bool IsCabbage(int x, int y) => farm[y, x] == NAPA_CABBAGE;
            (int x, int y) Peek()
            {
                if (stackCursor == -1) return (-1, -1);
                return stackData[stackCursor];
            }
            (int x, int y) Pop()
            {
                if (stackCursor == -1) return (-1, -1);
                --stackCursor;
                return stackData[stackCursor + 1];
            }
            void Push((int x, int y) data)
            {
                ++stackCursor;
                stackData[stackCursor] = data;
            }
            bool IsAvailableIndex(int x, int y) => x > -1 && x < m && y > -1 && y < n;
            void TryInfestCabbage(int x, int y)
            {
                if (farm[y, x] != NAPA_CABBAGE) return;
                farm[y, x] = INFESTED_CABBAGE;
                Push((x, y));
            }

            for (int yIndex = 0; yIndex < n; ++yIndex)
            {
                for (int xIndex = 0; xIndex < m; ++xIndex)
                {
                    // 재귀 함수를 반복문으로 바꾸었습니다.
                    if (!(farm[yIndex, xIndex] == NAPA_CABBAGE)) continue;

                    //Console.WriteLine($"found fresh victim in [{yIndex}, {xIndex}]");
                    //Display(farm);

                    ++result;
                    Push((xIndex, yIndex));
                    farm[yIndex, xIndex] = INFESTED_CABBAGE;
                    while (stackCursor > -1)
                    {
                        

                        (int x, int y) pos = Peek();
                        if (pos.x == -1) break;
                        (int x, int y)[] near =
                        {
                            (pos.x + 1, pos.y),
                            (pos.x - 1, pos.y),
                            (pos.x, pos.y + 1),
                            (pos.x, pos.y - 1)
                        };

                        // 주변 양배추를 향해 전파
                        bool isFound = false;
                        for (int index = 0; index < near.Length; ++index)
                        {
                            if (!IsAvailableIndex(near[index].x, near[index].y)) continue;
                            if (!IsCabbage(near[index].x, near[index].y)) continue;
                            TryInfestCabbage(near[index].x, near[index].y);
                            isFound = true;
                            break;
                        }

                        if (isFound)
                        {
                            continue;
                        }
                        Pop();
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine(TestCase());
            }
        }
    }
}
