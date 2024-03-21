using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10569try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                Console.WriteLine($"{2 + int.Parse(nums[1]) - int.Parse(nums[0])}");
            }
        }
    }
}
