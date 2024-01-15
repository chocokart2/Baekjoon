using System;
using System.Text;

namespace no2908try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            StringBuilder reverse = new StringBuilder();
            for(int index = recvLine.Length - 1; index >= 0; --index)
            {
                reverse.Append(recvLine[index]);
            }
            int[] numbers = new int[2]
            {
                int.Parse(reverse.ToString().Split(' ')[0]),
                int.Parse(reverse.ToString().Split(' ')[1])
            };
            Console.WriteLine(Math.Max(numbers[0], numbers[1]));
        }
    }
}
