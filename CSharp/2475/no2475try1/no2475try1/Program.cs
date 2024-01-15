using System;

namespace no2475try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int result =
                (int)Math.Pow(int.Parse(line[0].ToString()), 2) +
                (int)Math.Pow(int.Parse(line[2].ToString()), 2) +
                (int)Math.Pow(int.Parse(line[4].ToString()), 2) +
                (int)Math.Pow(int.Parse(line[6].ToString()), 2) +
                (int)Math.Pow(int.Parse(line[8].ToString()), 2);
            Console.WriteLine(result % 10);
        }
    }
}
