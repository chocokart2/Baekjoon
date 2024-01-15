using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14655try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] recvNums = Console.ReadLine().Split(' ');
            int result = 0;
            for (int index = 0; index < recvNums.Length; ++index)
                result += Math.Abs(int.Parse(recvNums[index]));
            result *= 2;
            Console.WriteLine(result);
        }
    }
}
