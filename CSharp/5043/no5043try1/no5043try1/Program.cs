using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5043try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            long max = 0;
            long fileCount = long.Parse(nums[0]);
            long b = long.Parse(nums[1]);
            for (int i = 0; i <= b; i++)
            {
                max |= (1L << i);
            }
            Console.WriteLine(max >= fileCount ? "yes" : "no");
        }
    }
}
