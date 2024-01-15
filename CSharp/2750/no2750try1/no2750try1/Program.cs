using System;

namespace no2750try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 삽입 정렬로 해결해보자
            int count = int.Parse(Console.ReadLine());
            int[] num = new int[count];
            for (int index = 0; index < count; ++index)
                num[index] = int.Parse(Console.ReadLine());

            for (int i = 1; i < num.Length; ++i)
            {
                for (int j = i; j > 0; --j)
                {
                    if (num[j] < num[j - 1])
                    {
                        int temp = num[j];
                        num[j] = num[j - 1];
                        num[j - 1] = temp;
                    }
                }
            }

            for (int index = 0; index < count; ++index)
            {
                Console.WriteLine(num[index]);
            }
        }
    }
}
