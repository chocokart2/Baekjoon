using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float scores = 0.0f;
            int cursor = 0;

            string recvLine = Console.ReadLine();

            foreach (char one in recvLine)
            {
                switch (one)
                {
                    case 'A':
                        scores += 4.0f;
                        break;
                    case 'B':
                        scores += 3.0f;
                        break;
                    case 'C':
                        scores += 2.0f;
                        break;
                    case 'D':
                        scores += 1.0f;
                        break;
                    case 'F':
                        break;
                    case '+':
                        scores += 0.5f;
                        break;
                    default:
                        break;
                }

                if (one != '+') cursor++;
            }

            Console.WriteLine(scores / cursor);

        }
    }
}
