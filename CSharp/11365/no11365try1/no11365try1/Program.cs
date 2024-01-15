using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11365try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            while (true)
            {
                string recvLine = Console.ReadLine();
                if (recvLine.Equals("END")) break;
                
                for (int index = recvLine.Length - 1; index > -1; --index)
                    result.Append(recvLine[index]);
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
