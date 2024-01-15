using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11945try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yLength = int.Parse(Console.ReadLine().Split(' ')[0]);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < yLength; ++i)
            {
                string recvLine = Console.ReadLine();

                for (int index = recvLine.Length - 1; index > -1; --index)
                {
                    result.Append(recvLine[index]);
                }
                result.Append('\n');
            }

            Console.Write(result);
        }
    }
}
