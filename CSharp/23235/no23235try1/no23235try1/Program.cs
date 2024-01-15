using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no23235try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int caseNum = 1; ;caseNum++)
            {
                string recvline = Console.ReadLine();

                if (recvline[0] == '0') break;

                Console.WriteLine($"Case {caseNum}: Sorting... done!");
            }
        }
    }
}
