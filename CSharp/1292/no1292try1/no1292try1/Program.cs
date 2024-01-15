using System;

namespace no1292try1
{
    internal class Program
    {
        static int GetSum(int position)
        {
            int result = 0;
            for (int i = 1, pos = 0; ; result += i * i, pos += i, ++i)
            {
                if(position <= pos)
                {
                    result -= (pos - position) * (i - 1);
                    break;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Console.WriteLine(GetSum(int.Parse(input[1])) - GetSum(int.Parse(input[0]) - 1));
        }
    }
}
