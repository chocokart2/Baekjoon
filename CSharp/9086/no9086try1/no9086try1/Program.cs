using System;
using System.Text;

namespace no9086try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string recvLine = Console.ReadLine();
                result.Append($"{recvLine[0]}{recvLine[recvLine.Length - 1]}\n");
            }
            Console.Write(result);
        }
    }
}
