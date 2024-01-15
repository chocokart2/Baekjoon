using System;

namespace no1312try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 일단 피제수를 제수로 나누되, 정수 횟수만큼 나눕니다.
            // 한자릿수 오른쪽으로 옮길 때, 10씩 곱합니다.

            string[] nums = Console.ReadLine().Split(' ');
            int A = int.Parse(nums[0]);
            int B = int.Parse(nums[1]);
            int N = int.Parse(nums[2]);

            int remained = A % B; // 피제수를 제수로 나눈 나머지
            for (int point = 0; point < N - 1; ++point)
            {
                remained *= 10;
                remained %= B;
            }
            remained *= 10;
            Console.WriteLine(remained / B);
        }
    }
}
