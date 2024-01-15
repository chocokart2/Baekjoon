using System;
using System.Text;

namespace no11022try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                string[] strings = Console.ReadLine().Split(' ');
                int[] num = new int[2] { int.Parse(strings[0]), int.Parse(strings[1]) };
                result.AppendLine($"Case #{i + 1}: {num[0]} + {num[1]} = {num[0] + num[1]}");
            }
            Console.Write(result);
        }
    }
}
