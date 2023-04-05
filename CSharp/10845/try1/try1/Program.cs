using System;
using System.Text;
internal class Program
{
    // Fifo한 자료구조네요
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        
        int[] queue = new int[10000];
        int headIndex = -1; // pop될때 제거될 인덱스입니다.
        int tailIndex = -1; // push될때 들어간 인덱스입니다. 새롭게 들어갈 인덱스 값은 tail + 1입니다
        int length = 0;

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < count; ++i)
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "push":
                    ++tailIndex;
                    queue[tailIndex] = int.Parse(command[1]);
                    if (length.Equals(0)) headIndex = tailIndex;
                    ++length;
                    break;
                case "pop":
                    if (length.Equals(0))
                    {
                        builder.AppendLine("-1");
                    }
                    else
                    {
                        builder.AppendLine(Convert.ToString(queue[headIndex]));// 하나 출력하고 헤드를 뒷칸으로 이동
                        ++headIndex;
                        --length;
                    }
                    break;
                case "size":
                    builder.AppendLine(Convert.ToString(length));
                    break;
                case "empty":
                    if (length.Equals(0)) builder.AppendLine("1");
                    else builder.AppendLine("0");
                    break;
                case "front":
                    if (length.Equals(0)) builder.AppendLine("-1");
                    else builder.AppendLine(Convert.ToString(queue[headIndex]));
                    break;
                case "back":
                    if (length.Equals(0)) builder.AppendLine("-1");
                    else builder.AppendLine(Convert.ToString(queue[tailIndex]));
                    break;
                default:
                    break;
            }
        }
        Console.Write(builder);
    }
}