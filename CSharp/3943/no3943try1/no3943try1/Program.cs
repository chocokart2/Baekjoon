using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3943try1
{
    internal class Program
    {
        static long[] dp = new long[100_001];

        static long GetNum(long value)
        {
            // dp[input]에 들어있는 값은 GetNum(input)의 리턴 값이다.

            // 데이터가 없다면 헤일스톤 수열을 진행한다.
            // ㄴ 진행하면서, 수열을 기록한다.
            // ㄴ 만약 해당하는 헤일스톤 수열에 dp에 존재하는 값이 있다면, 바로 수열의 생성을 종료한다.
            // 

            long max = value;
            while (value > 1)
            {
                if (value % 2 == 1)
                {
                    value = value * 3 + 1;
                    if (max < value) max = value;
                }
                else
                {
                    value /= 2;
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(GetNum(long.Parse(Console.ReadLine())));
            }
        }
    }
}
