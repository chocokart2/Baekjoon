using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13118try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] humanPosX = new int[4];
            string[] recvLine = Console.ReadLine().Split(' ');
            for (int index = 0; index < 4; ++index)
            {
                humanPosX[index] = int.Parse(recvLine[index]);
            }
            int appleX = int.Parse(Console.ReadLine().Split(' ')[0]);

            int result = 0;
            for (int index = 0; index < 4; ++index)
            {
                if (humanPosX[index] == appleX)
                {
                    result = index + 1;
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
