using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3765try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine();
                if (recvLine == null) break;

                Console.WriteLine(recvLine);
            }

        }
    }
}
