using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1010try1
{
    internal class Program
    {
        static long GetCombination(long n, long r)
        {
            long result = 1;

            long small = Math.Min(n - r, r);
            long big = Math.Max(n - r, r);

            // 곱할 숫자
            long multipleMax = n;
            long multipleMin = big + 1;
            // 나눌 숫자
            long divideMax = small;
            long divideNum = 1; // 가장 작은 값이기도 합니다.

            //Console.WriteLine($"init : multipleMax:{multipleMax}, multipleMin:{multipleMin}, divideMax:{divideMax}, divideNum:{divideNum}");

            // (n * n-1 * n-2 * ... * n-big) / (small * small-1 * small-2 * ... * 1)
            // result에 곱할 숫자를 하나씩 곱하다가, 나누어떨어지는 나눌 숫자를 발견하면, 나눕니다. 각각의 곱하거나 나눌 숫자는 작은 숫자부터 시작하여 끝까지 합니다.
            for (long multipleNum = multipleMin; multipleNum <= multipleMax;)
            {
                if(result % divideNum == 0 && divideNum <= divideMax)
                {
                    //Console.WriteLine($"in For Loop : result:{result}, divideNum:{divideNum}, result / divideNum: {result/divideNum}");
                    result /= divideNum;
                    ++divideNum;
                }
                else
                {
                    result *= multipleNum;
                    ++multipleNum;
                }
            }
            for (; divideNum <= divideMax; ++divideNum)
                result /= divideNum;
            // 나누다가 말은 숫자를 계속해서 나눕니다.
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                long resultOne = GetCombination(long.Parse(recvLine[1]), long.Parse(recvLine[0]));
                Console.WriteLine($"{resultOne}");
            }
        }
    }
}
