using System;

namespace no8723try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int a = int.Parse(nums[0]);
            int b = int.Parse(nums[1]);
            int c = int.Parse(nums[2]);
            int max = Math.Max(Math.Max(a, b), c);

            if (a == b && b == c) Console.WriteLine(2);
            else if (max * max * 2 == a * a + b * b + c * c) Console.WriteLine(1);
            else Console.WriteLine(0);
        }
    }
}
