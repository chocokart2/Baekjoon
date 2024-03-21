using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no29724try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mass = 0;
            int value = 0;

            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                if (recvLine[0][0] == 'A')
                {
                    int x = int.Parse(recvLine[1]) / 12;
                    int y = int.Parse(recvLine[2]) / 12;
                    int z = int.Parse(recvLine[3]) / 12;
                    mass += x * y * z * 500 + 1000;
                    value += x * y * z * 4000;
                }
                else
                {
                    mass += 6000;
                }
            }

            Console.WriteLine(mass);
            Console.WriteLine(value);
        }
    }
}
