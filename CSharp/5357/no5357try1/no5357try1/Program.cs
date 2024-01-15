using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5357try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char currnetChar = '?';
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string recvLine = Console.ReadLine();

                for (int index = 0; index < recvLine.Length; index++)
                {
                    if (currnetChar != recvLine[index])
                    {
                        currnetChar = recvLine[index];
                        result.Append(currnetChar);
                    }
                }
                result.Append('\n');
                currnetChar = '?';
            }
            Console.Write(result);
        }
    }
}
