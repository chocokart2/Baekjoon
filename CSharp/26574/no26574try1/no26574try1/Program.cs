using System;
using System.Text;

namespace no26574try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string number = Console.ReadLine();
                result.AppendLine($"{number} {number}");
            }
            Console.Write(result);
        }
    }
}
