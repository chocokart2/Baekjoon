using System;

namespace no2480try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(' ');
            int[] dices =
            {
                int.Parse(line[0]),
                int.Parse(line[1]),
                int.Parse(line[2])
            };

            if (dices[0].Equals(dices[1]) && dices[1].Equals(dices[2]))
            {
                Console.WriteLine($"1{line[0]}000");
                return;
            }
            else if (dices[0].Equals(dices[1]))
            {
                Console.WriteLine($"1{line[0]}00");
                return;
            }
            else if (dices[1].Equals(dices[2]))
            {
                Console.WriteLine($"1{line[1]}00");
                return;
            }
            else if (dices[2].Equals(dices[0]))
            {
                Console.WriteLine($"1{line[2]}00");
                return;
            }
            else
            {
                Console.WriteLine($"{Math.Max(Math.Max(dices[0], dices[1]), dices[2])}00");
            }
        }
    }
}
