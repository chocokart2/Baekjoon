using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 코드 개선할 것. 정말 더럽네. 메모리도 낭비가 심하고, 시간도 느려.
namespace no14003try1
{
    internal class Program
    {
        class NumberTrain // 자신의 이전 숫자를 기록하기 위해 존재하는 클래스입니다. 가장 긴 증가하는 부분 수열을 위해.
        {
            public int number; // 자신의 숫자.
            public NumberTrain prevNum;
        }
        // 해당 클래스는 문제 해결의 핵심입니다. 왜냐하면 prevNum은 "이전에 위치한" 숫자만을 참조하기 때문입니다.

        static void Main(string[] args)
        {
            const int MINUS_TERM = 1_000_000_001;
            int size = int.Parse(Console.ReadLine());
            string[] recvLine = Console.ReadLine().Split(' ');
            NumberTrain[] nums = new NumberTrain[recvLine.Length + 1];
            for (int index = 0; index < recvLine.Length; ++index)
            {
                nums[index + 1] = new NumberTrain()
                {
                    number = int.Parse(recvLine[index]) + MINUS_TERM
                };
            }
            int[] longestSize = new int[nums.Length + 1]; // 해당 숫자nums[index]가 가장 마지막에 올 최장 증가 수열의 길이
            NumberTrain[] lisSizeToMinimumNums = new NumberTrain[nums.Length + 1];
            lisSizeToMinimumNums[0] = new NumberTrain() { number = 0 };
            int sizeLIS = 0; // 최장 증가 부분 수열의 길이.


            for (int index = 1; index < nums.Length; ++index)
            {
                int one = nums[index].number;
                // 이진 탐색
                int m_binarySearchMin = 0;
                int m_binarySearchMaxInclude = sizeLIS;
                while (true)
                {
                    int m_middleIndex = (m_binarySearchMaxInclude + m_binarySearchMin) / 2;

                    if (lisSizeToMinimumNums[m_middleIndex].number >= one)
                    {
                        m_binarySearchMaxInclude = m_middleIndex - 1;
                        continue;
                    }

                    if (m_middleIndex == sizeLIS)
                    {
                        NumberTrain nextTrain = new NumberTrain()
                        {
                            number = one,
                            prevNum = lisSizeToMinimumNums[m_middleIndex]
                        };

                        nums[index] = nextTrain;
                        lisSizeToMinimumNums[m_middleIndex + 1] = nextTrain;

                        longestSize[index] = m_middleIndex + 1;
                        sizeLIS++;
                        break;
                    }
                    if (lisSizeToMinimumNums[m_middleIndex + 1].number >= one)
                    {
                        NumberTrain nextTrain = new NumberTrain()
                        {
                            number = one,
                            prevNum = lisSizeToMinimumNums[m_middleIndex]
                        };

                        nums[index] = nextTrain;
                        lisSizeToMinimumNums[m_middleIndex + 1] = nextTrain;
                        longestSize[index] = m_middleIndex + 1;
                        break;
                    }
                    else
                    {
                        m_binarySearchMin = m_middleIndex + 1;
                        continue;
                    }
                }
            }

            Console.WriteLine(sizeLIS);

            List<int> resultArray = new List<int>();
            NumberTrain current = lisSizeToMinimumNums[sizeLIS];
            for (int i = 0; i < sizeLIS; i++)
            {
                resultArray.Add(current.number);
                current = current.prevNum;
            }

            StringBuilder result = new StringBuilder();
            for (int index = resultArray.Count - 1; index >= 0; index--)
            {
                result.Append($"{resultArray[index] - MINUS_TERM} ");
            }

            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result);
        }
    }
}
