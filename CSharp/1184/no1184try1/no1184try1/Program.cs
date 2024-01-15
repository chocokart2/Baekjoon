using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace no1184try1
{
    internal class Program
    {
        static Dictionary<(int x, int y, int sum), int> sumUpLeft;
        static Dictionary<(int x, int y, int sum), int> sumUpRight;
        
        public static void AddValue(Dictionary<(int x, int y, int sum), int> map, (int x, int y, int sum) key)
        {
            if (map.ContainsKey(key))
            {
                map[key]++;
            }
            else
            {
                map[key] = 1;
            }
        }
        public static int GetValue(Dictionary<(int x, int y, int sum), int> map, (int x, int y, int sum) key)
        {
            if (map.ContainsKey(key)) return map[key];
            else return 0;
        }

        static int size;
        static int[,] sums;

        static int GetRectangleSum(int xMin, int yMin, int xMax, int yMax)
        {
            return sums[xMax, yMax] - sums[xMin, yMax] - sums[xMax, yMin] + sums[xMin, yMin];
        }

        static void Main(string[] args)
        {
            sumUpLeft = new Dictionary<(int x, int y, int sum), int>();
            sumUpRight = new Dictionary<(int x, int y, int sum), int>();

            size = int.Parse(Console.ReadLine());
            int count = 0;

            sums = new int[size + 1, size + 1];
            for (int y = 0; y < size; y++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                for (int x = 0; x < size; x++)
                {
                    sums[x + 1, y + 1]
                        = sums[x + 1, y] + sums[x, y + 1] - sums[x, y] + int.Parse(recvLine[x]);
                }
            }

            // 세상에, O(N^4) 알고리즘입니다. N <= 250이라 살았습니다.

            for (int x1 = 0; x1 < size; ++x1)
            {
                for (int y1 = 0; y1 < size; ++y1)
                {
                    for (int x2 = x1 + 1; x2 <= size; ++x2)
                    {
                        for (int y2 = y1 + 1; y2 <= size; ++y2)
                        {
                            int sum = GetRectangleSum(x1, y1, x2, y2);
                            // 저장하기
                            AddValue(sumUpLeft, (x2, y2, sum + 2_500_500));
                            AddValue(sumUpRight, (x1, y2, sum + 2_500_500));
                        }
                    }
                }
            }
            for (int x1 = 0; x1 < size; ++x1)
            {
                for (int y1 = 0; y1 < size; ++y1)
                {
                    for (int x2 = x1 + 1; x2 <= size; ++x2)
                    {
                        for (int y2 = y1 + 1; y2 <= size; ++y2)
                        {
                            int sum = GetRectangleSum(x1, y1, x2, y2);
                            // 로드하기
                            count += GetValue(sumUpLeft, (x1, y1, sum + 2_500_500));
                            count += GetValue(sumUpRight, (x2, y1, sum + 2_500_500));
                        }
                    }
                }
            }
            
            Console.WriteLine(count);
        }
    }
}
