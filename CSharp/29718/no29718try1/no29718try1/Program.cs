using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no29718try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int lineCount = int.Parse(size[0]);
            int numCount = int.Parse(size[1]);
            long[] sums = new long[numCount + 1];
            for (int i = 0; i < lineCount; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                for (int index = 0; index < nums.Length; index++)
                {
                    sums[index + 1] += long.Parse(nums[index]);
                }
            }
            for (int index = 1; index < sums.Length; index++)
            {
                sums[index] += sums[index - 1];
            }
            long max = 0;
            for (int index = int.Parse(Console.ReadLine()), start = 0; index < sums.Length; ++index, ++start)
            {
                long one = sums[index] - sums[start];
                if (one > max)
                {
                    max = one;
                }
            }
            Console.WriteLine(max);
        }
    }
}
