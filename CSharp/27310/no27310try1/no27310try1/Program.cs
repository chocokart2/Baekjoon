using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27310try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            int result = recvLine.Length;

            for (int index = 0; index < recvLine.Length; index++)
            {
                if (recvLine[index] == '_') result += 5;
                if (recvLine[index] == ':') result += 1;
            }
            Console.WriteLine(result);
        }
    }
}
