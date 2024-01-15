using System;
using System.Collections.Generic;

namespace no27964try1
{
    internal class Program
    {
        static bool IsCheese(string target) => target.EndsWith("Cheese");

        static void Main(string[] args)
        {
            HashSet<string> cheese = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());
            string[] ingredients = Console.ReadLine().Split(' ');

            for (int index = 0; index < count; ++index)
            {
                if (IsCheese(ingredients[index]) && cheese.Contains(ingredients[index]).Equals(false))
                {
                    cheese.Add(ingredients[index]);
                    if (cheese.Count == 4)
                    {
                        Console.WriteLine("yummy");
                        return;
                    }
                }
            }
            Console.WriteLine("sad");
        }
    }
}
