using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1011try1
{
    internal class Program
    {
        static long GetMoveMax(long stepCount)
        {
            long input = stepCount;
            long result = 0;
            // 1    1
            // 2    1 1 : i가 0일때 delta 유지
            // 3    1 2 1 => 2 * 2
            // 4    1 2 2 1 : i가 1일때 delta 유지
            // 5    1 2 3 2 1
            // => 1 + 2 + 2 + 1 + 3 => 3 * 3
            // 6    1 2 3 3 2 1 : i가 2일 때 delta 유지
            // => 1 + 3 + 2 + 2 + 3 + 1 => 4 * 3 = 12
            // 1
            // 1
            // 2
            // 2
            // 3

            if (stepCount % 2 == 0)
            {
                stepCount >>= 1;
                result = stepCount * (stepCount + 1);
            }
            else
            {
                stepCount = (stepCount + 1) >> 1;
                result = stepCount * stepCount;
            }
            return result;
        }

        static long GetStep(long length)
        {
            //Console.WriteLine($"GetStep({length})");

            long result = 1;
            for (; length > GetMoveMax(result); ++result) ;
            return result;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                result.Append($"{GetStep(long.Parse(nums[1]) - long.Parse(nums[0]))}\n");
            }

            Console.Write(result);
        }
    }
}
