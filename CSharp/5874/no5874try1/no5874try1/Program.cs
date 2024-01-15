using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5874try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // '(' => 1
            // ')' => -1
            // '😺' => +999

            string recvLine = Console.ReadLine();
            int[] sum = new int[recvLine.Length + 1];

            for (int index = 0; index < recvLine.Length; index++)
            {
                sum[index + 1] = sum[index] + (recvLine[index] == '(' ? 1 : -1);
            }
            // d < sum.length - 3
            // a~b < c~d
            int result = 0;
            for (int footIndex = 0; footIndex < sum.Length - 4; footIndex++)
            {
                if (sum[footIndex + 2] - sum[footIndex] != 2) continue;
                for (int handIndex = footIndex + 2; handIndex < sum.Length - 2; handIndex++)
                {
                    if (sum[handIndex + 2] - sum[handIndex] != -2) continue;
                    result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
