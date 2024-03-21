using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2501try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int numN = int.Parse(recvLine[0]);
            int numK = int.Parse(recvLine[1]);
            
            for (int i = 1; i <= numN; i++)
            {
                if (numN % i == 0) numK--;
                if (numK == 0)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine(0);
        }
    }
}
