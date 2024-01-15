using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            for (int i = 0; i < 5; ++i)
            {
                a ^= int.Parse(Console.ReadLine());
            }
            Console.WriteLine(a);
        }
    }
}
