using System;

namespace no10809try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int[] positions = new int[26];
            for (int i = 0; i < 26; i++) positions[i] = -1;

            for (int index = 0; index < word.Length; ++index)
            {
                if (positions[word[index] - 'a'] == -1) positions[word[index] - 'a'] = index;
            }

            Console.Write(positions[0]);
            for (int index = 1; index < 26; ++index) Console.Write($" {positions[index]}");
        }
    }
}
