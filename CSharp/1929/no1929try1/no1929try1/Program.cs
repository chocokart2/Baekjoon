using System;
using System.Text;

// M이상 N이하의 소수를 모두 출력하는 프로그램을 작성하시오.
// --> 첫째 줄에 자연수 M과 N이 빈 칸을 사이에 두고 주어진다. (1 ≤ M ≤ N ≤ 1,000,000) M이상 N이하의 소수가 하나 이상 있는 입력만 주어진다.
// <-- 한 줄에 하나씩, 증가하는 순서대로 소수를 출력한다.

namespace no1929try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 종착점까지의 소수를 구합니다.
            string[] recvNumbers = Console.ReadLine().Split(' ');
            int start = int.Parse(recvNumbers[0]);
            int end = int.Parse(recvNumbers[1]);
            int squareRoot = 0;
            for (; squareRoot * squareRoot < end; ++squareRoot) ;
            int[] primeNumbersFilter = new int[squareRoot]; // element value must less then squareRoot + 1
            int primeNumberFilterIndex = 0;
            StringBuilder result = new StringBuilder();

            for(int number = 2; number <= end; ++number)
            {
                bool isPrimeNumber = true;
                // check this wheather or not prime number
                for(int index = 0; index < primeNumberFilterIndex; ++index)
                {
                    if(number % primeNumbersFilter[index] == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }
                if (isPrimeNumber == false) continue;

                if(number <= squareRoot)
                {
                    primeNumbersFilter[primeNumberFilterIndex] = number;
                    ++primeNumberFilterIndex;
                }

                if (number >= start) result.Append($"{number}\n");
            }
            Console.Write(result);
        }
    }
}
