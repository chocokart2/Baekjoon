using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] levels = Console.ReadLine().Split(' ');
            StringBuilder result = new StringBuilder();

            for (int index = 0; index < levels.Length; ++index)
            {
                int one = int.Parse(levels[index]);

                int panel = 0;

                if (one == 300) panel = 1;
                else if (one >= 275) panel = 2;
                else if (one >= 250) panel = 3;
                else panel = 4;

                result.Append((index == 0) ? $"{panel}" : $" {panel}");
            }
            Console.WriteLine(result);
        }
    }
}
