using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16504try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.MaxValue;
            Console.WriteLine(a + 4);

            int i = 0; i = i + 1; i = i + 2; i = i + 3; i = i + 4;
            i = int.Parse(Console.ReadLine());
            long result = 0;
            for (int x = 0; x < i; x++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                for (int y = 0; y < i; y++)
                {
                    result += long.Parse(nums[y]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
