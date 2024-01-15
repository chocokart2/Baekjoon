using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2503try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 해당 모르고리즘은 빅 오의 50400이브니다.
            // 123부터 시작해서 987까지의 번호의 배열을 만듭니다.
            List<string> candidate = new List<string>();
            int count = int.Parse(Console.ReadLine());

            for (int first = 1; first < 10; ++first)
            {
                for (int second = 1; second < 10; ++second)
                {
                    if (first == second) continue;

                    for (int third = 1; third < 10; ++third)
                    {
                        if (first == third || second == third) continue;
                        candidate.Add($"{first}{second}{third}");
                    }
                }
            }

            for (int i = 0; i < count; ++i)
            {
                List<string> nextList = new List<string>();
                string[] nums = Console.ReadLine().Split(' ');
                int strikes = int.Parse(nums[1]);
                int balls = int.Parse(nums[2]);
                
                // 제시 번호와 후보 번호가 스트라이크와 볼이 같으면 리스트에 남기고, 그렇지 않는다면 쳐낸다.
                for (int index = 0; index < candidate.Count; ++index)
                {
                    int candidateStrikes = 0;
                    int candidateBalls = 0;

                    for (int slotIndex = 0; slotIndex < 3; ++slotIndex)
                    {
                        if (nums[0].Contains(candidate[index][slotIndex])) candidateBalls++;
                        if (nums[0][slotIndex] == candidate[index][slotIndex])
                        {
                            candidateStrikes++;
                            candidateBalls--;
                        }
                    }

                    if (candidateStrikes == strikes && candidateBalls == balls)
                    {
                        nextList.Add(candidate[index]);
                    }
                }

                candidate = nextList;
            }

            Console.WriteLine(candidate.Count);
        }
    }
}
