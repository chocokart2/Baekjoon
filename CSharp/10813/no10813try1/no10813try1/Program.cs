using System;

namespace no10813try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] baskets = new int[int.Parse(nums[0]) + 1];
            for (int i = 0; i < baskets.Length; i++) baskets[i] = i;
            int count = int.Parse(nums[1]);
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int[] position = new int[2] { int.Parse(recvLine[0]), int.Parse(recvLine[1]) };

                int temp = baskets[position[0]];
                baskets[position[0]] = baskets[position[1]];
                baskets[position[1]] = temp;
            }

            Console.Write(baskets[1]);
            for (int index = 2; index < baskets.Length; ++index)
                Console.Write($" {baskets[index]}");
        }
    }
}
