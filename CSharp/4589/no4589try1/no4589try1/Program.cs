using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4589try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Gnomes:");
            for (int group = 0; group < count; ++group)
            {
                string[] recvLine = Console.ReadLine().Split();
                int left = int.Parse(recvLine[0]);
                int middle = int.Parse(recvLine[1]);
                int right = int.Parse(recvLine[2]);

                string resultOne = "Ordered";
                if ((Math.Max(left, right) < middle) || (Math.Min(left, right) > middle)) resultOne = "Unordered";
                Console.WriteLine(resultOne);
            }
        }
    }
}
