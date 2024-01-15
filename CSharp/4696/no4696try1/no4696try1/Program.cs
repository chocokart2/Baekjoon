using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4696try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                float value = float.Parse(Console.ReadLine());

                if (value == 0f) break;

                value =
                    value * value * value * value +
                    value * value * value +
                    value * value +
                    value + 1f;

                Console.WriteLine(string.Format("{0:0.00}", value));
            }

        }
    }
}
