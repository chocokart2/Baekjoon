using System;
using System.Text;

namespace no25314try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < (number / 4); ++i) result.Append("long "); 

            result.Append("int");
            Console.WriteLine(result);
        }
    }
}
