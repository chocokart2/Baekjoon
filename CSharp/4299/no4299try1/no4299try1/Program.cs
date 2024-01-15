using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4299try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int sum = int.Parse(recvLine[0]);
            int sub = int.Parse(recvLine[1]);

            int scoreAFCWimbledon = (sum + sub) / 2;

            if ((sum + sub) % 2 != 0 || (sum - scoreAFCWimbledon < 0))
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine($"{scoreAFCWimbledon} {sum - scoreAFCWimbledon}");

            // 배고파
        }
    }
}
