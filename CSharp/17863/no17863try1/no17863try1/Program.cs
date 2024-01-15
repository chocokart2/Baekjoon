using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17863try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            recvLine = recvLine.Substring(0, 3);
            if (recvLine.Equals("555")) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
