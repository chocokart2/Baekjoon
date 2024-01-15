using System;

namespace no11021try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i < count + 1; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                Console.WriteLine($"Case #{i}: {int.Parse(nums[0]) + int.Parse(nums[1])}");
            }
        }
    }
}
