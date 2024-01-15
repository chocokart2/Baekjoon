using System;

namespace no14652try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int m = int.Parse(nums[1]);
            int k = int.Parse(nums[2]);
            Console.WriteLine($"{k/m} {k%m}");
        }
    }
}
