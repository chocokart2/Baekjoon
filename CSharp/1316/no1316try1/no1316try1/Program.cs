using System;

namespace no1316try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                bool[] characterInfo = new bool[26];
                char nowChar = ' ';
                string recvLine = Console.ReadLine();

                for (int index = 0; index < recvLine.Length; ++index)
                {
                    if (nowChar == ' ')
                    {
                        nowChar = recvLine[index];
                    }
                    else if (characterInfo[recvLine[index] - 'a'] == true) // 떨어져 나온 문자가 있는 경우
                    {
                        --result;
                        break;
                    }
                    else if (nowChar.Equals(recvLine[index]) == false) // 다른 문자가 나타난 경우
                    {
                        characterInfo[nowChar - 'a'] = true;
                        nowChar = recvLine[index];
                    }
                }
                ++result;
            }

            Console.WriteLine(result);
        }
    }
}
