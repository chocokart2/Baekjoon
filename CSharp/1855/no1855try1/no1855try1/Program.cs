using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1855try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int keyNum = int.Parse(Console.ReadLine());
            string anigma = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int ySize = anigma.Length / keyNum;
            char[,] matrix = new char[keyNum, ySize];
            int index = 0;
            for (int period = 0; index < anigma.Length; period++)
            {
                int y = period * 2;
                for (int x = 0; x < keyNum && index < anigma.Length; ++x)
                {
                    matrix[x, y] = anigma[index];
                    index++;
                }
                y++;
                for (int x = keyNum - 1; x >= 0 && index < anigma.Length; x--)
                {
                    matrix[x, y] = anigma[index];
                    index++;
                }
            }
            for (int x = 0; x < keyNum; x++)
            {
                for (int y = 0; y < ySize; ++y)
                {
                    result.Append(matrix[x, y]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
