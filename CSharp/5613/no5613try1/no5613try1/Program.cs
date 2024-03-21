using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5613try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            while (true)
            {
                char c = Console.ReadLine()[0];
                if (c == '=') break;

                int one = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case '+': num += one; break;
                    case '-': num -= one; break;
                    case '*': num *= one; break;
                    case '/': num /= one; break;
                    default: break;
                }
            }
            Console.WriteLine(num);
        }
    }
}
