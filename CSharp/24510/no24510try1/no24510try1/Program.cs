using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace no24510try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                string recvLine = Console.ReadLine();
                int one = 0;
                for (int index = 0; index < recvLine.Length - 2; ++index)
                {
                    if (recvLine[index] == 'f' &&
                        recvLine[index + 1] == 'o' &&
                        recvLine[index + 2] == 'r') one++;
                }
                for (int index = 0; index < recvLine.Length - 4; ++index)
                {
                    if (recvLine[index] == 'w' &&
                        recvLine[index + 1] == 'h' &&
                        recvLine[index + 2] == 'i' &&
                        recvLine[index + 3] == 'l' &&
                        recvLine[index + 4] == 'e') one++;
                }
                max = Math.Max(max, one);
            }
            Console.WriteLine(max);
        }
    }
}
