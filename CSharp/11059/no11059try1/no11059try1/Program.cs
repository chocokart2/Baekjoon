using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11059try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            int[] sums = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sums[i + 1] = sums[i] + nums[i] - '0';
            }

            // indexA ~ indexB = x[indexB + 1] - x[indexA]

            int maxSize = 0;
            for (int startIndex = 0; startIndex < nums.Length - 1; startIndex++)
            {
                for (int endIndex = startIndex + 1; endIndex < nums.Length; endIndex += 2)
                {
                    int middleIndex = (startIndex + endIndex + 1) / 2;
                    int left = sums[middleIndex] - sums[startIndex];
                    int right = sums[endIndex + 1] - sums[middleIndex];

                    //Console.WriteLine($"start = {startIndex}, end = {endIndex}, middle = {middleIndex}, left = {left}, right = {right}");
                    if (left != right) continue;

                    maxSize = Math.Max(maxSize, endIndex - startIndex + 1);
                }
            }

            Console.WriteLine(maxSize);
        }
    }
}
