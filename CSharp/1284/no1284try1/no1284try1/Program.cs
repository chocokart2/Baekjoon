using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no1284try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine();
                if (recvLine.Equals("0")) break;

                int result = 1;
                for (int index = 0; index < recvLine.Length; ++index)
                {
                    switch (recvLine[index])
                    {
                        case '0': result += 5; break;
                        case '1': result += 3; break;
                        default: result += 4; break;
                    }
                }

                Console.WriteLine(result);
            }


        }
    }
}
