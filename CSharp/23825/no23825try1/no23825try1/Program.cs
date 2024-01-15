using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no23825try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            Console.WriteLine((Math.Min(int.Parse(nums[0]), int.Parse(nums[1])) >> 1));
        }
    }
}
