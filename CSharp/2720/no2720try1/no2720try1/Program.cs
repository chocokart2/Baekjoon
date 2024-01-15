using System;
using System.Text;

namespace no2720try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                int change = int.Parse(Console.ReadLine());
                int[] coin = { 0, 0, 0, 0 }; // Quarter, Dime, Nickel, Penny

                while (change >= 25)
                {
                    ++coin[0];
                    change -= 25;
                }
                while (change >= 10)
                {
                    ++coin[1];
                    change -= 10;
                }
                while (change >= 5)
                {
                    ++coin[2];
                    change -= 5;
                }
                while (change > 0)
                {
                    ++coin[3];
                    --change;
                }
                result.AppendLine($"{coin[0]} {coin[1]} {coin[2]} {coin[3]}");
            }

            Console.WriteLine(result);
        }
    }
}
