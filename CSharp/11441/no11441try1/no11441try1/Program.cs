using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11441try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sums = new int[int.Parse(Console.ReadLine()) + 1];
            string[] nums = Console.ReadLine().Split(' ');

            for (int index = 0; index < nums.Length; index++)
            {
                sums[index + 1] = sums[index] + int.Parse(nums[index]);
            }

            int query = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < query; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');

                result.Append($"{sums[int.Parse(one[1])] - sums[int.Parse(one[0]) - 1]}\n");
            }
            Console.Write(result);
        }
    }
}
