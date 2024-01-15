using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13565try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            bool[,] graph = new bool[int.Parse(size[1]), int.Parse(size[0])];
            (int x, int y)[] queue = new (int x, int y)[graph.GetLength(0) * graph.GetLength(1)];
            int queueRear = 0;
            int queueHead = 0;

            for (int y = 0; y < graph.GetLength(1); y++)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < recvLine.Length; x++)
                {
                    graph[x, y] = recvLine[x] == '0';
                }
                if (y == 0)
                {
                    for (int x = 0; x < recvLine.Length; ++x)
                    {
                        if (graph[x, y] == true)
                        {
                            queue[queueHead] = (x, y);
                            queueHead++;
                            graph[x, y] = false;
                        }
                    }
                }
            }

            int[] deltaX = { 1, -1, 0, 0 };
            int[] deltaY = { 0, 0, 1, -1 };



            while (queueRear < queueHead)
            {
                int oneX = queue[queueRear].x;
                int oneY = queue[queueRear].y;
                queueRear++;

                // pop 실행
                for (int index = 0; index < 4; ++index)
                {

                    int x = oneX + deltaX[index];
                    int y = oneY + deltaY[index];


                    // 범위 내인지 체크
                    if (0 > x || x >= graph.GetLength(0)) continue;
                    if (0 > y || y >= graph.GetLength(1)) continue;

                    // 팝
                    if (graph[x, y] == false) continue;
                    
                    // 해피 루트
                    if (y == graph.GetLength(1) - 1)
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                    graph[x, y] = false;
                    queue[queueHead] = (x, y);
                    queueHead++;
                }
            }
            Console.WriteLine("NO");
        }
    }
}
