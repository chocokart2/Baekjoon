using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20205try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string[] nums = Console.ReadLine().Split(' ');
            int lineCount = int.Parse(nums[0]);
            int size = int.Parse(nums[1]);

            for (int y = 0; y < lineCount; y++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                StringBuilder singleLine = new StringBuilder();
                for (int index = 0; index < recvLine.Length; index++)
                {
                    for (int repeat = 0; repeat < size; ++repeat)
                    {
                        singleLine.Append($"{recvLine[index]} ");
                    }
                }
                singleLine.Remove(singleLine.Length - 1, 1);
                for (int repeat = 0; repeat < size; ++repeat)
                {
                    result.AppendLine(singleLine.ToString());
                }
            }
            Console.Write(result);
        }
    }
}
