using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27918try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int dalgu = 0;
            int phonix = 0;

            for (int i = 0; i < count; ++i)
            {
                switch (Console.ReadLine()[0])
                {
                    case 'D':
                        dalgu++;
                        break;
                    default:
                        phonix++;
                        break;
                }

                if (Math.Abs(dalgu - phonix) >= 2) break;
            }
            Console.WriteLine($"{dalgu}:{phonix}");
        }
    }
}
