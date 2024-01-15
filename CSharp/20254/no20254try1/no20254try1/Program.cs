using System;

namespace no20254try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int score = int.Parse(nums[0]) * 56 + int.Parse(nums[1]) * 24 + int.Parse(nums[2]) * 14 + int.Parse(nums[3]) * 6;
            Console.WriteLine(score);
        }
    }
}
