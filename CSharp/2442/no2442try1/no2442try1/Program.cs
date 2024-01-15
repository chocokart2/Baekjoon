using System;
using System.Text;

namespace no2442try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                for (int j = count - 1 - i; j > 0; --j)
                {
                    result.Append(' ');
                }
                for (int j = 1; j < (i + 1) * 2; ++j)
                {
                    result.Append('*');
                }
                result.Append('\n');
            }

            Console.Write(result);
        }
    }
}
