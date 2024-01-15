using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2331try1
{
    internal class Program
    {
        static int GetNext(int num, int count)
        {
            string recvLine = num.ToString();
            int result = 0;
            for (int index = 0; index < recvLine.Length; index++)
            {
                result += (int)Math.Pow((recvLine[index] - '0'), count);
            }
            return result;
        }

        static void Main(string[] args)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();
            string[] nums = Console.ReadLine().Split(' ');
            int last = int.Parse(nums[0]);
            int powCount = int.Parse(nums[1]);

            numToIndex.Add(last, 0);
            int nextIndexNum = 1;

            while (true)
            {
                int next = GetNext(last, powCount);
                if (numToIndex.ContainsKey(next))
                {
                    Console.WriteLine(numToIndex[next]);
                    break;
                }
                numToIndex.Add(next, nextIndexNum);
                last = next;
                ++nextIndexNum;
            }
        }
    }
}
