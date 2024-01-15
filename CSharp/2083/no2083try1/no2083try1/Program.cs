using System;
namespace no2083try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                if (recvLine[0].Equals("#")) break;
                Console.Write(recvLine[0]);
                if (int.Parse(recvLine[1]) < 18 && int.Parse(recvLine[2]) < 80)
                    Console.Write(" Junior\n");
                else
                    Console.Write(" Senior\n");
            }
        }
    }
}
