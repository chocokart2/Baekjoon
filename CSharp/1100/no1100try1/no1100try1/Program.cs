using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1100try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int y = 0; y < 8; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < 8; ++x)
                {
                    if (((x + y) % 2) == 1) continue;
                    if (recvLine[x] == 'F') count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
