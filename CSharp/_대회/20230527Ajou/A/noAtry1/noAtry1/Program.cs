using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        // 철자 획득
        // 글자 수 획득 > 번역 전 알파뱃 개수 기준인가, 번역 후 알파벳 기준인가?

        static void Main(string[] args)
        {
            // 변수
            StringBuilder result = new StringBuilder();
            int testCount = int.Parse(Console.ReadLine());

            // 실행

            for (int i = 0; i < testCount; ++i)
            {
                string codedLine = Console.ReadLine();
                StringBuilder decodedLine = new StringBuilder();
                
                int changedLetterCount = 0; // 바뀐 글자의 갯수입니다.

                for (int index = 0; index < codedLine.Length; ++index)
                {
                    char singleLetter = codedLine[index];

                    ++changedLetterCount;
                    switch (singleLetter)
                    {
                        case '@':
                            singleLetter = 'a';
                            break;
                        case '[':
                            singleLetter = 'c';
                            break;
                        case '!':
                            singleLetter = 'i';
                            break;
                        case ';':
                            singleLetter = 'j';
                            break;
                        case '^':
                            singleLetter = 'n';
                            break;
                        case '0':
                            singleLetter = 'o';
                            break;
                        case '7':
                            singleLetter = 't';
                            break;
                        case '\\':
                            ++index;
                            if (codedLine[index] == '\\')
                            {
                                ++index;
                                singleLetter = 'w';
                            }
                            else
                                singleLetter = 'v';
                            break;
                        default:
                            --changedLetterCount;
                            break;
                    }

                    decodedLine.Append(singleLetter);

                    if (codedLine.Length <= (changedLetterCount << 1))
                    {
                        decodedLine.Clear();
                        decodedLine.Append("I don't understand");
                    }
                }

                result.AppendLine(decodedLine.ToString());
            }


            Console.Write(result);
        }
    }
}
