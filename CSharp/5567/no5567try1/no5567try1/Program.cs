using System;

namespace no5567try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int count = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            bool[] invitedHuman = new bool[count];
            bool[,] network = new bool[count, count];

            for (int i = 0; i < m; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');

                int aIndex = int.Parse(nums[0]);
                int bIndex = int.Parse(nums[1]);

                network[aIndex - 1, bIndex - 1] = true;
                network[bIndex - 1, aIndex - 1] = true;
            }

            for (int index1 = 1; index1 < count; ++index1)
            {
                if (network[0, index1] == false) continue;
                invitedHuman[index1] = true;

                for (int index2 = 1; index2 < count; ++index2)
                {
                    if (network[index1, index2]) invitedHuman[index2] = true;
                }
            }

            for (int index = 1; index < count; ++index) if (invitedHuman[index]) ++result;

            Console.WriteLine(result);
        }
    }
}
