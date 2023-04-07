using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1599try1
{
    
    internal class Program
    {
        

        /// <summary>
        ///     Minsik-lish Language Word
        /// </summary>
        private class Word : IComparable<Word>
        {
            readonly private List<int> letterCode;
            readonly private string english;
            readonly private Dictionary<string, int> letterNumberPairs = new Dictionary<string, int>()
            {
                { "a", 10 },
                { "b", 11 },
                { "k", 12 },
                { "d", 13 },
                { "e", 14 },
                { "g", 15 },
                { "h", 16 },
                { "i", 17 },
                { "l", 18 },
                { "m", 19 },
                { "n", 20 },
                { "ng", 21 },
                { "o", 22 },
                { "p", 23 },
                { "r", 24 },
                { "s", 25 },
                { "t", 26 },
                { "u", 27 },
                { "w", 28 },
                { "y", 29 }
            };

            public Word(string english)
            {
                letterCode = ConvertWordsToNumbers(english);
                this.english = english;
            }

            public string Letter { get => english; }

            public static bool operator >(Word left, Word right)
            {
                return CompareIsLeftBig(left, right);
            }
            public static bool operator <(Word left, Word right)
            {
                return CompareIsLeftBig(right, left);
            }
            public int CompareTo(Word target)
            {
                if (CompareIsLeftBig(target, this)) return -1;
                else return 1;
            }

            private List<int> ConvertWordsToNumbers(string minsiklishLanguage)
            {
                List<int> result = new List<int>();
                // 쪼개는것부터 시작
                bool IsLetterN = false;
                for (int index = 0; index < minsiklishLanguage.Length; ++index)
                {
                    // n 글자가 오면 처리를 미룹니다.
                    if(IsLetterN && minsiklishLanguage[index].Equals('g'))
                    {
                        IsLetterN = false;
                        result.Add(letterNumberPairs["ng"]);
                        continue;
                    }
                    else if (IsLetterN && minsiklishLanguage[index].Equals('n'))
                    {
                        //이전의 n을 집어넣습니다.
                        result.Add(letterNumberPairs["n"]);
                        continue;
                    }
                    else if(IsLetterN)
                    {
                        result.Add(letterNumberPairs["n"]);
                        result.Add(letterNumberPairs[minsiklishLanguage[index].ToString()]);
                        IsLetterN = false;
                        continue;
                    }
                    else if (minsiklishLanguage[index].Equals('n'))
                    {
                        // 다음에 n 넣을 준비
                        IsLetterN = true;
                        continue;
                    }
                    else
                    {
                        result.Add(letterNumberPairs[minsiklishLanguage[index].ToString()]);
                        continue;
                    }
                }
                if (minsiklishLanguage.EndsWith("n")) result.Add(letterNumberPairs["n"]);
                return result;
            }
            //
            // 기준 : 가장 가까운 알파벳의 순서 -> 글자가 크면 true
            private static bool CompareIsLeftBig(Word left, Word right)
            {
                int count = Math.Min(left.letterCode.Count, right.letterCode.Count);
                for(int index = 0; index < count; ++index)
                {
                    if (left.letterCode[index].Equals(right.letterCode[index])) continue;
                    return left.letterCode[index] > right.letterCode[index];
                }
                return left.letterCode.Count > right.letterCode.Count;
            }
        }
        static void Main(string[] args)
        {
            int wordCount = int.Parse(Console.ReadLine());
            Word[] words = new Word[wordCount];
            
            for(int i = 0; i < wordCount; ++i)
            {
                words[i] = new Word(Console.ReadLine());
            }
            Array.Sort(words);
            for(int i = 0; i < wordCount; ++i)
            {
                Console.WriteLine(words[i].Letter);
            }

            Console.ReadLine();
        }
    }
}
