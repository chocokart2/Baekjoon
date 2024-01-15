using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no30501try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            while (true)
            {
                string one = Console.ReadLine();
                for (int i = 0; i < one.Length; i++)
                {
                    if (one[i] == 'S')
                    {
                        Console.WriteLine(one);
                        return;
                    }
                }
            }
        }
    }
}
