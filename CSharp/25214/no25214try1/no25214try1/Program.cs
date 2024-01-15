using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25214try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] nums = Console.ReadLine().Split(' ');
            int[] result = new int[count];

            int max = int.Parse(nums[0]);
            int min = int.Parse(nums[0]);

            result[0] = 0;

            for (int index = 1; index < count; ++index)
            {
                int one = int.Parse(nums[index]);

                if (one > max) max = one;
                if (one < min) min = one;

                result[index] = max - min;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(result[0].ToString());
            for (int index = 1; index < count; ++index)
            {
                sb.Append($" {result[index].ToString()}");
            }

            Console.WriteLine(sb);
        }
    }
}
