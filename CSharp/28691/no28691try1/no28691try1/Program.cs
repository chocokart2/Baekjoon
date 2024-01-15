using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28691try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            switch (Console.ReadLine()[0])
            {
                case 'M':
                    Console.WriteLine("MatKor");
                    break;
                case 'W':
                    Console.WriteLine("WiCys");
                    break;
                case 'C':
                    Console.WriteLine("CyKor");
                    break;
                case 'A':
                    Console.WriteLine("AlKor");
                    break;
                case '$':
                    Console.WriteLine("$clear");
                    break;
                default:
                    break;
            }
        }
    }
}
