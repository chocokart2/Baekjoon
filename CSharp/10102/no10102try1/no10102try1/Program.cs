using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10102try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string recvLine = Console.ReadLine();
            int a = 0;
            int b = 0
            for (int index = 0; index < recvLine.Length; ++index)
            {
                if (recvLine[index] == 'A') a++;
                else b++;
            }
            if (a > b) Console.WriteLine("A");
            else if (a < b) Console.WriteLine("B");
            else Console.WriteLine("Tie");
        }
    }
}
