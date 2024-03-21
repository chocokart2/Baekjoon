using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no21921try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] sum = new int[recvLine.Length + 1];
            int max = 0;
            int count = 0;
            for (int index = 0; index < recvLine.Length; index++)
            {
                sum[index + 1] = sum[index] + int.Parse(recvLine[index]);
            }
            for (int index = x; index < recvLine.Length + 1; index++)
            {
                int one = sum[index] - sum[index - x];
                if (one == max)
                {
                    count++;
                }
                else if (one > max)
                {
                    max = one;
                    count = 1;
                }
            }

            if (max == 0)
            {
                Console.WriteLine("SAD");
            }
            else
            {
                Console.WriteLine(max);
                Console.WriteLine(count);
            }
        }
    }
}
