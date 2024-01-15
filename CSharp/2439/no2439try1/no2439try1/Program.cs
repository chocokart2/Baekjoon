using System;
using System.Text;

namespace no2439try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < num; ++i)
            {
                for (int j = 0; j < num; ++j)
                {
                    if ((num - i - 1) > j) result.Append(' ');
                    else result.Append('*');
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
