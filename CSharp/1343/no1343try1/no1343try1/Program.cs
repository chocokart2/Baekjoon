using System;
using System.Text;

namespace no1343try1
{
    internal class Program
    {
        static string recvLine;
        static int count;
        static StringBuilder result;

        static bool Cutting()
        {
            if (count == 1 || count == 3)
            {
                Console.WriteLine(-1);
                return true;
            }
            else if (count == 2)
            {
                result.Append("BB");
                count = 0;
            }
            result.Append('.');
            return false;
        }

        static void Main(string[] args)
        {
            recvLine = Console.ReadLine();
            count = 0;
            result = new StringBuilder();
            // 글자를 읽습니다.

            // 점에 도달햇을 때 끝에 도달했을 때 카운트를 합니다.

            for (int index = 0; index < recvLine.Length; ++index)
            {
                if (recvLine[index].Equals('X'))
                {
                    ++count;
                    if (count == 4)
                    {
                        result.Append("AAAA");
                        count = 0;
                    }
                }
                else
                {
                    if (Cutting()) return;
                }
            }
            if (Cutting()) return;
            result.Remove(result.Length - 1, 1);

            Console.WriteLine(result);
        }
    }
}
