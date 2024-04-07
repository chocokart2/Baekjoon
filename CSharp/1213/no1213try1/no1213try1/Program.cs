using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1213try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            // 반쪽 만들고, 역순으로 추가



            int[] wordCount = new int[26];
            for (int index = 0; index < recvLine.Length; ++index)
            {
                wordCount[recvLine[index] - 'A']++;
            }

            // 홀수 알파벳이 있는지 체크
            int oddWordIndex = -1;
            for (int index = 0; index < wordCount.Length; ++index)
            {
                if (wordCount[index] % 2 == 1)
                {
                    if (oddWordIndex != -1)
                    {
                        Console.WriteLine("I'm Sorry Hansoo");
                        return;
                    }
                    oddWordIndex = index;
                }
            }

            StringBuilder result = new StringBuilder();
            StringBuilder rear = new StringBuilder();
            for (char word = 'A'; word <= 'Z'; ++word)
            {
                for (int count = 0; count < wordCount[word - 'A'] / 2; ++count)
                {
                    result.Append(word);
                }
            }

            string reverse = result.ToString();
            for (int index = result.Length - 1; index >= 0; --index)
            {
                rear.Append(reverse[index]);
            }
            if (oddWordIndex != -1)
            {
                result.Append((char)('A' + oddWordIndex));
            }
            result.Append(rear.ToString());

            Console.WriteLine(result);
        }
    }
}
