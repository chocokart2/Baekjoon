using System;

namespace no25238try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');

            Console.WriteLine((int.Parse(recvLine[0]) * (100 - int.Parse(recvLine[1])) / 100 < 100) ? 1 : 0);
        }
    }
}
