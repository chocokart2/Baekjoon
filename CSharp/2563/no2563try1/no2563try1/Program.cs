using System;

namespace no2563try1
{
    internal class Program
    {
        static bool[] paper = new bool[10000];

        static void Plate(int x, int y)
        {
            for (int ix = x; ix < x + 10; ++ix)
            {
                for (int iy = y; iy < y + 10; ++iy)
                {
                    paper[ix + iy * 100] = true;
                }
            }
        }

        static int GetSize()
        {
            int result = 0;

            for (int index = 0; index < 10_000; ++index)
                if (paper[index]) ++result;

            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');

                Plate(int.Parse(nums[0]), int.Parse(nums[1]));
            }

            Console.WriteLine(GetSize());
        }
    }
}
