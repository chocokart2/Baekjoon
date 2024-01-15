using System;

namespace no27866try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recv = Console.ReadLine();
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine(recv[index - 1]);
        }
    }
}
