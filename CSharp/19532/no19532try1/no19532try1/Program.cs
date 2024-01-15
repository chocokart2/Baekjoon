using System;

namespace no19532try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int a = int.Parse(nums[0]);
            int b = int.Parse(nums[1]);
            int c = int.Parse(nums[2]);
            int d = int.Parse(nums[3]);
            int e = int.Parse(nums[4]);
            int f = int.Parse(nums[5]);
            int x = 0;
            int y = 0;

            
            if (a != 0 && b != 0 && d != 0 && e != 0)
            {
                y = (c * d - f * a) / (b * d - e * a);
                x = (c - b * y) / a;
            }


            Console.WriteLine($"{x} {y}");
        }
    }
}
