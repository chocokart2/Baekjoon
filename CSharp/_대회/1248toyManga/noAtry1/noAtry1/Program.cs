using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            if (recvLine.Length < 3) Console.WriteLine("CE");
            else if (recvLine[0] != '\"' || recvLine[recvLine.Length - 1] != '\"') Console.WriteLine("CE");
            else
            {
                Console.WriteLine(recvLine.Substring(1, recvLine.Length - 2));
            }
        }
    }
}
