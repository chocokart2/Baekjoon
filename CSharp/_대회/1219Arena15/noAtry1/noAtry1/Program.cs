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
            string[] size = Console.ReadLine().Split(' ');
            int count = int.Parse(size[0]);
            int people = int.Parse(size[1]) / 2;
            int result = 0;

            for (int i = 0; i < count; ++i)
            {
                string line = Console.ReadLine();
                int a = 0;
                for (int index = 0; index < line.Length; ++index)
                {
                    if (line[index] == 'O')
                    {
                        a++;
                    }
                }
                if (a > people) result++;
            }
            Console.WriteLine(result);
        }
    }
}
