using System;

namespace no2752try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] threeNums = new int[3] { int.Parse(nums[0]), int.Parse(nums[1]), int.Parse(nums[2]) };

            Array.Sort(threeNums);
            Console.WriteLine($"{threeNums[0]} {threeNums[1]} {threeNums[2]}");
        }
    }
}
