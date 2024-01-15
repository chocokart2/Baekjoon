using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17388try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] contribute = new int[]
            {
                int.Parse(recvLine[0]),
                int.Parse(recvLine[1]),
                int.Parse(recvLine[2])
            };

            if (contribute[0] + contribute[1] + contribute[2] >= 100)
            {
                Console.WriteLine("OK");
            }
            else if (contribute[0] < contribute[1] && contribute[0] < contribute[2])
            {
                Console.WriteLine("Soongsil");
            }
            else if (contribute[1] < contribute[0] && contribute[1] < contribute[2])
            {
                Console.WriteLine("Korea");
            }
            else
            {
                Console.WriteLine("Hanyang");
            }

        }
    }
}
