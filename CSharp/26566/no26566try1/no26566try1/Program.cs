using System;

namespace no26566try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] recvLine1 = Console.ReadLine().Split(' ');
                double amountPerDollar1 = double.Parse(recvLine1[0]) / double.Parse(recvLine1[1]);
                string[] recvLine2 = Console.ReadLine().Split(' ');
                double radius = double.Parse(recvLine2[0]);
                double amountPerDollar2 = (radius * radius * Math.PI) / double.Parse(recvLine2[1]);
                Console.WriteLine((amountPerDollar1 > amountPerDollar2) ? "Slice of pizza" : "Whole pizza");
            }

        }
    }
}
