using System;

namespace no1065try1
{
    internal class Program
    {
        const int NOT_FOUND = -1;

        static int TryGetHansoo(int numCount, int startNum, int different)
        {
            int result = 0;
            for (int i = numCount; i > 0; --i)
            {
                int digit = startNum + different * (numCount - i);
                if ((digit < 0) || (9 < digit)) // 현재 자리의 숫자가 0부터 9까지의 범위를 벗어나면 NOT_FOUND를 리턴합니다.
                    return NOT_FOUND;
                result += (int)Math.Pow(10, i - 1) * digit;
            }
            if (result == 0) return NOT_FOUND;

            return result;
        }

        static void Main(string[] args)
        {
            //자릿수 개수 / 시작수 / 차수를 결정 => 한수를 생성 (0부터 9 사이의 범위를 벗어나면 or target보다 크면 continue) => 해당하는지 체크
            string recvLine = Console.ReadLine();
            int targetNumber = int.Parse(recvLine);
            int result = 0;
            for (int i = 1; i <= targetNumber && i < 10; ++i)
                ++result;
            for (int numCount = 2; numCount < recvLine.Length + 1; ++numCount)
            {
                for (int headNum = 1; headNum < 10; ++headNum)
                {
                    for (int different = -9; different < 10; ++different)
                    {
                        int hansoo = TryGetHansoo(numCount, headNum, different);
                        if (hansoo == NOT_FOUND || hansoo > targetNumber) continue;
                        ++result;
                    }
                }
            }
            Console.WriteLine(result);

        }
    }
}
