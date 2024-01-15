using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no19944try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');

            int n = int.Parse(recvLine[0]);
            int m = int.Parse(recvLine[1]);

            if (m < 3) Console.WriteLine("NEWBIE!");
            else if (m <= n) Console.WriteLine("OLDBIE!");
            else Console.WriteLine("TLE!");
        }
    }
}
