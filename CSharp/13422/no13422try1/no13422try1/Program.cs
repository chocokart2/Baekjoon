using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13422try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // N개의 집이 있으면
            // 합 배열은 2 * N + 1
            // 투 포인터의 시작 지점(X)의 범위는 [0, N - 1]까지
            // 투 포인터의 종료 지점의 범위는 [X + 1, X + N - 1]까지
            // * (구간의 종료가 X + N이면 모두를 선택하는 경우를 연산할 수 있지만 이것을 여러번 겹쳐서 다른 것으로 취급할 수 있음.)
            // * 따라서 모두를 선택하는 경우는 따로 연산함.

            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                string[] numsNMK = Console.ReadLine().Split(' ');
                int oneResult = 0;
                int theftCount = int.Parse(numsNMK[1]);
                int moneyLimit = int.Parse(numsNMK[2]);
                string[] houseSafeStr = Console.ReadLine().Split(' ');
                int[] houseSafe = new int[houseSafeStr.Length];
                int[] sums = new int[houseSafe.Length * 2 + 1];

                for (int index = 0; index < houseSafeStr.Length; index++)
                {
                    houseSafe[index] = int.Parse(houseSafeStr[index]);
                    sums[index + 1] = sums[index] + houseSafe[index];
                }
                for (int index = 0; index < houseSafe.Length; ++index)
                {
                    sums[houseSafe.Length + index + 1] = sums[houseSafe.Length + index] + houseSafe[index];
                }

                // 만약 집의 갯수와 훔칠 집의 갯수가 동일하다면 한번만 계산.
                if (theftCount == houseSafeStr.Length)
                {
                    if (sums[theftCount] < moneyLimit)
                    {
                        oneResult = 1;
                    }
                }
                else
                {
                    for (int index = 0; index < houseSafe.Length; ++index)
                    {
                        if (sums[index + theftCount] - sums[index] < moneyLimit) oneResult++;
                    }
                }
                result.AppendLine($"{oneResult}");
            }

            Console.Write(result);
        }
    }
}
