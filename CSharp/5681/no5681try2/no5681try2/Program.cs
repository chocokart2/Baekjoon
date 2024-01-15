using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5681try2
{
    internal class Program
    {
        // https://stackoverflow.com/questions/59431273/algorithmic-puzzle-ball-stacking-problem
        // 해당 문서가 어떻게 연산을 하는지 이해하고,
        // 다음 코드를 최적화하세요.

        static int[,] sums;
        static int GetSumNorthWest(int[][] array, int j, int i)
        {
            //Console.WriteLine($"GetSumNorthWest(array, {j}, {i})");
            int sum = 0;
            for (int index = 0; index < i + 1; ++index)
            {
                sum += array[j][index];
            }
            return sum;
        }

        static int GetSum(int[][] array, int i, int j)
        {
            if (i < 0 || j < 1 || i >= array[array.Length - j].Length) return 0;

            int m_northWest = sums[array.Length - j, i]; //GetSumNorthWest(array, array.Length - j, i);

            int returnValue = Math.Max(
                Math.Max(
                    GetSum(array, i - 1, j),
                    m_northWest + GetSum(array, i - 1, j - 1)),
                m_northWest + GetSum(array, i, j - 1)
                );

            //Console.WriteLine($">> {returnValue}");
            return returnValue;
        }


        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                int size = int.Parse(Console.ReadLine());
                if (size == 0) break;

                int[][] array = new int[size][];
                for (int index = 0; index < size; ++index)
                {
                    array[index] = new int[size - index];
                }

                for (int line = 0; line < size; ++line)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');
                    
                    for (int index = 0; index < recvLine.Length; ++index)
                    {
                        array[line - index][index] = int.Parse(recvLine[index]);
                    }
                }
                sums = new int[size, size];
                for (int firstIndex = 0; firstIndex < size; firstIndex++)
                {
                    for (int secondIndex = 0; secondIndex < array[firstIndex].Length; ++secondIndex)
                    {
                        //Console.WriteLine("A");
                        sums[firstIndex, secondIndex] = array[firstIndex][secondIndex];
                        if (secondIndex > 0) sums[firstIndex, secondIndex] += sums[firstIndex, secondIndex - 1];
                    }
                }
                result.Append($"{GetSum(array, size - 1, size)}\n");
            }

            Console.Write(result);
        }
    }
}
