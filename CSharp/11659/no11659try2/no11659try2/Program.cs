using System;
using System.Text;

namespace no11659wtry2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string[] recvLineNM = Console.ReadLine().Split(' ');
            string[] recvLineNums = Console.ReadLine().Split(' ');

            int N = int.Parse(recvLineNM[0]);
            int M = int.Parse(recvLineNM[1]);
            int[] nums = new int[N];
            int[] sum = new int[N + 1];
            sum[0] = 0;
            for (int index = 0; index < N; ++index)
            {
                nums[index] = int.Parse(recvLineNums[index]);
                sum[index + 1] = nums[index] + sum[index];
            }

            for (int i = 0; i < M; ++i)
            {
                string[] recvLineIJ = Console.ReadLine().Split(' ');
                result.Append($"{sum[int.Parse(recvLineIJ[1])] - sum[int.Parse(recvLineIJ[0]) - 1]}\n");
            }
            Console.WriteLine(result);
        }
    }
}
