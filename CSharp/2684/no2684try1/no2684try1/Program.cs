using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2684try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                string recvLine = Console.ReadLine();
                int[] one = new int[8];

                for (int index = 2; index < 40; ++index)
                {
                    int pattern = 0;
                    for (int delta = 0; delta < 3; ++delta)
                    {
                        if (recvLine[index - delta] == 'H')
                        {
                            pattern += (1 << delta);
                        }
                    }
                    one[pattern]++;
                }

                result.Append(one[0]);
                for (int index = 1; index < 8; ++index)
                {
                    result.Append($" {one[index]}");
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
