using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace no12847try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            int term = int.Parse(recvLineNM[1]);
            string[] recvLine = Console.ReadLine().Split(' ');

            long[] nums = new long[recvLine.Length + 1];

            for (int index = 0; index < recvLine.Length; ++index)
            {
                nums[index + 1] = long.Parse(recvLine[index]) + nums[index];
            }

            long max = 0;
            for (int index = term; index < nums.Length; ++index)
            {
                long one = nums[index] - nums[index - term];

                //Console.WriteLine($">> one = {one}");
                if (one > max) { max = one; }
            }

            Console.WriteLine(max);
        }
    }
}
