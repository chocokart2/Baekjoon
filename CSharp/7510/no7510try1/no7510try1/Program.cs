using System;
using System.Text;

namespace no7510try1
{
    internal class Program
    {
        static int GetSquare(int a) => a * a;

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int a = int.Parse(nums[0]);
                int b = int.Parse(nums[1]);
                int c = int.Parse(nums[2]);

                result.Append($"Scenario #{i}:\n");
                result.Append((2 * GetSquare(Math.Max(Math.Max(a, b), c)) == (GetSquare(a) + GetSquare(b) + GetSquare(c))) ? "yes\n" : "no\n");
                if (i < count) result.Append('\n');
            }

            Console.Write(result);
        }
    }
}
