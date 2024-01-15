using System;
using System.Text;

namespace no2440try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = count; i > 0; --i)
            {
                for (int j = 0; j < i; ++j)
                    result.Append('*');
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
