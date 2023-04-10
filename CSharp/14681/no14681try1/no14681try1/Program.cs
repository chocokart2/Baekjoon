using System;

namespace no14681try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            bool a = x > 0, b = y > 0;
            if (a)
            {
                if (b) Console.WriteLine(1);
                else Console.WriteLine(4);
            }
            else
            {
                if (b) Console.WriteLine(2);
                else Console.WriteLine(3);
            }
        }
    }
}
