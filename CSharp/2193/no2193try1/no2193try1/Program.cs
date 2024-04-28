using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2193try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong lastOne = 1;
            ulong lastZero = 0;

            for (int i = int.Parse(Console.ReadLine()) - 1; i > 0; --i)
            {
                ulong nextOne = lastZero;
                ulong nextZero = lastOne + lastZero;

                lastOne = nextOne;
                lastZero = nextZero;
            }

            Console.WriteLine((lastOne + lastZero).ToString());
        }
    }
}
