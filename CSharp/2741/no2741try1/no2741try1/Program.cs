using System;
using System.Text;

namespace no2741try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < count + 1; ++i)
                result.Append($"{i}\n");
            Console.WriteLine(result);
        }
    }
}
