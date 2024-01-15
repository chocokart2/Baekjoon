using System;

namespace no6550try1
{
    internal class Program
    {

        static bool IsSubsequence(string s, string t)
        {
            bool result = false;
            int indexS = 0;
            for (int indexT = 0; indexT < t.Length; ++indexT)
            {
                if (s[indexS] == t[indexT])
                {
                    if (indexS == s.Length - 1)
                    {
                        result = true;
                        break;
                    }
                    ++indexS;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine();

                if (recvLine == null) break;
                string[] strings = recvLine.Split(' ');
                if (IsSubsequence(strings[0], strings[1]))
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
        }
    }
}
