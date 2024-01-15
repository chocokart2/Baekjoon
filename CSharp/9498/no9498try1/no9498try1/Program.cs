using System;
namespace no9498try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());
            if (score > 89) Console.Write("A");
            else if (score > 79) Console.Write("B");
            else if (score > 69) Console.Write("C");
            else if (score > 59) Console.Write("D");
            else Console.Write("F");
        }
    }
}
