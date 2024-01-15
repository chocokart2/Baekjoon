using System;

namespace no1149try1
{
    internal class Program
    {
        // 그래, n번째 집은, n - 1번째 집이랑 같은 색상이면 안되니까 신경써야 해
        // 근데, n번째 집은 n - 2번째 집부터와는 캬루 양심 크기보다도 더 상관이 없어!

        static void Main(string[] args)
        {
            int[] minCost = new int[3] { 0, 0, 0 };
            int[] prevMinCost = new int[3] { 0, 0, 0 };
            // minCost[index] == 가장 마지막에 색칠한 집의 색상이 index번째 색상일 때, 지금까지 색칠하느라 쓴 돈의 최소값.
            // 0 == red, 1 == green, 2 == blue
            // prevMinCost == minCost을 깊은 복사 한 것

            int houseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < houseCount; i++)
            {
                for (int index = 0; index < 3; ++index)
                {
                    prevMinCost[index] = minCost[index];
                }

                string[] recvLineCost = Console.ReadLine().Split(' ');
                int redCost = int.Parse(recvLineCost[0]);
                int greenCost = int.Parse(recvLineCost[1]);
                int blueCost = int.Parse(recvLineCost[2]);

                minCost[0] = redCost + Math.Min(prevMinCost[1], prevMinCost[2]);
                minCost[1] = greenCost + Math.Min(prevMinCost[0], prevMinCost[2]);
                minCost[2] = blueCost + Math.Min(prevMinCost[0], prevMinCost[1]);
            }

            Console.WriteLine(Math.Min(Math.Min(minCost[0], minCost[1]), minCost[2]));
        }
    }
}
