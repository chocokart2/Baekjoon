using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2003try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            string[] nums = Console.ReadLine().Split(' ');

            int count = int.Parse(nums[0]);
            int target = int.Parse(nums[1]);

            string[] numsA = Console.ReadLine().Split(' ');
            int[] sum = new int[numsA.Length + 1];
            for (int index = 1; index < sum.Length; index++)
            {
                sum[index] = sum[index - 1] + int.Parse(numsA[index - 1]);
            }

            for (int indexA = 0; indexA  < sum.Length - 1; indexA++)
            {
                for (int indexB = indexA + 1; indexB < sum.Length; ++indexB)
                {
                    if (sum[indexB] - sum[indexA] == target) result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
