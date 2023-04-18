using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17103try1
{
    internal class Program
    {
        static PrimeNumberFlag numsFlag = new PrimeNumberFlag(0);

        struct PrimeNumberFlag // 프라임 넘버면 해당 자리의 비트가 0이고 그렇지 않으면 해당 자리의 비트는 1입니다.
        {
            int[] data;
            public PrimeNumberFlag(int uselessArgument)
            {
                data = new int[125_000]; // 0부터 1000000까지의 소수 여부를 저장함.
                SetNotPrime(1);
            }
            public void SetNotPrime(int target) // 솟수가 아니라고 설정합니다.
            {
                //Console.WriteLine($"SetNotPrime({target}) : 호출됨");
                --target; // target - 1 => target
                data[target >> 3] |= 1 << (target & 7);
            }
            public bool IsPrime(int target)
            {
                --target;
                int temp = 1 << (target & 7);
                return (data[target >> 3] & temp).Equals(temp).Equals(false);
            }
        }
        static void GetPrimeNums()
        {
            // 모든 숫자의 프라임 넘버를 구합니다.
            int maxNumber = 1_000_000;
            for(int number = 2; number * number < maxNumber; ++number)
            {
                //Console.WriteLine($"GetPrimeNums() : 숫자 {number} 도는 중");
                if (numsFlag.IsPrime(number))
                {
                    for(int i = 2; i * number <= maxNumber; ++i)
                    {
                        numsFlag.SetNotPrime(i * number);
                    }
                }
            }
        }
        static int GetGoldbachPartition(int number)// 루프문을 돌던 중 N/2의 값을 '초과'하면 중지함
        {
            int result = 0;
            for(int num = 1; num <= number >> 1; ++num)
            {
                // 소수의 목록중 하나씩 넣어서 값이 맞는지 판단 맞을 때마다 값++함
                if (numsFlag.IsPrime(num) && numsFlag.IsPrime(number - num)) ++result;
            }
            return result;
        }
        static void Main(string[] args)
        {
            GetPrimeNums(); // 체를 통해 소수의 목록을 구함
            StringBuilder sb = new StringBuilder();

            int count = int.Parse(Console.ReadLine());
            for(int i = 0; i < count; ++i)
            {
                sb.Append($"{GetGoldbachPartition(int.Parse(Console.ReadLine()))}\n");
            }
            Console.Write(sb);// 출력
        }
    }
}
