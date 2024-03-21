using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCtry1
{
    internal class Program
    {
        static ulong Min(ulong left, ulong right) => (left > right) ? right : left;

        static void Main(string[] args)
        {
            // 바이러스 A의 위치의 수 * 바이러스 B의 위치의 수 * 바이러스 C의 위치의 수 * ... * 바이러스 N의 위치의 수
            // 일단 ulong 사용
            // 바이러스의 위치의 수(T초) = (2 * T + 1) ^ 2
            // ㄴ 조금 더 쪼개면 (북쪽 + 남쪽 + 1) * (동쪽 + 서쪽 + 1)
            // 값 구하기 최소값(시간, 그쪽 방향 거리)
            // 값을 계산할 때는 ((X % 나누기) * 원래 값) % 나누기
            string[] nums = Console.ReadLine().Split(' ');
            ulong xSize = ulong.Parse(nums[0]);
            ulong ySize = ulong.Parse(nums[1]);
            ulong count = ulong.Parse(nums[2]);
            ulong time = ulong.Parse(nums[3]);

            ulong result = 1;
            ulong divide = 998_244_353;
            for (;count > 0; --count)
            {
                string[] oneStr = Console.ReadLine().Split(' ');
                ulong xPos = ulong.Parse(oneStr[0]);
                ulong yPos = ulong.Parse(oneStr[1]);
                ulong one = (Min(time, yPos - 1) + Min(time, ySize - yPos) + 1) * (Min(time, xPos - 1) + Min(time, xSize - xPos) + 1);
                result = ((one % divide) * result) % divide;
            }
            Console.WriteLine(result);
        }
    }
}
