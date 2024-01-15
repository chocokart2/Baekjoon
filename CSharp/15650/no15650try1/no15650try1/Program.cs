using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15650try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();

            int numRange = recvLine[0] - '0';
            int size = recvLine[2] - '0';
            bool[] isSelected = new bool[numRange + 1]; // 인덱스 넘버 0은 사용하지 않습니다. 따라서 배열의 크기는 1개 더 줍니다.
            int[] numSlot = new int[size]; // 수열을 표현하는 곳입니다.
            int backtrackLastSelectNumber = -1;
            int changeCursor = 0;

            // numSlot의 0번째 인덱스 자리에 가장 첫번째 자리를 넣음
            // 그 이후..
            // 현재 커서가 -1이라면, 루프를 빠져나간다 : for 문의 2번째 칸 루프조건문에 서술
            // 현재 커서 인덱스 == size이라면,
            // ㄴ해당 수열을 출력한다.
            // ㄴ그리고 후퇴한다. (isSelected에 해당 숫자를 false로 만들기. changeCursor인덱스가 가리키는 숫자를 백트래킹넘버에 넣고, changeCursor--, 루프 다시 돌기)
            // 만약 (맨 처음 숫자부터 마지막 숫자까지, 혹은 백트래킹 넘버 다음 숫자부터 마지막 숫자까지)다음 숫자를 고를 수 있다면(사용하지 않은 숫자: isSelected[숫자 - 1] == false)
            // ㄴ 해당 슬롯에 선택한 숫자를 넣습니다.
            // ㄴ changeCursor++
            // 만약 다음 숫자를 고를 수 없다면 후퇴합니다.

            void BackStep()
            {
                changeCursor--;

                if (changeCursor < 0) return;
                backtrackLastSelectNumber = numSlot[changeCursor];
                isSelected[backtrackLastSelectNumber] = false;
            }

            StringBuilder result = new StringBuilder();

            for (; changeCursor > -1;)
            {
                // changeCursor는 변경해야 할 커서입니다. 빈 공간을 참조하고 있습니다.

                // numSlot의 가장 첫번째 자리를 선택 
                if (changeCursor == size)
                {
                    BackStep();
                    result.Append(numSlot[0]);
                    for (int index = 1; index < numSlot.Length; ++index)
                        result.Append($" {numSlot[index]}");
                    result.Append('\n');
                    continue;
                }
                
                int nextNum = -1;
                for (int selectingNumber = (backtrackLastSelectNumber == -1) ? 1 : backtrackLastSelectNumber + 1; selectingNumber <= numRange; ++selectingNumber)
                {
                    if (isSelected[selectingNumber]) continue;
                    nextNum = selectingNumber;
                    break;
                }

                if (nextNum == -1)
                {
                    BackStep();
                    continue;
                }
                else
                {
                    backtrackLastSelectNumber = nextNum;
                    
                    isSelected[nextNum] = true;
                    numSlot[changeCursor] = nextNum;
                    changeCursor++;
                }
            }

            Console.Write(result);
        }
    }
}
