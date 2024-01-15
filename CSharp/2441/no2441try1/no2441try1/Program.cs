using System;
using System.Text;

namespace no2441try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i > j) result.Append(" ");
                    else result.Append("*");
                }
                result.Append("\n");
            }
            Console.Write(result);
        }
    }
}
