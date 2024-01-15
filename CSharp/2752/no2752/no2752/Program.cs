using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2752
{
    internal class Program
    {
        static void Main(string[] args) // O(N) 알고리즘
        {
            // 목표의 위치 값
            // 살아 있는 위치 값 / 닿는데 걸리는 시간(인덱스는 인티저)
            // 뒤져버린 위치 값 : 이미 순간이동을 했거나, 앞 뒤로 걸어가버린 경우, 새로운 정보를 만들 수 없는경우 살아있는 노드 목록에서 제거

            //800.008KB + 4(int) * 4 Byte + ???(string)
            int[] alivePosition = new int[100_001];
            int rear = 0; // 가장 뒷부분에 있는 유효한 원소의 인덱스 값입니다. 수빈의 위치 값을 포함합니다.
            int head = 0; // 가장 최근에 등록된 원소의 인덱스 값입니다. 초반에 수빈의 위치 값을 포함합니다.
            int [] stepCount = new int[100_001]; // 너비 탐색 과정중 이미 그 위치의 값이 있다면 피합니다. alivePosition의 값도 true입니다.
            for (int index = 0; index < stepCount.Length; ++index) stepCount[index] = -1;

            string[] nums = Console.ReadLine().Split(' ');
            int start = int.Parse(nums[0]);
            int end = int.Parse(nums[1]);

            if (start == end)
            {
                Console.WriteLine(0);
                return;
            }

            // 초기값 저장.
            alivePosition[0] = start;
            stepCount[start] = 0;

            while ((head - rear + 1) > 0) // 살아있는 노드의 수가 있는 한
            {
                // 살아있는 노드를 POP합니다. alivePosition[rear]
                //  +1 / -1 / *2 한 값
                //  stepCount에서 이 위치의 값이 -1인지 체크 합니다.
                //      맞다면
                //          이 위치의 값을 result에 넣습니다.
                //          이 위치의 값을 살아있는 노드의 값으로 넣습니다.
                //          head 값을 갯수만큼 더 추가합니다.
                //  선택한 살아있는 노드를 버립니다. 즉 rear 값을 1만큼 늘립니다.
                // 각 노드들이 end와 같은지 체크합니다.

                int currentPos = alivePosition[rear];
                int[] candidatePos = { currentPos + 1, currentPos - 1, currentPos * 2 };

                for (int candidateIndex = 0; candidateIndex < 3; ++candidateIndex)
                {
                    if (candidatePos[candidateIndex] < 0) continue;
                    if (candidatePos[candidateIndex] > 100_000) continue;
                    if (stepCount[candidatePos[candidateIndex]] != -1) continue;
                    stepCount[candidatePos[candidateIndex]] = stepCount[currentPos] + 1;

                    if (candidatePos[candidateIndex] == end)
                    {
                        Console.WriteLine(stepCount[candidatePos[candidateIndex]]);
                        return;
                    }

                    alivePosition[head + 1] = candidatePos[candidateIndex];
                    ++head;
                }
                ++rear;
            }
        }
    }
}
