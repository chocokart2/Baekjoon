using System;

namespace no15964try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            long a = long.Parse(nums[0]);
            long b = long.Parse(nums[1]);

            Console.WriteLine((a + b) * (a - b));
        }
    }
}
