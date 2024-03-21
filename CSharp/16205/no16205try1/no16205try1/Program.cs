using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace no16205try1
{
    internal class Program
    {

        static bool IsLower(char c)
        {
            return (c >= 'a') && (c <= 'z');
        }
        static string Convert(string s)
        {
            if (s.Length < 2) return s.ToUpper();
            return $"{(IsLower(s[0]) ? (char)(s[0] - 32) : s[0])}{s.Substring(1)}";
        }
        static void Main(string[] args)
        {
            string[] words = new string[0];

            string[] recvLine = Console.ReadLine().Split(' ');
            StringBuilder oneWords = new StringBuilder();
            List<string> tempStrings = new List<string>();
            switch (recvLine[0])
            {
                case "1":
                    oneWords.Append(recvLine[1][0]);
                    for (int index = 1; index < recvLine[1].Length; ++index)
                    {
                        if (IsLower(recvLine[1][index]))
                        {
                            oneWords.Append(recvLine[1][index]);
                        }
                        else
                        {
                            tempStrings.Add(oneWords.ToString());
                            oneWords.Clear();
                            oneWords.Append(recvLine[1][index]);
                        }
                    }
                    if (oneWords.Length > 0)
                    {
                        tempStrings.Add(oneWords.ToString());
                    }
                    words = tempStrings.ToArray();
                    break;
                case "2":
                    words = recvLine[1].Split('_');
                    break;
                case "3":
                    oneWords.Append(recvLine[1][0]);
                    for (int index = 1; index < recvLine[1].Length; ++index)
                    {
                        if (IsLower(recvLine[1][index]))
                        {
                            oneWords.Append(recvLine[1][index]);
                        }
                        else
                        {
                            tempStrings.Add(oneWords.ToString());
                            oneWords.Clear();
                            oneWords.Append(recvLine[1][index]);
                        }
                    }
                    if (oneWords.Length > 0)
                    {
                        tempStrings.Add(oneWords.ToString());
                    }
                    words = tempStrings.ToArray();
                    break;
                default: break;
            }

            StringBuilder result = new StringBuilder();
            for (int index = 0; index < words.Length; ++index)
            {
                if (index == 0)
                {
                    result.Append(words[0].ToLower());
                }
                else
                {
                    result.Append(Convert(words[index]));
                }
            }
            result.Append('\n');
            for (int index = 0; index < words.Length; ++index)
            {
                if (index == 0)
                {
                    result.Append(words[0].ToLower());
                }
                else
                {
                    result.Append($"_{words[index].ToLower()}");
                }
            }
            result.Append('\n');
            for (int index = 0; index < words.Length; ++index)
            {
                result.Append(Convert(words[index]));
            }
            Console.WriteLine(result);
        }
    }
}
