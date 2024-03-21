using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static class KSA // KSA는 너무 위대한 바람에 정적 클래스가 되었습니다.
        {
            static public int index = 0;
            static string word = "KSA";

            static public char Next
            {
                get => word[index];
            }

            static public void Push() => index = ((index < 2) ? index + 1 : 0);
        }

        static void Main(string[] args)
        {
            // KSA를 하나씩 체크합니다.
            //


            string words = Console.ReadLine();
            int result = int.MaxValue;
            int removed = 0;
            // SSSS => KSAK (6)

            // 채점자가 뒷목잡고 쓰러질 IQ 80짜리의 개1멍1청1한 풀이과정

            if (words.Length == 1)
            {
                switch (words[0])
                {
                    case 'K':
                        Console.WriteLine(0);
                        return;
                    default:
                        Console.WriteLine(2);
                        return;
                }
            }
            if (words.Length == 2)
            {
                switch (words)
                {
                    case "KS":
                        Console.WriteLine(0);
                        return;
                    case "AA":
                        Console.WriteLine(4);
                        return;
                    default:
                        Console.WriteLine(2);
                        return;
                }
            }
            if (words.Length == 3)
            {

            }
            if (words.Length == 4)
            {

            }
            if (words.Length == 5)
            {

            }
            if (words.Length == 6)
            {

            }
            if (words.Length == 7)
            {

            }
            if (words.Length == 8)
            {

            }
            if (words.Length == 9)
            {

            }
            if (words.Length == 10)
            {

            }
            if (words.Length == 11)
            {

            }

            for (int startKsaIndex = 0; startKsaIndex < 3; ++startKsaIndex)
            {
                int oneResult = 0;
                int oneRemoved = 0;
                KSA.index = startKsaIndex;


                for (int index = 0; index < words.Length; ++index)
                {
                    if (words[index] == KSA.Next) KSA.Push();
                    else oneRemoved++;
                }
                oneResult = startKsaIndex + Math.Max(startKsaIndex, oneRemoved) + Math.Max(0, oneRemoved - startKsaIndex);

                //Console.WriteLine($">> startKsaIndex = {startKsaIndex}, oneResult = {oneResult}");
                if (result > oneResult) result = oneResult;
            }
            Console.WriteLine(result);

            // 정말 귀여워요
            // https://www.youtube.com/watch?v=6f8jqEmDFVo
        }
    }
}
