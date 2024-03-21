using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1951try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong demand = ulong.Parse(Console.ReadLine());
            ulong result = 0;
            ulong numCount = 9;
            ulong chunkSize = 1;

            while (demand > 0)
            {
                ulong add = Math.Min(demand, numCount);
                demand -= add;

                result += add * chunkSize;
                result %= 1234567;

                numCount *= 10;
                chunkSize++;
            }

            Console.WriteLine(result);
        }
    }
}
