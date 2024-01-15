using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5358try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                string recvLine = Console.ReadLine();
                if (recvLine == null) break;

                for (int index = 0; index < recvLine.Length; index++)
                {
                    switch (recvLine[index])
                    {
                        case 'i':
                            result.Append('e');
                            break;
                        case 'e':
                            result.Append('i');
                            break;
                        case 'I':
                            result.Append('E');
                            break;
                        case 'E':
                            result.Append('I');
                            break;
                        default:
                            result.Append(recvLine[index]);
                            break;
                    }
                }
                result.Append('\n');
            }

            Console.Write(result);
        }
    }
}
