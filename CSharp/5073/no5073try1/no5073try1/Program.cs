using System;

namespace no5073try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] nums = Console.ReadLine().Split(' ');
                
                if (nums[0].Equals("0")) break;
                int a = int.Parse(nums[0]);
                int b = int.Parse(nums[1]);
                int c = int.Parse(nums[2]);

                if ((a + b + c) <= (Math.Max(Math.Max(a, b), c) * 2)) Console.WriteLine("Invalid");
                else if (a == b && b == c) Console.WriteLine("Equilateral");
                else if (a == b || b == c || c == a) Console.WriteLine("Isosceles");
                else Console.WriteLine("Scalene");
            }
        }
    }
}
