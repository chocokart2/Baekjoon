using System;

namespace no2163try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            Console.WriteLine(int.Parse(nums[0]) * int.Parse(nums[1]) - 1);
        }
    }
}
