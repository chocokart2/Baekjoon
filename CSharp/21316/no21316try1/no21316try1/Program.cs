using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no21316try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 각 점마다 엣지의 수를 구합니다.
            // 스피카의 엣지의 수는 3개입니다.
            // 스피카에 연결된 별의 엣지의 수는 각각 1, 2, 3입니다.

            List<int>[] starsConnects = new List<int>[13];
            for (int index = 0; index < starsConnects.Length; index++)
            {
                starsConnects[index] = new List<int>();
            }
            bool[] isNotSpica = new bool[13];
            for (int i = 0; i < 12; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int[] nums = new int[]
                {
                    int.Parse(recvLine[0]),
                    int.Parse(recvLine[1])
                };

                starsConnects[nums[0]].Add(nums[1]);
                starsConnects[nums[1]].Add(nums[0]);
            }

            // spica는 3개의 별과 연결되어 있습니다.
            for (int index = 0; index < 13; ++index)
            {
                if (starsConnects[index].Count != 3)
                {
                    isNotSpica[index] = true;
                    continue;
                }
                int[] nearEdgeCount = { 1, 2, 3 };
                bool[] isExist = new bool[3];

                // 해당 별의 연결된 
                for (int subIndex = 0; subIndex < starsConnects[index].Count; ++subIndex)
                {
                    int nearStar = starsConnects[index][subIndex];

                    for (int nearEdgeCountIndex = 0; nearEdgeCountIndex < 3; ++nearEdgeCountIndex)
                    {
                        if (starsConnects[nearStar].Count == nearEdgeCount[nearEdgeCountIndex])
                        {
                            isExist[nearEdgeCountIndex] = true;
                            break;
                        }
                    }
                }
                if (isExist[0] && isExist[1] && isExist[2])
                {
                    Console.WriteLine(index);
                    return;
                }
            }
        }
    }
}
