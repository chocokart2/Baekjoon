using System;
namespace no2455try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passenger = 0;
            int max = 0;

            for (int i = 0; i < 4; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');

                passenger += int.Parse(nums[1]) - int.Parse(nums[0]);
                if (max < passenger) max = passenger;
            }

            Console.WriteLine(max);
        }
    }
}
