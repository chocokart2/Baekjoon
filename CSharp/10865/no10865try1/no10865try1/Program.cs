using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10865try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int[] friendsCount = new int[int.Parse(nums[0])];
            for (int i = int.Parse(nums[1]); i > 0; --i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                friendsCount[int.Parse(recvLine[0]) - 1]++;
                friendsCount[int.Parse(recvLine[1]) - 1]++;
            }
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < friendsCount.Length; ++index)
            {
                result.AppendLine(friendsCount[index].ToString());
            }
            Console.Write(result);
        }
    }
}
