using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noDtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 시뮬레이션 간다!
            // https://www.youtube.com/watch?v=_MrnPoKKYqg

            const int RED = 1;
            const int BLUE = 2;

            int line = int.Parse(Console.ReadLine());
            int remainChocolate = 0;
            int[,] chocolate = new int[line, line];

            for (int yIndex = 0; yIndex < line; ++yIndex)
            {
                string recvLine = Console.ReadLine();
                remainChocolate += recvLine.Length;
                for (int xIndex = 0; xIndex < recvLine.Length; xIndex++)
                {
                    chocolate[xIndex, yIndex] = (recvLine[xIndex] == 'R') ? RED : BLUE;
                }
            }
            
            for (int yIndex = 0; yIndex < line - 1; ++yIndex)
            {
                for (int xIndex = 0; xIndex < line - 1; ++xIndex)
                {
                    if (chocolate[xIndex, yIndex] == RED &&
                        chocolate[xIndex, yIndex + 1] == RED &&
                        chocolate[xIndex + 1, yIndex + 1] == RED
                        )
                    {
                        chocolate[xIndex, yIndex] = 0;
                        chocolate[xIndex, yIndex + 1] = 0;
                        chocolate[xIndex + 1, yIndex + 1] = 0;
                        remainChocolate -= 3;
                    }
                    if (chocolate[xIndex, yIndex] == BLUE &&
                        chocolate[xIndex + 1, yIndex] == BLUE &&
                        chocolate[xIndex + 1, yIndex + 1] == BLUE
                        )
                    {
                        chocolate[xIndex, yIndex] = 0;
                        chocolate[xIndex + 1, yIndex] = 0;
                        chocolate[xIndex + 1, yIndex + 1] = 0;
                        remainChocolate -= 3;
                    }
                }
            }

            if (remainChocolate > 0) Console.WriteLine(0);
            else Console.WriteLine(1);

        }
    }
}
