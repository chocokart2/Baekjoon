using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12015try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[recvLine.Length + 1];
            for (int index = 0; index < recvLine.Length; index++)
            {
                nums[index + 1] = int.Parse(recvLine[index]);
            }
            int[] lisLongestSize = new int[nums.Length + 1];
            int[] lisSizeToMinumumLast = new int[recvLine.Length + 1];
            int result = 0;

            for (int index = 1; index < nums.Length; index++)
            {
                int one = nums[index];

                int binarySearchMin = 0;
                int binarySearchMax = result;

                while (true)
                {
                    int binarySearchMiddle = (binarySearchMin + binarySearchMax) / 2;

                    if (lisSizeToMinumumLast[binarySearchMiddle] >= one)
                    {
                        binarySearchMax = binarySearchMiddle - 1;
                        continue;
                    }
                    if (binarySearchMiddle == result)
                    {
                        lisSizeToMinumumLast[binarySearchMiddle + 1] = one;
                        lisLongestSize[index] = binarySearchMiddle + 1;
                        result++;
                        break;
                    }
                    if (lisSizeToMinumumLast[binarySearchMiddle + 1] >= one)
                    {
                        lisSizeToMinumumLast[binarySearchMiddle + 1] = one;
                        lisLongestSize[index] = binarySearchMiddle + 1;
                        break;
                    }
                    else
                    {
                        binarySearchMin = binarySearchMiddle + 1;
                        continue;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
