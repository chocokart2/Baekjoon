using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11005try1
{
    internal class Program
    {
        // 1. 최대 자릿수 맞추기
        // 2. 현재 자릿수에 숫자 넣고 현재 수보다 같거나 작은지 체크하기.
        // 그러면 제곱을 해서 괜찮은지 체크한다.

        static char NumToChar(long num) => (num > 9) ? (char)('A' + num - 10) : num.ToString()[0];

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            long cursor = 0; // B를 몇번 제곱했는가?
            long positionNum = 1; // N번 자릿수의 숫자는 무엇인가?

            string[] nums = Console.ReadLine().Split(' ');
            long target = long.Parse(nums[0]);
            long baseNum = long.Parse(nums[1]); // 진법을 저장합니다.

            // 가장 머릿 자리부터 만든 다음, cursor를 한칸씩 아래로 내려갑니다. 0인 부분도 포함.
            while (positionNum * baseNum <= target)
            {
                positionNum *= baseNum;
                ++cursor;
            }

            for (; cursor >= 0; --cursor)
            {
                // 해당 자리의 숫자 맞추기
                long num = target / positionNum;
                target %= positionNum;
                positionNum /= baseNum;

                result.Append(NumToChar(num)); // 매개변수에 대상 넣기;
            }

            Console.WriteLine(result);

        }
    }
}
