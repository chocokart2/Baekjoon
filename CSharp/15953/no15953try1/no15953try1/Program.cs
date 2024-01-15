using System;
using System.Text;

namespace no15953try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int first = int.Parse(nums[0]);
                int second = int.Parse(nums[1]);
                int reward = 0;

                if (first == 0) { }
                else if (first <= 1) reward += 500_0000;
                else if (first <= 3) reward += 300_0000;
                else if (first <= 6) reward += 200_0000;
                else if (first <= 10) reward += 50_0000;
                else if (first <= 15) reward += 30_0000;
                else if (first <= 21) reward += 10_0000;

                if (second == 0) { }
                else if (second <= 1) reward += 512_0000;
                else if (second <= 3) reward += 256_0000;
                else if (second <= 7) reward += 128_0000;
                else if (second <= 15) reward += 64_0000;
                else if (second <= 31) reward += 32_0000;

                result.AppendLine(reward.ToString());
            }

            Console.Write(result);
        }
    }
}
