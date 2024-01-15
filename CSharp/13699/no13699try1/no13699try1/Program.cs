using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13699try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long[] t = new long[36];
            t[0] = 1;
            long GetT(int n)
            {
                if (t[n] == 0)
                {
                    long sum = 0;
                    for (int x = 0; x < n; ++x)
                    {
                        sum += GetT(x) * GetT(n - 1 - x);
                    }
                    t[n] = sum;
                }

                return t[n];
            }

            Console.WriteLine(GetT(int.Parse(Console.ReadLine())));
        }
    }
}
