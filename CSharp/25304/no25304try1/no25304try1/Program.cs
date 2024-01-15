using System;

namespace no25304try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                sum -= int.Parse(recvLine[0]) * int.Parse(recvLine[1]);
            }

            Console.WriteLine((sum == 0) ? "Yes" : "No");
        }
    }
}
