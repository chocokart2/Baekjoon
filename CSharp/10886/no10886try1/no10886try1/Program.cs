using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no10886try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int qt = 0;

            for (int i = 0; i < count; i++)
            {
                if (Console.ReadLine()[0] == '1') qt++;
            }

            if (qt > count / 2) Console.WriteLine("Junhee is cute!");
            else Console.WriteLine("Junhee is not cute!");
        }
    }
}
