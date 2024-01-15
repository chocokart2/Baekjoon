using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17350try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                if (Console.ReadLine().Equals("anj"))
                {
                    Console.WriteLine("뭐야;");
                    return;
                }
            }
            Console.WriteLine("뭐야?");
        }
    }
}
