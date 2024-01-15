using System;
using System.Text;

namespace no10828try1
{
    internal class Program
    {
        static StringBuilder result;
        static int[] stackData;
        static int cursor = -1;

        static void mPush(int data)
        {
            ++cursor;
            stackData[cursor] = data;
        }
        static void mPop()
        {
            if (cursor == -1) result.AppendLine("-1");
            else
            {
                result.AppendLine(stackData[cursor].ToString());
                --cursor;
            }
        }
        static void mWriteSize() => result.AppendLine((cursor + 1).ToString());
        static void mCheckEmpty() => result.AppendLine((cursor == -1) ? "1" : "0");
        static void mWriteTop() => result.AppendLine((cursor == -1) ? "-1" : stackData[cursor].ToString());


        static void Main(string[] args)
        {
            result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            stackData = new int[count];

            for (int attempt = 0; attempt < count; ++attempt)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "push":
                        mPush(int.Parse(command[1]));
                        break;
                    case "pop":
                        mPop();
                        break;
                    case "size":
                        mWriteSize();
                        break;
                    case "empty":
                        mCheckEmpty();
                        break;
                    case "top":
                        mWriteTop();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
