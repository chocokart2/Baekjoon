using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5681try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            while (true)
            {
                int size = int.Parse(Console.ReadLine());
                if (size == 0) break;
                int sumMax = 0; // 만약, 공을 하나도 고르지 않은 경우에 점수는 0이 된다. 참가자가 얻을 수 있는 점수의 최댓값을 출력한다.
                int[] sums = new int[size];

                for (int y = 0; y < size; ++y)
                {
                    string[] nums = Console.ReadLine().Split(' ');
                    int[] nextSums = new int[nums.Length];
                    for (int x = 0; x < nums.Length; ++x)
                    {
                        int oneValue = int.Parse(nums[x]);
                        int oneSumMax = oneValue;
                        if (x > 0) // 위쪽의 왼쪽을 살핍니다.
                        {
                            oneSumMax = Math.Max(oneSumMax, oneValue + sums[x - 1]);
                        }
                        if (x < y) // 위쪽의 오른쪽을 살핍니다.
                        {
                            oneSumMax = Math.Max(oneSumMax, oneValue + sums[x]);
                        }
                        nextSums[x] = oneSumMax;
                        sumMax = Math.Max(oneSumMax, sumMax);
                    }
                    sums = nextSums;
                }

                result.Append($"{sumMax}\n");
            }


            Console.Write(result);




        }
    }
}