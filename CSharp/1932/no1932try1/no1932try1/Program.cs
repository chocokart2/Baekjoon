using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1932try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // O(N^2) 일고리즘!

            int size = int.Parse(Console.ReadLine());
            int[,] sum = new int[size, size]; // sum[lastNumIndex, index]

            // lastNumIndex는 위에서 n - 1번째 칸을 의미합니다.
            sum[0, 0] = int.Parse(Console.ReadLine());
            for (int lastNumIndex = 1; lastNumIndex < size; ++lastNumIndex)
            {
                string[] numsString = Console.ReadLine().Split(' ');
                int[] nums = new int[numsString.Length];
                for (int index = 0; index < numsString.Length; ++index) nums[index] = int.Parse(numsString[index]);

                for (int index = 0; index < lastNumIndex; ++index) sum[lastNumIndex, index] = sum[lastNumIndex - 1, index] + nums[index];
                for (int index = 0; index < lastNumIndex; ++index)
                {
                    int newSum = sum[lastNumIndex - 1, index] + nums[index + 1];
                    if (sum[lastNumIndex, index + 1] < newSum) sum[lastNumIndex, index + 1] = newSum;
                }
            }

            int max = 0;
            for (int index = 0; index < size; ++index) if (max < sum[size - 1, index]) max = sum[size - 1, index];

            Console.WriteLine(max);
        }
    }
}
