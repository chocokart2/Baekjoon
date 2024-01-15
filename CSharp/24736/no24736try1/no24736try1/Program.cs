using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no24736try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[2];

            for (int i = 0; i < 2; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int[] ints = new int[nums.Length];
                for (int index = 0; index < nums.Length; ++index)
                {
                    ints[index] = int.Parse(nums[index]);
                }

                result[i] = ints[0] * 6 + ints[1] * 3 + ints[2] * 2 + ints[3] * 1 + ints[4] * 2;
            }

            Console.WriteLine($"{result[0]} {result[1]}");

        }
    }
}
