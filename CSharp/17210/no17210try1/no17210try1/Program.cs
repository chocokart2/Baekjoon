using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17210try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long count = long.Parse(Console.ReadLine()) - 1;
            bool isStartZero = Console.ReadLine()[0] == '0';

            switch (count)
            {
                case 0: return;
                case 1: Console.WriteLine(isStartZero ? "1" : "0"); return;
                case 2: Console.WriteLine(isStartZero ? "1\n0" : "0\n1"); return;
                case 3: Console.WriteLine(isStartZero ? "1\n0\n1" : "0\n1\n0"); return;
                case 4: Console.WriteLine(isStartZero ? "1\n0\n1\n0" : "0\n1\n0\n1"); return;
                default: Console.WriteLine("Love is open door"); return;
            }

        }
    }
}
