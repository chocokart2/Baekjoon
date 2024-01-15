using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace no28432try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wordCount = int.Parse(Console.ReadLine());
            int blankIndex = -1;
            string[] words = new string[wordCount];
            HashSet<string> existWords = new HashSet<string>();
            for (int index = 0; index < wordCount; index++)
            {
                words[index] = Console.ReadLine();
                existWords.Add(words[index]);
                if (words[index].Equals("?"))
                {
                    blankIndex = index;
                }
            }
            int candidateCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < candidateCount; ++i)
            {
                string word = Console.ReadLine();

                if (existWords.Contains(word)) { continue; }

                bool headPass = false;
                bool tailPass = false;

                if (blankIndex == 0) headPass = true;
                else
                {
                    headPass =
                        word[0] == words[blankIndex - 1][words[blankIndex - 1].Length - 1];
                }
                if (blankIndex == wordCount - 1) tailPass = true;
                else
                {
                    tailPass =
                        word[word.Length - 1] == words[blankIndex + 1][0];
                }
                if (headPass && tailPass)
                {
                    Console.WriteLine(word);
                    break;
                }
            }
            

        }
    }
}
