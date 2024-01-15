using System;

namespace no2566try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int col = 1; // 몇번째 줄에 있는가?
            int max = -1;
            int x = 0;
            int y = 0;

            for (int col = 1; col <= 9; ++col)
            {
                string[] nums = Console.ReadLine().Split(' ');
                
                for (int index = 0; index < 9; ++index)
                {
                    int one = int.Parse(nums[index]);
                    if (max < one)
                    {
                        max = one;
                        y = col;
                        x = index + 1;
                    }
                }
            }

            Console.WriteLine($"{max}\n{y} {x}");
        }
    }
}
