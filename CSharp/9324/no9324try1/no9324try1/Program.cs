using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9324try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string recvLine = Console.ReadLine();
                int[] repeatCount = new int[26];

                bool result = true;
                for (int index = 0; index < recvLine.Length; ++index)
                {
                    repeatCount[recvLine[index] - 'A']++;

                    if (repeatCount[recvLine[index] - 'A'] == 3)
                    {
                        repeatCount[recvLine[index] - 'A'] = 0;
                        if (index == recvLine.Length - 1)
                        {
                            result = false;
                            break;
                        }
                        if (recvLine[index] != recvLine[index + 1])
                        {
                            result = false;
                            break;
                        }
                        index++;
                    }
                }
                Console.WriteLine(result ? "OK" : "FAKE");

            }
        }
    }
}
