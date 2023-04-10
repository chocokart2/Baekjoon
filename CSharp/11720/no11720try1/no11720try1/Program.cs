using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11720try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string numbers = Console.ReadLine();
            int result = 0;

            foreach(char one in numbers)
            {
                result += int.Parse(one.ToString());
            }
            Console.WriteLine(result);
        }
    }
}
