using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15734try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int left = int.Parse(nums[0]);
            int right = int.Parse(nums[1]);
            int both = int.Parse(nums[2]);

            int gap = Math.Max(left, right) - Math.Min(left, right);

            int result = Math.Min(left, right) * 2 + (gap > both ? both * 2 : ((gap + both) / 2) * 2);
            Console.WriteLine(result);
        }
    }
}
