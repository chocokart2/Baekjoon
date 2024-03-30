using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9079try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder answer = new StringBuilder();



            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                int stackSize = 0;
                int max = 0;
                string recvLine = Console.ReadLine();

                for (int index = 0; index < recvLine.Length; ++index)
                {
                    if (recvLine[index] == '[') stackSize++;
                    else stackSize--;

                    if (stackSize > max) max = stackSize;
                }

                answer.AppendLine((1 << max).ToString());
            }

            Console.WriteLine(answer.ToString());
        }
    }
}
