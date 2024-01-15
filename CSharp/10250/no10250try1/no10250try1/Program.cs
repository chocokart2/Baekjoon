using System;

namespace no10250try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int H = int.Parse(nums[0]);
                int N = int.Parse(nums[2]);
                int room = ((N % H == 0) ? H : N % H) * 100 + ((N - 1) / H) + 1;
                Console.WriteLine(room);
            }

        }
    }
}
