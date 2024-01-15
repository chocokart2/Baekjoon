using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<ulong> squareNumbers = new HashSet<ulong>();

            for (ulong n = 1; n < 1_000_000; n++)
            {
                squareNumbers.Add((n * n));
            }

            ulong input = ulong.Parse(Console.ReadLine());

            if (squareNumbers.Contains(input))
            {
                Console.WriteLine(-1);
                return;
            }

            int result = 0;

            // is (input == A * A + B * B)?

            for (ulong i = 1; i * i <= (input >> 1); ++i)
            {
                Console.WriteLine($"squareNumbers.Contains({input - (i * i)}) = {squareNumbers.Contains(input - (i * i))}");

                if (squareNumbers.Contains(input - (i * i))) result++;
            }
            for (ulong i = 1; ; ++i)
            {
                if (squareNumbers.Contains(input + (i * i))) result++;

                ulong temp = (ulong)Math.Pow(i, 2) - (ulong)Math.Pow(i - 1, 2);
                Console.WriteLine($"{(ulong)Math.Pow(i, 2)} - {(ulong)Math.Pow(i - 1, 2)} = {temp}");
                if (temp > input) break;
            }

            Console.WriteLine(result);
        }
    }
}
