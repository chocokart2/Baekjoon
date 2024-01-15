using System;

namespace no5597try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] submitted = new bool[30];

            for (int i = 0; i < 28; ++i)
            {
                submitted[int.Parse(Console.ReadLine()) - 1] = true;
            }

            for (int index = 0; index < 30; ++index)
            {
                if (submitted[index] == false)
                    Console.WriteLine(index + 1);
            }
        }
    }
}
