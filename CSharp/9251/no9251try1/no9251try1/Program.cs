using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9251try1
{
    internal class Program
    {
        class RandomGenerator
        {
            System.Random random;

            public RandomGenerator()
            {
                random = new System.Random();
            }

            public enum StringMode
            {
                numberAll,
                alphabetAll,
                upperAlphabet
            }
            
            public string GetRandomString(int length)
            {
                System.Text.StringBuilder stringBuilder = new StringBuilder();

                for (int index = 0; index < length; ++index)
                    stringBuilder.Append((char)('a' + random.Next(25)));
                return stringBuilder.ToString();
            }
        }

        static void Main(string[] args)
        {
            RandomGenerator rg = new RandomGenerator();

            for (int i = 0; i < 2; ++i)
                Console.WriteLine(rg.GetRandomString(20));
        }
    }
}
