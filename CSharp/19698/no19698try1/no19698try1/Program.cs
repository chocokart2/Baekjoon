using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no19698try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int size = int.Parse(nums[3]);
            Console.WriteLine(Math.Min(
                int.Parse(nums[0]),
                (int.Parse(nums[1]) / size) * (int.Parse(nums[2]) / size)
                ));
        }
    }
}
