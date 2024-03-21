using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noMtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            int s = 0;
            int i = 0;
            int a = 0;
            int result = 0;
            Console.ReadLine();
            string recvLine = Console.ReadLine();
            for (int index = 0; index < recvLine.Length; index++)
            {
                switch (recvLine[index])
                {
                    case 'C': c++; break;
                    case 'S': s++; break;
                    case 'I': i++; break;
                    case 'A': a++; break;
                    default: break;
                }
            }
            string one = Console.ReadLine();
            switch (one[0])
            {
                case 'C': Console.WriteLine(c); break;
                case 'S': Console.WriteLine(s); break;
                case 'I': Console.WriteLine(i); break;
                case 'A': Console.WriteLine(a); break;
            }
        }
    }
}
