using System;
namespace no1157try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine().ToUpper();
            int[] count = new int[26];
            int max = 0;
            int result = -1; // -1은 ?를 출력하고, max 값과 동일한 값이 있으면 -1로 회귀, 아니라면 최우선 대상 인덱스를 가집니다

            for (int index = 0; index < recvLine.Length; ++index)
            {
                count[(int)recvLine[index] - (char)'A']++;
            }
            for (int index = 0; index < count.Length; ++index)
            {
                if (count[index] == max) result = -1;
                else if (count[index] > max)
                {
                    result = index;
                    max = count[index];
                }
            }
            Console.WriteLine((result == -1) ? '?' : (char)(result + (int)'A'));
        }
    }
}
