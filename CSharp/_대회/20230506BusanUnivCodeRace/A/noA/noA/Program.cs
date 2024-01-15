using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int perv = 0;
            Console.ReadLine();

            string[] towers = Console.ReadLine().Split(' ');
            for (int index = 0; index < towers.Length; ++index)
            {
                int height = int.Parse(towers[index]);
                ++result;
                if (height < perv)
                {
                    --result;
                }
                perv = height;
            }
            Console.WriteLine(result);
        }
    }
}
