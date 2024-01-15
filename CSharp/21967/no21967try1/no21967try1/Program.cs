using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no21967try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            // 한 점을 선택
            // 오른쪽 최대길이 / 왼쪽 최대길이를 각각 구함
            // 만약 구했으면 그것을 합한것이 해당 점에서 최대 점
            
            int maxLength = 0;
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[recvLine.Length];

            for (int index = 0; index < recvLine.Length; index++)
            {
                int one = int.Parse(recvLine[index]);
                int oneResult = 0;
                nums[index] = one;

                int max = one;
                int min = one;
                for (int rearIndex = index - 1; rearIndex >= 0; rearIndex--)
                {
                    if (nums[rearIndex] > max) max = nums[rearIndex];
                    if (nums[rearIndex] < min) min = nums[rearIndex];

                    if (max - min > 2) break;
                    oneResult = index - rearIndex + 1;
                }

                if (maxLength < oneResult) maxLength = oneResult;
            }

            Console.WriteLine(maxLength);
        }
    }
}
