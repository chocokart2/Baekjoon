using System;

namespace no5171try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine();

                if (recvLine[0] == '0' && recvLine[2] == '0') break;

                Console.WriteLine($"{recvLine[0] - '0' + recvLine[2] - '0'}");
            }


        }
    }
}
