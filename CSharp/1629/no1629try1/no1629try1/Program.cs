using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1629try1
{
    internal class Program
    {
        static ulong c = 1;
        // a의 b제곱입니다.
        static ulong GetPower(ulong a, ulong b)
        {
            if (b == 0) return 1;
            if (b == 1) return a % c;
            ulong half = GetPower(a, b >> 1);
            if ((b & 1) == 1)
            {
                return (((half * half) % c) * a) % c;
            }
            return (half * half) % c;
        }


        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');

            c = ulong.Parse(recvLine[2]);
            Console.WriteLine(GetPower(ulong.Parse(recvLine[0]), ulong.Parse(recvLine[1])));
        }
    }
}