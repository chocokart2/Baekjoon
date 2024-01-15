using System;
using System.Text;

namespace no4949try1
{
    internal class Program
    {
        static int[] stackData = new int[100];
        static int cursor = -1; // 가장 마지막에 원소가 들어간 곳의 인덱스

        static int Peek()
        {
            if (cursor == -1) return -1;
            return stackData[cursor];
        }
        static void Push(int target) // ( == 1, [ == 2
        {
            ++cursor;
            stackData[cursor] = target;
        }
        static void DeleteTop()
        {
            if (cursor == -1) return;
            cursor--;
        }


        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                string recvLine = Console.ReadLine();

                if (recvLine.Equals(".")) break;
                bool isSuccess = true;

                for (int index = 0; index < recvLine.Length; ++index)
                {
                    // (나 [를 만나면 push
                    if (recvLine[index] == '(') Push(1);
                    if (recvLine[index] == '[') Push(2);
                    if (recvLine[index] == ')')
                    {
                        if (Peek() == 1) DeleteTop();
                        else
                        {
                            isSuccess = false;
                            break;
                        }
                    }
                    if (recvLine[index] == ']')
                    {
                        if (Peek() == 2) DeleteTop();
                        else
                        {
                            isSuccess = false;
                            break;
                        }
                    }
                }

                if (cursor == -1 && isSuccess) result.AppendLine("yes");
                else result.AppendLine("no");

                cursor = -1;
            }

            Console.WriteLine(result);
        }
    }
}
