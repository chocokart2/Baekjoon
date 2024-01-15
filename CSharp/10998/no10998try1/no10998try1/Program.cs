using System;
namespace no10998try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            Console.WriteLine(int.Parse(recvLine[0]) * int.Parse(recvLine[1]));
        }
    }
}
