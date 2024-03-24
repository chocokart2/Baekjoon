using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1806try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = int.MaxValue;

            int head = 1;
            int tail = 0;

            int target = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] numsStr = Console.ReadLine().Split(' ');
            int[] sums = new int[numsStr.Length + 1];
            for (int index = 0; index < numsStr.Length; index++)
            {
                int one = int.Parse(numsStr[index]);
                sums[index + 1] = sums[index] + one;
            }

            while (head < sums.Length && tail < sums.Length)
            {
                int one = sums[head] - sums[tail];
                if (one >= target)
                {
                    result = Math.Min(result, head - tail);
                    tail++;
                }
                else
                {
                    head++;
                }
            }
            Console.WriteLine((result == int.MaxValue) ? 0 : result);
        }
    }
}
