using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9465try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int caseCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < caseCount; ++i)
            {
                int stikerCount = int.Parse(Console.ReadLine());
                int[,] value = new int[stikerCount, 2];
                int[,] maxSum = new int[stikerCount, 3];

                for (int indexY = 0; indexY < 2; ++indexY)
                {
                    string[] valueString = Console.ReadLine().Split(' ');

                    for (int indexX = 0; indexX < stikerCount; ++indexX)
                    {
                        value[indexX, indexY] = int.Parse(valueString[indexX]);
                    }
                }

                maxSum[0, 0] = value[0, 0];
                maxSum[0, 1] = value[0, 1];

                for (int index = 1; index < stikerCount; ++index)
                {
                    maxSum[index, 0] = Math.Max(maxSum[index - 1, 1] + value[index, 0], maxSum[index - 1, 2] + value[index, 0]);
                    maxSum[index, 1] = Math.Max(maxSum[index - 1, 0] + value[index, 1], maxSum[index - 1, 2] + value[index, 1]);
                    maxSum[index, 2] = Math.Max(maxSum[index - 1, 0], maxSum[index - 1, 1]);
                }

                Console.WriteLine(Math.Max(Math.Max(maxSum[stikerCount - 1, 0], maxSum[stikerCount - 1, 1]), maxSum[stikerCount - 1, 2]));
            }






        }
    }
}
