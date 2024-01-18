using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16973try1
{
    internal class Program
    {
        struct Vector2
        {
            public int x;
            public int y;

            static public Vector2 operator +(Vector2 left, Vector2 right)
            {
                return new Vector2() { x = left.x + right.x, y = left.y + right.y };
            }
        }

        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int xSize = int.Parse(size[1]);
            int ySize = int.Parse(size[0]);

            int[,] sums = new int[xSize + 1, ySize + 1];
            for (int y = 0; y < ySize; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < xSize; ++x)
                {
                    sums[x + 1, y + 1] = sums[x + 1, y] + sums[x, y + 1] - sums[x, y] + (recvLine[x * 2] == '1' ? 1 : 0);
                }
            }

            string[] nums = Console.ReadLine().Split(' ');
            Vector2 rectSize = new Vector2() { x = int.Parse(nums[1]), y = int.Parse(nums[0]) };
            Vector2 start = new Vector2() { x = int.Parse(nums[3]) - 1, y = int.Parse(nums[2]) - 1 };
            Vector2 end = new Vector2() { x = int.Parse(nums[5]) - 1, y = int.Parse(nums[4]) - 1 };

            bool M_IsAvailable(Vector2 position)
            {
                Vector2 m_front = new Vector2() { x = position.x, y = position.y };
                Vector2 m_back = new Vector2()
                {
                    x = position.x + rectSize.x,
                    y = position.y + rectSize.y
                };

                if (m_front.x < 0 || m_front.x > xSize || m_front.y < 0 || m_front.y > ySize) return false;
                if (m_back.x < 0 || m_back.x > xSize || m_back.y < 0 || m_back.y > ySize) return false;

                return (sums[m_back.x, m_back.y] - sums[m_back.x, m_front.y] - sums[m_front.x, m_back.y] + sums[m_front.x, m_front.y] == 0);
            }

            Vector2[] queue = new Vector2[xSize * ySize * 2];
            int queueRear = 0;
            int queueHead = 0;
            bool[,] trace = new bool[xSize, ySize];
            int[,] cost = new int[xSize, ySize];
            if (M_IsAvailable(start))
            {
                queue[0] = start;
                queueHead++;
                trace[start.x, start.y] = true;
            }

            Vector2[] moveDelta = new Vector2[4]
            {
                new Vector2() { x = 1, y = 0 },
                new Vector2() { x = -1, y = 0 },
                new Vector2() { x = 0, y = 1 },
                new Vector2() { x = 0, y = -1 }
            };

            while (queueHead > queueRear)
            {
                Vector2 one = queue[queueRear];
                queueRear++;

                // 주변으로 pop
                for (int index = 0; index < 4; index++)
                {
                    Vector2 newOne = one + moveDelta[index];

                    if (!M_IsAvailable(newOne)) continue;
                    if (trace[newOne.x, newOne.y]) continue;
                    queue[queueHead] = newOne;
                    queueHead++;
                    trace[newOne.x, newOne.y] = true;
                    cost[newOne.x, newOne.y] = cost[one.x, one.y] + 1;
                }
            }

            Console.WriteLine(trace[end.x, end.y] ? cost[end.x, end.y] : -1);
        }
    }
}
