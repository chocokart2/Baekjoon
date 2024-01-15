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
            for (int i = 0; i < 15; ++i)
            {
                string recvLine = Console.ReadLine();
                foreach (char c in recvLine)
                {
                    switch (c)
                    {
                        case 'w':
                            Console.WriteLine("chunbae");
                            return;
                        case 'b':
                            Console.WriteLine("nabi");
                            return;
                        case 'g':
                            Console.WriteLine("yeongcheol");
                            return;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
