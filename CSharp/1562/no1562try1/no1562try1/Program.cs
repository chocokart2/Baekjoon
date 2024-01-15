using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1562try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            long[,,] numberOfCases = new long[10, 100, 1024];
            long limit = 1_000_000_000;
            // [lastNum, size, traces]

            int size = int.Parse(Console.ReadLine());

            for (int index = 0; index < 10; ++index)
            {
                numberOfCases[index, 0, (1 << index)] = 1;
            }

            for (int N = 0; N < 99; ++N)
            {
                for (int tracesIndex = 0; tracesIndex < 1024; ++tracesIndex)
                {
                    for (int beginNum = 0; beginNum < 9; ++beginNum)
                    {
                        numberOfCases[beginNum + 1, N + 1, tracesIndex | (1 << (beginNum + 1))]
                            += numberOfCases[beginNum, N, tracesIndex];
                        if (numberOfCases[beginNum + 1, N + 1, tracesIndex | (1 << (beginNum + 1))] > limit)
                            numberOfCases[beginNum + 1, N + 1, tracesIndex | (1 << (beginNum + 1))] %= limit;
                    }
                    for (int beginNum = 1; beginNum < 10; ++beginNum)
                    {
                        numberOfCases[beginNum - 1, N + 1, tracesIndex | (1 << (beginNum - 1))]
                            += numberOfCases[beginNum, N, tracesIndex];
                        if (numberOfCases[beginNum - 1, N + 1, tracesIndex | (1 << (beginNum - 1))] > limit)
                            numberOfCases[beginNum - 1, N + 1, tracesIndex | (1 << (beginNum - 1))] %= limit;
                    }
                }
            }

            for (int beginNum = 1; beginNum < 10; ++beginNum)
            {
                result += numberOfCases[beginNum, size - 1, (1 << 10) - 1];
                if (result > 1_000_000_000) result %= 1_000_000_000;
            }

            Console.WriteLine(result);

            //StringBuilder arrString = new StringBuilder();
            //for (int y = 0; y < 10; ++y)
            //{
            //    for (int x = 0; x < 10; ++x)
            //    {
            //        arrString.Append($"{numberOfCases[x, y]}\t");
            //    }
            //    arrString.Append("\n");
            //}
            //arrString.Append("\n");
            //for (int y = 10; y < 100; ++y)
            //{
            //    for (int x = 0; x < 10; ++x)
            //    {
            //        arrString.Append($"{numberOfCases[x, y]}\t");
            //    }
            //    arrString.Append("\n");
            //}
            //Console.Write(arrString);
        }
    }
}
