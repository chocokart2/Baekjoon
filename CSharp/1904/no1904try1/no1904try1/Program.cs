using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1904try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sum = new int[1_000_000];
            sum[0] = 1;
            sum[1] = 2;
            for (int index = 2; index < sum.Length; ++index)
                sum[index] = (sum[index - 1] + sum[index - 2]) % 15746;

            Console.WriteLine(sum[int.Parse(Console.ReadLine()) - 1]);
        }
    }
}
