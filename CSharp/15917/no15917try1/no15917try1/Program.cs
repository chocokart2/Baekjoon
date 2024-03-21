using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15917try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int q = int.Parse(Console.ReadLine()); q > 0; q--)
            {
                long one = long.Parse(Console.ReadLine());
                int sum = 0;
                for (int bit = 0; bit < 32; bit++)
                {
                    sum += (one & (1 << bit)) == (1 << bit) ? 1 : 0;
                }
                result.AppendLine(sum == 1 ? "1" : "0");
            }
            Console.Write(result);

        }
    }
}
