using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2920_try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string received = Console.ReadLine();
            if (received.Equals("1 2 3 4 5 6 7 8")) Console.WriteLine("ascending");
            else if (received.Equals("8 7 6 5 4 3 2 1")) Console.WriteLine("descending");
            else Console.WriteLine("mixed");
        }
    }
}
