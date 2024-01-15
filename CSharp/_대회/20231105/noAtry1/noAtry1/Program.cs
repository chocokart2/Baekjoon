using System;

namespace noAtry1
{
    internal class Program
    {
        static int GetLine()
        {
            bool blackTrigger = true; // 0 보면 반응함
            int result = 0;
            string recvLine = Console.ReadLine();

            for (int index = 0; index < recvLine.Length; index++)
            {
                if (recvLine[index] == '0') blackTrigger = true;
                else if (blackTrigger)
                {
                    blackTrigger = false;
                    result++;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Split(' ')[0]);
            int max = 0;
            int best = 0; // 만약 max가 업데이트 되면 1로 세팅

            for (int i = 0; i < count; ++i)
            {
                int one = GetLine();
                if (one > max)
                {
                    max = one;
                    best = 1;
                }
                else if (one == max)
                {
                    best++;
                }
            }
            Console.WriteLine($"{max} {best}");
        }
    }
}
