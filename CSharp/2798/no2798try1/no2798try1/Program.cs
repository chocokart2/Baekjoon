using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2798try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int target = int.Parse(recvLine[1]);
            string[] rawNumbers = Console.ReadLine().Split(' ');
            int[] numbers = new int[rawNumbers.Length];
            for (int index = 0; index < rawNumbers.Length; ++index)
                numbers[index] = int.Parse(rawNumbers[index]);

            int closestSum = 0;
            for (int index1 = 0; index1 < numbers.Length - 2; ++index1)
                for (int index2 = index1 + 1; index2 < numbers.Length - 1; ++index2)
                    for (int index3 = index2 + 1; index3 < numbers.Length; ++index3)
                    {
                        // (수정 필요) 합이 M을 넘지 않는 카드 3장을 찾을 수 있는 경우만 입력으로 주어진다.
                        int sum = numbers[index1] + numbers[index2] + numbers[index3];
                        if (sum <= target && closestSum < sum) closestSum = sum;
                    }
            Console.WriteLine(closestSum);
        }
    }
}
