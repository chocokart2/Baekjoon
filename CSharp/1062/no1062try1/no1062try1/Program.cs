using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1062try1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int alphabetCount = int.Parse(nums[1]);
            if (alphabetCount < 5)
            {
                Console.WriteLine(0);
                return;
            }
            int count = int.Parse(nums[0]);
            string[] words = new string[count];
            int[] demandingLettersCode = new int[count]; // 읽을 수 있는 문자 코드 & 원소 의 결과가 원소와 동일하면 그 글자를 읽을 수 있음
            for (int index = 0; index < count; index++)
            {
                words[index] = Console.ReadLine();
                int one = 0;
                for (int wordIndex = 0; wordIndex < words.Length; ++wordIndex)
                {
                    one |= 1 << (words[index][wordIndex] - 'a');
                }
                demandingLettersCode[index] = one;
            }

            int knowingLetter = 0;
            int maxValue = 0;

            // a = 0, c = 2, i = 8, n = 13, t = 19
            // allowedLetter의 한 원소의 값을 넣으면 얼만큼 shift 연산을 해야 하는지 리턴한다.
            int[] allowedLetter = new int[alphabetCount - 5]; // 0부터 21까지만 가능
            int[] AL2ShiftCode = { 1, 3, 4, 5, 6, 7, 9, 10, 11, 12, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, 25 };

            while (true)
            {


            }
        }
    }
}
