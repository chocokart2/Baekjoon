using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9295try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
            {
                string nums = Console.ReadLine();
                Console.WriteLine($"Case {i}: {nums[0] + nums[2] - '0' * 2}");
            }
        }
    }
}
