using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1309try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[100_001];
            result[0] = 3;
            int prev = 3;
            
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i < count; ++i)
            {
                prev = prev * 3 - 2;
            }

            Console.WriteLine(prev);
        }
    }
}
