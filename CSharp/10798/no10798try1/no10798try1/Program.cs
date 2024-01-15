using System;
using System.Text;

namespace no10798try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string[] lines = new string[5];
            for (int index = 0; index < 5; ++index) lines[index] = Console.ReadLine();

            for (int rowIndex = 0; rowIndex < 15; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < 5; ++columnIndex)
                {
                    if (rowIndex < lines[columnIndex].Length) result.Append(lines[columnIndex][rowIndex]);
                }
            }

            Console.WriteLine(result);
        }
    }
}
