using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no21966try1
{
    internal class Program
    {
        // 간단한 구현
        // 1. 만약 length가 25 이하면 그대로 출력
        // 2.1. 그 외, 머리와 꼬리 11글자를 모두 떼고 나머지 부위가 1문장이라면 ...으로 치환
        // 2.2. 나머지 부위가 2문장 이상이면 원본의 머리의 9글자를 떼고, 꼬리의 10글자를 때고 전부 ......으로 치환

        // 문자열을 받으면 중간 내용을 온점으로 생략합니다.
        static void Main(string[] args)
        {
            Console.ReadLine();
            string recvline = Console.ReadLine();

            // 얼리 리턴 패턴
            if (recvline.Length <= 25)
            {
                Console.WriteLine(recvline);
                return;
            }

            // 글자는 루프를 기반으로 진행합니다.
            int checkRangeStartIndex = 11;
            int checkRangeEndIndex = recvline.Length - 11; // 인덱스가 해당 범위에 닿으면 한 글자씩 읽는 루프에서 탈출합니다.

            // 해당 범위가 하나의 문장인가요?
            bool isSingleSentence = true;
            bool isFoundDot = false;
            
            for (int index = checkRangeStartIndex; index < checkRangeEndIndex; ++index)
            {
                // 온점을 발견하고 그 다음 글자를 발견하면 분리된 문장이라고 간주합니다.
                if (isFoundDot)
                {
                    isSingleSentence = false;
                    break;
                }

                if (recvline[index] == '.')
                {
                    isFoundDot = true;
                }
            }

            string result;

            if (isSingleSentence)
            {
                // ... 으로 생략
                result = $"{recvline.Substring(0, 11)}...{recvline.Substring(checkRangeEndIndex)}";
            }
            else
            {
                result = $"{recvline.Substring(0, 9)}......{recvline.Substring(checkRangeEndIndex + 1)}";
            }
            Console.WriteLine(result);
        }
    }
}
