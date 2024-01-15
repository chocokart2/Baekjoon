using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            float w = float.Parse(nums[0]);
            float h = float.Parse(nums[1]);

            Console.WriteLine("{0:F1}", (w * h * 0.5f));

        }
    }
}
