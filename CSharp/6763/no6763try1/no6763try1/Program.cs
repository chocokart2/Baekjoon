using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no6763try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int over = -int.Parse(Console.ReadLine()) + int.Parse(Console.ReadLine());
            if (over > 30) Console.WriteLine("You are speeding and your fine is $500.");
            else if (over > 20) Console.WriteLine("You are speeding and your fine is $270.");
            else if (over > 0) Console.WriteLine("You are speeding and your fine is $100.");
            else Console.WriteLine("Congratulations, you are within the speed limit!");
        }
    }
}
