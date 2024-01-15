using System;

namespace no10156try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] num = Console.ReadLine().Split(' ');
            int result = int.Parse(num[0]) * int.Parse(num[1]) - int.Parse(num[2]);
            result = result > 0 ? result : 0;
            Console.WriteLine(result);
        }
    }
}
