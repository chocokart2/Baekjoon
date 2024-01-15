using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15700try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            ulong result = (ulong.Parse(recvLine[0]) * ulong.Parse(recvLine[1])) >> 1;
            Console.WriteLine(result);
        }
    }
}
