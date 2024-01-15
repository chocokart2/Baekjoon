using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no6try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int p = int.Parse(nums[0]);
                int c = int.Parse(nums[1]);

                if (Math.Abs(p - score) <= c) score++;
            }
            Console.WriteLine(score);
        }
    }
}
