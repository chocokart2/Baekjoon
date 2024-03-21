using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10824try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            Console.WriteLine($"{ulong.Parse($"{nums[0]}{nums[1]}") + ulong.Parse($"{nums[2]}{nums[3]}")}");
        }
    }
}
