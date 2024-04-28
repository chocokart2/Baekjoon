using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1914try1
{
    internal class Program
    {
        class BigNumPositive
        {
            List<byte> data; // 1의 자리 수의 인덱스는 0이고, 10의 자리수의 인덱스는 1입니다.
            public BigNumPositive() { data = new List<byte>(); }
            public BigNumPositive(string num) : this()
            {
                for (int index = num.Length - 1; index >= 0; --index)
                {
                    data.Add((byte)(num[index] - '0'));
                }
            }
            public BigNumPositive(int num) : this()
            {
                int offset = 10;
                int prevOffset = 1;
                for (int index = 0; num > 0; index++)
                {
                    int one = num % offset;
                    data.Add((byte)(one / prevOffset));
                    num -= one;
                    offset *= 10;
                    prevOffset *= 10;
                }
            }
            public override string ToString()
            {
                System.Text.StringBuilder buffer = new System.Text.StringBuilder();
                for (int index = data.Count - 1; index >= 0; --index)
                {
                    buffer.Append(data[index]);
                }
                return buffer.ToString();
            }
            public static BigNumPositive Plus(BigNumPositive left, BigNumPositive right)
            {
                BigNumPositive result = new BigNumPositive();

                int index = 0;
                for (; index < Math.Max(left.data.Count, right.data.Count); ++index)
                {
                    if (index >= result.data.Count)
                    {
                        result.data.Add(0);
                    }
                    if (index < left.data.Count)
                    {
                        result.data[index] += left.data[index];
                    }
                    if (index < right.data.Count)
                    {
                        result.data[index] += right.data[index];
                    }
                    if (result.data[index] > 9)
                    {
                        result.data[index] -= 10;
                        result.data.Add(1);
                    }
                }
                return result;
            }
        }
        
        static bool isPrint = false;
        static StringBuilder answer = new StringBuilder();
        static BigNumPositive GetMove(int N, int start, int destination, int temp)
        {
            BigNumPositive result = new BigNumPositive("1");
            if (N > 1) result = BigNumPositive.Plus(result, GetMove(N - 1, start, temp, destination));
            answer.Append($"{start} {destination}\n");
            if (N > 1) result = BigNumPositive.Plus(result, GetMove(N - 1, temp, destination, start));
            return result;
        }


        static void Main(string[] args)
        {

            BigNumPositive numAnswer = new BigNumPositive("1");
            BigNumPositive offset = new BigNumPositive("2");
            
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size - 1; ++i)
            {
                numAnswer = BigNumPositive.Plus(numAnswer, offset);
                offset = BigNumPositive.Plus(offset, offset);
            }
            Console.WriteLine(numAnswer.ToString());

            isPrint = size <= 20;
            if (isPrint)
            {
                GetMove(size, 1, 3, 2);
                Console.Write(answer);

            }

        }
    }
}
