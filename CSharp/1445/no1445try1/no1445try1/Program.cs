using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1445try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int candy = int.Parse(nums[0]);
                int siblings = int.Parse(nums[1]);

                result.AppendLine($"You get {candy / siblings} piece(s) and your dad gets {candy % siblings} piece(s).");
            }

            Console.Write(result);
        }
    }
}
