using System;

namespace no7891try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                Console.WriteLine(int.Parse(nums[0]) + int.Parse(nums[1]));
            }
        }
    }
}
