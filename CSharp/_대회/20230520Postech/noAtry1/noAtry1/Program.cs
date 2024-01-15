using System;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            Console.ReadLine();
            string[] nums = Console.ReadLine().Split(' ');
            result = int.Parse(nums[0]);

            for (int index = 1; index < nums.Length; ++index)
            {
                result += int.Parse(nums[index]) + 8;
            }

            Console.WriteLine($"{result / 24} {result % 24}");
        }
    }
}
