using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2890try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int lineCount = int.Parse(nums[0]);
            int[] score = new int[9];

            for (int y = 0; y < lineCount; y++)
            {
                string recvLine = Console.ReadLine();

                for (int x = 1; x < recvLine.Length - 1; x++)
                {
                    if (recvLine[x] == '.') continue;


                    break;
                }
            }
        }
    }
}
