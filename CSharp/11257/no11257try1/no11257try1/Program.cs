using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11257try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strategyScore = 35 * 3 / 10;
            int managementScore = 25 * 3 / 10;
            int technologyScore = 40 * 3 / 10;

            int count = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split();

                int[] scores = new int[]
                {
                    int.Parse(recvLine[1]),
                    int.Parse(recvLine[2]),
                    int.Parse(recvLine[3]),
                    0
                };
                scores[3] = scores[0] + scores[1] + scores[2];

                bool result =
                    (scores[3] >= 55) &&
                    (scores[0] > strategyScore) &&
                    (scores[1] > managementScore) &&
                    (scores[2] >= technologyScore);

                Console.WriteLine($"{recvLine[0]} {scores[3]} {(result ? "PASS" : "FAIL")}");
            }

        }
    }
}
