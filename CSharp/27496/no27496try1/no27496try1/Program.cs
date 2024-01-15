using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27496try1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int result = 0;
            int lifeTime = int.Parse(Console.ReadLine().Split(' ')[1]);

            string[] recvLine = Console.ReadLine().Split(' ');
            int[] sums = new int[recvLine.Length + 1];

            for (int index = 0; index < recvLine.Length; index++)
            {
                sums[index + 1] = sums[index] + int.Parse(recvLine[index]);
            }


            for (int index = 0; index < recvLine.Length; ++index)
            {
                int one = 0;
                if (index < lifeTime)
                {
                    one = sums[index + 1];
                }
                else
                {
                    one = sums[index + 1] - sums[index + 1 - lifeTime];
                }

                if (one <= 138 && one >= 129) result++;
            }
            Console.WriteLine(result);
        }
    }
}
