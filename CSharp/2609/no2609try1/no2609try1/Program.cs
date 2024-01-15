using System;

namespace no2609try1
{
    internal class Program
    {
        static int[] GetDivisor(int target)
        {
            int[] result = new int[10_000];
            for (int i = 2; i <= target;)
            {
                if (target % i == 0)
                {
                    ++result[i];
                    target /= i;
                }
                else
                {
                    ++i;
                }
            }
            return result;
        }
        static int Pow(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; ++i) result *= a;
            return result;
        }

        static void Main(string[] args)
        {
            // 약수의 배열 구하기
            string[] nums = Console.ReadLine().Split(' ');
            int left = int.Parse(nums[0]); // left와 right는 수정될 수 있는 값입니다.
            int right = int.Parse(nums[1]);
            int[] leftDivisor = GetDivisor(left);
            int[] rightDivisor = GetDivisor(right);
            // 인덱스가 약수이고, 원소는 몇번 곱했는지에 대한 값을 가지는 배열을 추가합니다.
            int GCD = 1; // 최대공약수
            int LCM = 1; // 최소공배수

            // GCD와 LCM에 각각 leftDivisor 값을 반영합니다.
            // 그 다음 합집합은 LCM, 교집합은 GCD로 합니다.
            for (int index = 0; index < 10_000; ++index)
            {
                GCD *= Pow(index, Math.Min(leftDivisor[index], rightDivisor[index]));
                LCM *= Pow(index, Math.Max(leftDivisor[index], rightDivisor[index]));
            }
            Console.WriteLine($"{GCD}\n{LCM}");
        }
    }
}
