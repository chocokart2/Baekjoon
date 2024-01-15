using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1267try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] nums = Console.ReadLine().Split(' ');
            int yongsik = 0;
            int minsik = 0;
            for (int index = 0; index < nums.Length; ++index)
            {
                int one = int.Parse(nums[index]);

                yongsik += one / 30 + 1;
                minsik += one / 60 + 1;
            }
            yongsik *= 10;
            minsik *= 15;

            if (yongsik > minsik) Console.WriteLine($"M {minsik}");
            else if (yongsik < minsik) Console.WriteLine($"Y {yongsik}");
            else Console.WriteLine($"Y M {yongsik}");
        }
    }
}
