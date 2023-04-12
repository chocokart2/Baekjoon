using System;

namespace no1085try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] positions = new int[4]; // x, y, w, h
            for(int i = 0; i < nums.Length; ++i)
                positions[i] = int.Parse(nums[i]);
            // a b c d일 때, a-c, c-a, b-d, d-b의 값중 가장 작은 값을 구함.
            Console.WriteLine(
                Math.Min(
                    Math.Min(
                        positions[0],
                        Math.Abs(positions[2] - positions[0])
                        )
                    , Math.Min(
                        positions[1],
                        Math.Abs(positions[3] - positions[1])
                        )
                    )
                );
        }
    }
}
