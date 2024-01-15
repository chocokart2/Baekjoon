using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1120try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 문자열 A의 위치를 바꿔가면서 얼마나 차이나는지 체크
            string[] words = Console.ReadLine().Split(' ');
            int delta = words[1].Length - words[0].Length;
            int result = int.MaxValue;
            for (int startIndex = 0; startIndex < delta + 1; startIndex++)
            {
                int oneResult = 0;
                for (int index = startIndex; index < startIndex + words[0].Length; index++)
                {
                    if (words[0][index - startIndex] != words[1][index]) oneResult++;
                }
                if (result > oneResult) result = oneResult;
            }
            Console.WriteLine(result);
        }
    }
}
