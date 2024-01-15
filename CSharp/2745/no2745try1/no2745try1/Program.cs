using System;

namespace no2745try1
{
    internal class Program
    {
        static int ConvertToInt(char a) => int.TryParse(a.ToString(), out int result) ? result : (10 + a - 'A');
        static int Pow(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; ++i) result *= a;
            return result;
        }

        static void Main(string[] args)
        {
            int result = 0;
            string[] recvLine = Console.ReadLine().Split(' ');
            int B = int.Parse(recvLine[1]);

            for (int index = 0; index < recvLine[0].Length; ++index)
            {
                result += ConvertToInt(recvLine[0][index]) * Pow(B, recvLine[0].Length - index - 1);
            }
            Console.WriteLine(result);
        }
    }
}
