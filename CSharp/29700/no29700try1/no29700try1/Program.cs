using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no29700try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int people = int.Parse(nums[2]);
            int line = int.Parse(nums[0]);
            int result = 0;
            
            int empty;
            for (int i = 0; i < line; ++i)
            {
                empty = 0;
                string recvLine = Console.ReadLine();
                for (int index = 0; index < recvLine.Length; ++index)
                {
                    if (index >= people)
                    {
                        if (recvLine[index - people] == '0') empty--;
                    }
                    if (recvLine[index] == '0') empty++;
                    if (empty == people) result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
