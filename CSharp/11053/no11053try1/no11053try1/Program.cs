using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11053try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[] nums = new int[count];
            int[] maxLengthOfSequence = new int[count];

            // O(N*N)알고리즘 같다.
            string[] recvLine = Console.ReadLine().Split();
            for (int index = 0; index < recvLine.Length; index++)
            {
                int one = int.Parse(recvLine[index]);

                nums[index] = one;
                maxLengthOfSequence[index] = 1;
                for (int subIndex = 0; subIndex < index; subIndex++)
                {
                    if (nums[subIndex] < one && maxLengthOfSequence[subIndex] + 1 > maxLengthOfSequence[index])
                        maxLengthOfSequence[index] = maxLengthOfSequence[subIndex] + 1;
                }
            }

            int max = 0;
            for (int index = 0; index < count; ++index) if (max < maxLengthOfSequence[index]) max = maxLengthOfSequence[index];
            Console.WriteLine(max);
        }
    }
}
