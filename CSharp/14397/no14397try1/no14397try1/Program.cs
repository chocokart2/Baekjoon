using System;

namespace no14397try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int N = int.Parse(nums[0]);
            int M = int.Parse(nums[1]);
            int result = 0;

            string prevLine = "";
            // 1줄씩 읽음 => 가로 관계와 이전 줄 관계 체크

            for (int i = 0; i < N; ++i)
            {
                string currentLine = Console.ReadLine();

                // 현재 라인에서 beach가 있는지 체크
                for (int index = 1; index < M; ++index) if (currentLine[index] != currentLine[index - 1]) ++result;

                if (i == 0)
                {
                    prevLine = currentLine;
                    continue;
                }

                // 이전 줄과 현재 줄 사이의 해변 체크
                int leftShift = i & 1;// prevLine의 인덱스를 얼만큼 왼쪽으로 옮길 것인가?
                for (int index = 0; index < M; ++index)
                {
                    int upperLeft = index - 1 + leftShift;
                    int upperRight = index + leftShift;
                    if (upperLeft > -1) if (currentLine[index] != prevLine[upperLeft]) ++result;
                    if (upperRight < M) if (currentLine[index] != prevLine[upperRight]) ++result;
                }
                prevLine = currentLine;
            }

            Console.WriteLine(result);
        }
    }
}
