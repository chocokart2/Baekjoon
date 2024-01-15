using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25377try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isFound = false;
            int minTime = int.MaxValue;

            for (int i = 0; i < n; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int breadTime = int.Parse(recvLine[1]);
                
                if (breadTime >= int.Parse(recvLine[0]))
                {
                    isFound = true;
                    if (minTime > breadTime || (isFound == false)) minTime = breadTime;
                }
            }

            Console.WriteLine(isFound ? minTime : -1);
        }
    }
}
