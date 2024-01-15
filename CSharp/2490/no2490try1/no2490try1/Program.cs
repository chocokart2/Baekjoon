using System;
namespace no2490try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; ++i)
            {
                int belly = 0; // 윳의 배
                string recvLine = Console.ReadLine();
                for (int index = 0; index < recvLine.Length; index += 2)
                {
                    if (recvLine[index] == '0') belly++;
                }

                switch (belly)
                {
                    case 0: Console.WriteLine("E"); break;
                    case 1: Console.WriteLine("A"); break;
                    case 2: Console.WriteLine("B"); break;
                    case 3: Console.WriteLine("C"); break;
                    case 4: Console.WriteLine("D"); break;
                    default:
                        break;
                }
            }
        }
    }
}
// 반갑습니다. C#입니다.
// 이번 문제는 상당히 어렵습니다. 골드 5는 되어야 한다고 생각합니다.
// 하여튼 문제 푸느라 수고하셨습니다.