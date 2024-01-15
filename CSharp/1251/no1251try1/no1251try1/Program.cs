using System;
using System.Text;

namespace no1251try1
{
    internal class Program
    {
        static string ReverseWord(string target)
        {
            StringBuilder result = new StringBuilder();
            for (int index = target.Length - 1; index >= 0; --index) result.Append(target[index]);
            return result.ToString();
        }

        static string Merge(string[] target)
        {
            return $"{target[0]}{target[1]}{target[2]}";
        }
        
        static void Main(string[] args)
        {
            string original = Console.ReadLine();
            string result = "";
            bool isResultInited = false;
            for (int secondWordBegin = 1; secondWordBegin < original.Length - 1; secondWordBegin++)
            {
                for (int thirdWordBegin = secondWordBegin + 1; thirdWordBegin < original.Length; ++thirdWordBegin)
                {
                    string one
                        = Merge(
                            new string[] {
                            ReverseWord(original.Substring(0,secondWordBegin)),
                            ReverseWord(original.Substring(secondWordBegin, thirdWordBegin - secondWordBegin)),
                            ReverseWord(original.Substring(thirdWordBegin, original.Length - thirdWordBegin))
                            });
                    if (isResultInited == false)
                    {
                        isResultInited = true;
                        result = one;
                    }
                    else if (result.CompareTo(one) > 0)
                    {
                        result = one;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
