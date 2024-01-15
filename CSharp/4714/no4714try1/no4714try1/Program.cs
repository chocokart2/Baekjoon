using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4714try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                float weight = float.Parse(Console.ReadLine());

                if (weight < 0) break;
                Console.WriteLine("Objects weighing {0:F2} on Earth will weigh {1:F2} on the moon.", weight, weight * 0.167f);
            }

        }
    }
}
