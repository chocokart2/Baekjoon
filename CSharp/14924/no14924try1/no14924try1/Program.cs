using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14924try1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 시간 곱하기 파리 속도
            // 시간 = 거리 / (기차 속도 * 2)
            string[] nums = Console.ReadLine().Split(' ');

            Console.WriteLine(
                int.Parse(nums[1]) *
                (int.Parse(nums[2]) / (int.Parse(nums[0]) * 2))
                );
        }
    }
}
