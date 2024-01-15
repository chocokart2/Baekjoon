using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4447try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string original = Console.ReadLine();
                string recvLine = original.ToLower();
                int g = 0;
                int b = 0;

                for (int index = 0; index < recvLine.Length; ++index)
                {
                    if (recvLine[index] == 'g') g++;
                    if (recvLine[index] == 'b') b++;
                }
                Console.Write($"{original} is ");
                if (g > b) Console.WriteLine("GOOD");
                else if (g < b) Console.WriteLine("A BADDY");
                else Console.WriteLine("NEUTRAL");
            }
        }
    }
}
