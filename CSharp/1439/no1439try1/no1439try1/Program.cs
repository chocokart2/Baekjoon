using System;

namespace no1439try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int changedNum = 0;
            string recvLine = Console.ReadLine();

            for (int index = 0; index < recvLine.Length - 1; index++)
                if (recvLine[index] != recvLine[index + 1])
                    ++changedNum;

            Console.WriteLine((changedNum + 1) >> 1);
        }
    }
}


// 
// 1010 1 0101
// 101 000 101
// 10 11111 01
// 1 0000000 1
// 1 1111111 1


// 청크 : 9
// result = 4
// OneToZero = 4
// ZeroToOne = 4
// 변환 횟수 + 1 >> 1