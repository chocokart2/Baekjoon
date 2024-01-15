using System;

namespace no10797try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            string target = Console.ReadLine();
            string[] nums = Console.ReadLine().Split(' ');

            for (int index = 0; index < 5; ++index) if (target.Equals(nums[index])) ++result;

            Console.WriteLine(result);
        }
    }
}
