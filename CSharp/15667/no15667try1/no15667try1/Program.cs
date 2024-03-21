using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15667try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i < 101; i++)
            {
                if (num == i * i + i + 1)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
