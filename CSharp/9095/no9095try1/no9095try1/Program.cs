using System;
using System.Text;

namespace no9095try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // F(n) = F(n - 1) + F(n - 2) + F(n - 3)
            // 1 - 1
            // 2 - 2
            // 3 - 4
            // 4 - 7
            // 5 - 13
            // 6 - 24
            // 7 - 44
            // 8 - 81
            // 9 - 24 + 44 + 81 = 149
            // 10 - 44 + 81 + 149 = 274
            // 11 - 81 + 149 + 274 = 504

            StringBuilder result = new StringBuilder();
            int[] answer = { 0, 1, 2, 4, 7, 13, 24, 44, 81, 149, 274, 504 };
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                result.AppendLine(answer[int.Parse(Console.ReadLine())].ToString());
            }
            Console.Write(result);
        }
    }
}
