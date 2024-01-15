using System;

namespace no9063try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxX = int.MinValue;
            int maxY = int.MinValue;
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int count = int.Parse(Console.ReadLine());

            for(int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int x = int.Parse(recvLine[0]);
                int y = int.Parse(recvLine[1]);

                if (maxX < x) maxX = x;
                if (maxY < y) maxY = y;
                if (minX > x) minX = x;
                if (minY > y) minY = y;
            }

            Console.WriteLine((maxX - minX) * (maxY - minY));
        }
    }
}
