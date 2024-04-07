using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9291try1
{
    internal class Program
    {
        static bool Check()
        {
            int[,] slot = new int[9, 9];
            for (int y = 0; y < 9; ++y)
            {
                string recvLine = Console.ReadLine();

                for (int x = 0; x < 9; ++x)
                {
                    slot[x, y] = recvLine[x * 2] - '1';
                }
            }
            
            for (int alpha = 0; alpha < 9; ++alpha)
            {
                int colummChecksum = 0; // 세로
                int rowChecksum = 0; // 가로
                for (int beta = 0; beta < 9; ++beta)
                {
                    colummChecksum += (1 << slot[alpha, beta]);
                    rowChecksum += (1 << slot[beta, alpha]);
                }
                if (colummChecksum != (1 << 9) - 1) return false;
                if (rowChecksum != (1 << 9) - 1) return false;
            }

            for (int blockX = 0; blockX < 3; ++blockX)
            {
                for (int blockY = 0; blockY < 3; ++blockY)
                {
                    int blockChecksum = 0;

                    for (int x = 0; x < 3; ++x)
                    {
                        for (int y = 0; y < 3; ++y)
                        {
                            blockChecksum += (1 << slot[blockX * 3 + x, blockY * 3 + y]);
                        }
                    }

                    if (blockChecksum != (1 << 9) - 1) return false;
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            StringBuilder answer = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            for (int t = 1; t <= count; ++t)
            {
                Console.WriteLine($"Case {t}: {(Check() ? "CORRECT" : "INCORRECT")}");
                if (t < count) { Console.ReadLine(); }
            }
        }
    }
}
