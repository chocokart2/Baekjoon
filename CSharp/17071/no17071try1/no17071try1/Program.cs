using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17071try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 턴수 (0에서 시작)
            // 수빈의 좌표들
            // 동생의 좌표

            // 현재 수빈의 좌표와 동생의 좌표중 같은 값이 있는지 체크
            // 만약 동일한 값이 있다면 즉시 현재 턴 수를 출력하고 종료
            //
            // 현재 동생 좌표 + 현재 턴 수 + 1 = 다음 턴의 동생의 좌표.
            // 만약 동생의 좌표가 50만 초과라면 즉시 -1을 출력하고 종료.
            //
            // 수빈의 좌표 배열의 각각의 수마다 -1 +1 *2를 시행하여 다음 턴의 수빈의 좌표에 삽입
            string[] nums = Console.ReadLine().Split(' ');
            int hunterStartPos = int.Parse(nums[0]); // 4바이트
            HashSet<int> hunterPos = new HashSet<int>(); // 알수 없지만 일단 최대 500_001 * 4바이트
            hunterPos.Add(hunterStartPos);
            bool[] hunterPosTable = new bool[500_001];
            hunterPosTable[hunterStartPos] = true;

            int preyPos = int.Parse(nums[1]);
            int time = 0;
            const int BEGIN = 0;
            const int END = 500_000;
            int result = -1;

            while (true)
            {
                if (hunterPosTable[preyPos] == true)
                {
                    result = time;
                    break;
                }
                //if (hunterPos.Contains(preyPos))
                //{
                //    result = time;
                //    break;
                //}

                preyPos += 1 + time;
                if (preyPos > END)
                {
                    break;
                }

                bool[] nextPosTable = new bool[500_001];
                for (int pos = 0; pos < 500_001; ++pos)
                {
                    if (hunterPosTable[pos] == false) continue;

                    if (pos - 1 >= BEGIN) nextPosTable[pos - 1] = true;
                    if (pos + 1 <= END) nextPosTable[pos + 1] = true;
                    if ((pos << 1) <= END) nextPosTable[(pos << 1)] = true;
                }
                hunterPosTable = nextPosTable;

                //int[] currentPos = hunterPos.ToArray();
                //hunterPos = new HashSet<int>();
                //for (int index = 0; index < currentPos.Length; ++index)
                //{
                //    int one = currentPos[index];

                //    if (one - 1 >= BEGIN) hunterPos.Add(one - 1);
                //    if (one + 1 <= END) hunterPos.Add(one + 1);
                //    if ((one << 1) <= END) hunterPos.Add((one << 1));
                //}

                ++time;
            }

            Console.WriteLine(result);

        }
    }
}
