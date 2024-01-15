using System;
using System.Text;
using System.IO;

namespace noAtry1
{
    internal class Program
    {
        static string GetAlter(string subject) => (subject[0] == 'b') ? "swimming" : "bowling";

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder ask = new StringBuilder();

            ask.Append("soccer");
            for (int i = 1; i < count; ++i) ask.Append(" soccer");

            Console.WriteLine(ask);

            StringBuilder result = new StringBuilder();

            string[] subject = Console.ReadLine().Split(' ');
            result.Append(GetAlter(subject[0]));
            for (int index = 1; index < count; ++index)
            {
                result.Append($" {GetAlter(subject[index])}");
            }
            Console.WriteLine(result);
        }
    }
}
