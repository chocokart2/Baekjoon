using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no21318try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int bufferSize = 1_100_000;
            StreamReader reader = new StreamReader(Console.OpenStandardInput(bufferSize));

            reader.ReadLine();
            string[] nums = reader.ReadLine().Split(' ');
            int[] sums = new int[nums.Length + 1]; // 자신이 다음 원소보다 큰 경우 +1
            // 값 => 값[현재인덱스 - 2] - 값[과거인덱스 - 1]
            int prev = 0;
            for (int index = 0; index < nums.Length; ++index)
            {
                int one = int.Parse(nums[index]);
                if (index > 0)
                {
                    if (prev > one)
                    {
                        sums[index]++;
                    }
                    sums[index + 1] = sums[index];
                }
                prev = one;
            }

            int count = int.Parse(reader.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] oneLine = reader.ReadLine().Split(' ');
                int start = int.Parse(oneLine[0]);
                int end = int.Parse(oneLine[1]);
                if (start == end)
                {
                    result.AppendLine("0");
                }
                else
                {
                    result.AppendLine($"{sums[end - 1] - sums[start - 1]}");
                }
            }

            Console.Write(result);
            reader.Close();
        }
    }
}
