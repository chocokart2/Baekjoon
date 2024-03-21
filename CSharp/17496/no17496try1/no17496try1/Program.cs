using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17496try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');

            int days = int.Parse(recvLine[0]) - 1;
            int term = int.Parse(recvLine[1]);
            int slot = int.Parse(recvLine[2]);
            int price = int.Parse(recvLine[3]);

            Console.WriteLine($"{(days / term) * slot * price}");

        }
    }
}
