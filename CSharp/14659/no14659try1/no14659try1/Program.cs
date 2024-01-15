using System;
namespace no14659try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int max = 0;
            string[] numString = Console.ReadLine().Split(' ');
            int[] numbers = new int[numString.Length];
            for (int index = 0; index < numString.Length; ++index)
                numbers[index] = int.Parse(numString[index]);

            for (int index = 0; index < numbers.Length; ++index)
            {
                int startNum = numbers[index];
                int oneResult = 0;
                for (int indexTwo = index + 1; indexTwo < numbers.Length; ++indexTwo)
                {
                    if (numbers[indexTwo] < startNum) ++oneResult;
                    else break;
                }

                if (max < oneResult) max = oneResult;
            }

            Console.WriteLine(max);
        }
    }
}
