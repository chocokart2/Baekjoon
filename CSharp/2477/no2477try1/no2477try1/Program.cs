using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2477try1
{
    internal class Program
    {
        static int GetPrevIndex(int index) => (index == 0) ? 5 : index - 1;
        static int GetNextIndex(int index) => (index == 5) ? 0 : index + 1;

        static int GetMaxIndex(int[] size)
        {
            int maxIndex = 0;
            for (int index = 1; index < 6; ++index)
            {
                if (size[index] > size[maxIndex]) maxIndex = index;
            }
            return maxIndex;
        }

        static void Main(string[] args)
        {
            int[] length = new int[6];

            int melonPerBlock = int.Parse(Console.ReadLine());

            for (int index = 0; index < 6; ++index)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                length[index] = int.Parse(recvLine[1]);
            }

            int aLengthIndex = GetMaxIndex(new int[] { 0, length[1], 0, length[3], 0, length[5] });
            int bLengthIndex = GetMaxIndex(new int[] { length[0], 0, length[2], 0, length[4], 0 });

            bool isAIndexHead = GetPrevIndex(aLengthIndex) == bLengthIndex;
            int head = isAIndexHead ? aLengthIndex : bLengthIndex;
            int tail = isAIndexHead ? bLengthIndex : aLengthIndex;

            int minusXIndex = GetNextIndex(GetNextIndex(head));
            int minusYIndex = GetPrevIndex(GetPrevIndex(tail));

            int result = melonPerBlock * (length[head] * length[tail] - length[minusXIndex] * length[minusYIndex]);
            Console.WriteLine(result);
        }
    }
}
