using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9517try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lastTime = 210;
            int result = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int time = int.Parse(recvLine[0]);
                bool isNext = recvLine[1][0] == 'T';
                lastTime -= time;
                if (lastTime <= 0)
                {
                    break;
                }
                if (isNext)
                {
                    result = (result == 8) ? 1 : result + 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
