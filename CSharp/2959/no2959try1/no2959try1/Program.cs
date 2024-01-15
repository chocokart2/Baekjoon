using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace no2959try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] indexes = new int[3][]
            {
                new int[]
                {
                    0, 1, 2, 3
                },
                new int[]
                {
                    0, 2, 1, 3
                },
                new int[]
                {
                    0, 3, 1, 2
                }
            };
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[4];
            for (int index = 0; index < 4; ++index)
                nums[index] = int.Parse(recvLine[index]);
            int result = int.MinValue;
            for (int index = 0; index < 3; ++index)
            {
                int one =
                    Math.Min(nums[indexes[index][0]], nums[indexes[index][1]])
                    * Math.Min(nums[indexes[index][2]], nums[indexes[index][3]]);
                if (result < one) result = one;
            }
            Console.WriteLine(result);
        }
    }
}
