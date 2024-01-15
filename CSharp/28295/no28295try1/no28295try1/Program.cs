using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28295try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += Console.ReadLine()[0] - '0';
            }
            
            switch (sum % 4)
            {
                case 0: Console.WriteLine("N"); break;
                case 1: Console.WriteLine("E"); break;
                case 2: Console.WriteLine("S"); break;
                case 3: Console.WriteLine("W"); break;
                default: break;
            }
        }
    }
}
