using System;
using System.Text;

namespace no11880try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testCaseCount = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < testCaseCount; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                long x = long.Parse(recvLine[0]);
                long y = long.Parse(recvLine[1]);
                long z = long.Parse(recvLine[2]);
                long a = (y + z) * (y + z) + x * x;
                long b = (x + z) * (x + z) + y * y;
                long c = (x + y) * (x + y) + z * z;

                result.AppendLine(Math.Min(Math.Min(a, b), c).ToString());
            }
            Console.Write(result);
        }
    }
}
