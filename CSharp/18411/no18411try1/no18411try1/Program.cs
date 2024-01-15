using System;
namespace no18411try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            Console.WriteLine($"{int.Parse(nums[0]) + int.Parse(nums[1]) + int.Parse(nums[2]) - Math.Min(Math.Min(int.Parse(nums[0]), int.Parse(nums[1])), int.Parse(nums[2]))}");
        }
    }
}
