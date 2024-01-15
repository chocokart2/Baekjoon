using System;
using System.Text;

namespace no2742try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = num; i > 0; --i)
            {
                result.Append($"{i}\n");
            }
            Console.Write(result);
        }
    }
}
