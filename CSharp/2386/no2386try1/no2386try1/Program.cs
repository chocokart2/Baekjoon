using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2386try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine().ToLower();
                char one = recvLine[0];
                if (one == '#') break;
                int count = 0;
                for (int index = 2; index < recvLine.Length; ++index)
                {
                    if (recvLine[index] == one) count++;
                }
                Console.WriteLine($"{one} {count}");
            }
        }
    }
}
