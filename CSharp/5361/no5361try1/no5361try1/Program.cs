using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5361try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] cost = new long[5]
            {
                35034,
                23090,
                19055,
                12530,
                18090
            };
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                long sum = 0;
                for (int index = 0; index < nums.Length; ++index)
                {
                    sum += long.Parse(nums[index]) * cost[index];
                }
                Console.Write($"${sum / 100}.");
                Console.WriteLine("{0:00}", sum % 100);
            }
        }
    }
}
