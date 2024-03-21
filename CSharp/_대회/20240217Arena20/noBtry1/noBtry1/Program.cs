using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 3가지 상태가 있음
            // 순수
            // 착신 전환 - 스트링
            // 착신전환 - 루프
            // 이중에 순수한 것을 선택하여, 아무 착신 전환된 전화기에 연결하면 끝

            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[recvLine.Length];
            for (int index = 0; index < recvLine.Length; index++)
            {
                nums[index] = int.Parse(recvLine[index]);
            }
            int firstChaksin = -1;
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] - 1 != index)
                {
                    firstChaksin = index;
                    break;
                }
            }
            int result = 0;
            if (firstChaksin < 0)
            {
                firstChaksin = 0;
                nums[0] = recvLine.Length;
                result++;
            }
            for (int index = 0; index < nums.Length; ++index)
            {
                if (nums[index] - 1 == index)
                {
                    nums[index] = firstChaksin + 1;
                    result++;
                }
            }
            StringBuilder print = new StringBuilder();
            print.AppendLine($"{result}");
            for (int index = 0; index < nums.Length; ++index)
            {
                print.Append($"{nums[index]} ");
            }
            Console.WriteLine(print);
        }
    }
}
