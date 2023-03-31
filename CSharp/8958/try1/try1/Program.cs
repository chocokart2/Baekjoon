using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] results = new int[count];
            for(int line = 0; line < count; ++line)
            {
                string receiveLine = Console.ReadLine();
                int streak = 1;
                for(int index = 0; index < receiveLine.Length; ++index)
                {
                    if (receiveLine[index] == 'O')
                    {
                        results[line] += streak;
                        streak++;
                    }
                    else
                    {
                        streak = 1;
                    }
                }
            }
            foreach (int one in results)
            {
                Console.WriteLine(one);
            }
        }
    }
}
