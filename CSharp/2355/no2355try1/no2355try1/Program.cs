using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2355try1
{
    internal class Program
    {
        static long Sum(long top)
        {
            if (top == -1) return -1;
            return ((top > 0) ? (top + 1) : (-top + 1)) * top / 2;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            long top = Math.Max(long.Parse(nums[0]), long.Parse(nums[1]));
            long min = Math.Min(long.Parse(nums[0]), long.Parse(nums[1]));

            long result =
                (min * Math.Abs(top - min + 1))
                + Sum(top - min);
            Console.WriteLine(result);

        }
    }
}
