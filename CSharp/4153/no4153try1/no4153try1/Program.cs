using System;

namespace no4153try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recv = Console.ReadLine();
                if (recv.Equals("0 0 0")) break;
                string[] recvLine = recv.Split(' ');
                int[] num = new int[3] { int.Parse(recvLine[0]), int.Parse(recvLine[1]), int.Parse(recvLine[2]) };
                int max = Math.Max(Math.Max(num[0], num[1]), num[2]);
                Console.WriteLine((num[0] * num[0] + num[1] * num[1] + num[2] * num[2] - max * max * 2).Equals(0) ? "right" : "wrong");
            }

        }
    }
}
