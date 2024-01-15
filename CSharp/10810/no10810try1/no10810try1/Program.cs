using System;
namespace no10810try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] baskets = new int[int.Parse(nums[0])];
            int count = int.Parse(nums[1]);
            for (int i = 0; i < count; i++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int start = int.Parse(recvLine[0]) - 1;
                int end = int.Parse(recvLine[1]);
                int content = int.Parse(recvLine[2]);
                for (int index = start; index < end; ++index)
                {
                    baskets[index] = content;
                }
            }
            Console.Write(baskets[0]);
            for (int index = 1; index < baskets.Length; ++index) Console.Write($" {baskets[index]}");
        }
    }
}
