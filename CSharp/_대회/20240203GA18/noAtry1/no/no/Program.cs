using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no
{
    internal class Program
    {
        // 가장 마지막 수보다 낮거나, 현재 숫자가 마지막인 경우
        static long GetCount(long size)
        {
            long result = 0;
            for (long i = size; i > 0; i--) { result += i; }
            return result;
        }

        static void Main(string[] args)
        {
            Console.ReadLine();
            long result = 0;
            string[] recvLine = Console.ReadLine().Split(' ');

            long max = 0;
            long streak = 0;
            for (long index = 0; index < recvLine.Length; ++index)
            {
                long one = long.Parse(recvLine[index]);

                if (one > max)
                {
                    streak++;
                    max = one;
                }
                else
                {
                    result += GetCount(streak);

                    streak = 1;
                    max = one;
                }    
            }
            result += GetCount(streak);

            Console.WriteLine(result);

        }
    }
}
