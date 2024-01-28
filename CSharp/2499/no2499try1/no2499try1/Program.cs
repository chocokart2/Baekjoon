using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2499try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int y = 0; y < size; ++y)
            {
                string[] oneLine = Console.ReadLine().Split(' ');
                for (int x = 0; x < size; ++x)
                {
                    sum += int.Parse(oneLine[x]);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
