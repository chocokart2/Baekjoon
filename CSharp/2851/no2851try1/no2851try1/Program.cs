using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2851try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[11];
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine()) + nums[i - 1];
            }

            int nearest = 0;
            int nearDiff = int.MaxValue;
            for (int end = 0; end < 11; ++end)
            {
                int one = nums[end] - nums[0];
                //Console.WriteLine($">> sum[{end}] - sum[{0}] = {one}");
                int oneDiff = Math.Abs(one - 100);
                if (nearDiff > oneDiff)
                {
                    //Console.WriteLine($"업데이트 1 : near diff = {nearDiff}, oneDiff = {oneDiff}");
                    nearest = one;
                    nearDiff = oneDiff;
                    continue;
                }
                if (nearDiff == oneDiff && one > nearest)
                {
                    nearest = one;
                }
            }
            Console.WriteLine(nearest);
        }
    }
}
