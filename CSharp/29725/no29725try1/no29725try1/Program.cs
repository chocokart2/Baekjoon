using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no29725try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int y = 0; y < 8; ++y)
            {
                string line = Console.ReadLine();
                for (int x = 0; x < 8; ++x)
                {
                    switch (line[x])
                    {
                        case 'P': result += 1; break;
                        case 'p': result -= 1; break;
                        case 'N': result += 3; break;
                        case 'n': result -= 3; break;
                        case 'B': result += 3; break;
                        case 'b': result -= 3; break;
                        case 'R': result += 5; break;
                        case 'r': result -= 5; break;
                        case 'Q': result += 9; break;
                        case 'q': result -= 9; break;
                        default: break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
