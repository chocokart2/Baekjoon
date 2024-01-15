using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2846try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 꼬리를 자르는 경우
            // 더이상 증가하지 않는 경우 => 이번 숫자가 이전 숫자에 비해 크지 않은 경우
            // 루프의 끝에 도달한 경우. => 이번 인덱스가 밖으로 나간 경우.
            Console.ReadLine();
            string[] nums = Console.ReadLine().Split(' ');

            int prev = -1;
            int start = 0;
            int riseMax = 0;

            for (int index = 0; index < nums.Length; index++)
            {
                int one = int.Parse(nums[index]);

                if (index == 0)
                {
                    start = one;
                }
                else if (prev >= one)
                {
                    // 기록
                    riseMax = Math.Max(riseMax, prev - start);
                    // 새 꼬리
                    start = one;
                }

                prev = one;
            }

            riseMax = Math.Max(riseMax, prev - start);

            Console.WriteLine(riseMax);
        }
    }
}
