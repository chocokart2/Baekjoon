using System;

namespace no16430try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            Console.WriteLine($"{int.Parse(recvLine[2].ToString()) - int.Parse(recvLine[0].ToString())} {recvLine[2]}");
        }
    }
}
