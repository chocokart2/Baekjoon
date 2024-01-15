using System;

namespace no10807try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int result = 0;
            string[] nums = Console.ReadLine().Split(' ');
            string target = Console.ReadLine();
            for (int index = 0; index < nums.Length; ++index)
                if (nums[index].Equals(target)) ++result;
            Console.WriteLine(result);
        }
    }
}
