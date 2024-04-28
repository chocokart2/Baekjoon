using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2891try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineNSR = Console.ReadLine().Split(' ');
            int teamCount = int.Parse(recvLineNSR[0]);
            
            bool[] isBroken = new bool[teamCount];
            bool[] isExtra = new bool[teamCount];

            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                isBroken[int.Parse(nums[index]) - 1] = true;
            }
            nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                isExtra[int.Parse(nums[index]) - 1] = true;
            }
            for (int index = 0; index < teamCount; ++index)
            {
                if (isBroken[index] && isExtra[index])
                {
                    isBroken[index] = false;
                    isExtra[index] = false;
                }
            }

            for (int index = 1; index < teamCount; ++index)
            {
                if (isBroken[index - 1] && isExtra[index])
                {
                    isBroken[index - 1] = false;
                    isExtra[index] = false;
                }
                if (isExtra[index - 1] && isBroken[index])
                {
                    isExtra[index - 1] = false;
                    isBroken[index] = false;
                }
            }
            int answer = 0;
            for (int index = 0; index < teamCount; ++index)
            {
                if (isBroken[index]) answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
