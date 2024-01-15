using System;
using System.Text;

namespace no2688try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 일단 브루트 포스로 풀기

            // 어떻게 풀까?
            // n이 1일때
            // (0 1 2 3 ... 8 9)
            // 10개
            // n이 2일때
            // {(00 01 02... 09) [[10개]] (11 12 13... 19) 22 23 24 ... 29 33 ... 77 78 79 88 89 99}
            // 10개 + 9개 + 8개 + ... + 3 + 2 + 1 = K
            // n이 3일 때 => n이 2일때, 옆에 숫자 하나가 더 붙음
            // [ { (000 001 002 ... 008 009) [[10개]] (011 012 ... 017 018 019) [[9개]] ... 078 079 088 089 099} 111 112 .. ]
            // (10개 + 9개 + 8개 + ... + 3 + 2 + 1) [[k]] + (9 + 8 + 7 + ... + 3 + 2 + 1) [[k - k[0]]] + (8 + 7 + 6 + 5 + .. + 3 + 2 + 1) [[ k - k[0] - k[1] ]]
            // => k * 10 - ? (? = 10 * 9 + 9 * 8 + 8 * 7 ... + 2 * 1 + 1 * 0)

            // 여기서 Y + 1개의 자릿수를 만들 때,
            // 그리고 가장 왼쪽 자리의 숫자를 X라고 할 때,
            // 그리고 남은 y개의 빈칸을 채우는 경우의 수를 f(X,Y)라고 부른다면,
            // f(0, 1) = 10, f(1, 1) = 9, f(2, 1) = 8, ... f(8, 1) = 2, f(9, 1) = 1이고,
            // f(a, b)의 값은 f()

            long[,] numOfCases = new long[10, 1_001];
            long count = long.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (long index = 0; index < 10; index++)
            {
                numOfCases[index, 1] = 10 - index;
            }
            for (long numSize = 2; numSize < 1001; numSize++)
            {
                for (long index = 0; index < 10; index++)
                {
                    for (long index2 = index; index2 < 10; index2++)
                    {
                        numOfCases[index, numSize] += numOfCases[index2, numSize - 1];
                    }
                }
            }

            for (long i = 0; i < count; ++i)
                result.AppendLine(numOfCases[0, long.Parse(Console.ReadLine())].ToString());

            Console.Write(result);
        }
    }
}
