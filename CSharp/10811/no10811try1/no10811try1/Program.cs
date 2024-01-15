using System;

namespace no10811try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] baskets = new int[int.Parse(nums[0])];
            for (int i = 0; i < baskets.Length; ++i) baskets[i] = i + 1;
            int count = int.Parse(nums[1]);

            for (int i = 0; i < count; ++i)
            {
                string[] pos = Console.ReadLine().Split(' ');
                
                for (int start = int.Parse(pos[0]) - 1, end = int.Parse(pos[1]) - 1; 
                    start < end; 
                    ++start, --end)
                {
                    int temp = baskets[start];
                    baskets[start] = baskets[end];
                    baskets[end] = temp;
                }
            }

            Console.Write(baskets[0]);
            for (int index = 1; index < baskets.Length; ++index)
            {
                Console.Write($" {baskets[index]}");
            }
        }
    }
}
