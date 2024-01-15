using System;

namespace no3052try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] remainderArray = new int[42]; // 얘네들은 나눗셈 나머지를 인덱스 값으로 가집니다.
            for (int i = 0; i < 10; i++)
            {
                remainderArray[int.Parse(Console.ReadLine()) % 42] += 1;
            }
            int result = 0;
            for (int index = 0; index < 42; ++index)
            {
                if (remainderArray[index] > 0) ++result;
            }
            Console.WriteLine(result);
        }
    }
}
