using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15820try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int sampleCount = int.Parse(nums[0]);
            int systemCount = int.Parse(nums[1]);
            for (int i = 0; i < sampleCount; i++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                if (!recvLine[0].Equals(recvLine[1]))
                {
                    Console.WriteLine("Wrong Answer");
                    return;
                }
            }
            for (int i = 0; i < systemCount; i++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                if (!recvLine[0].Equals(recvLine[1]))
                {
                    Console.WriteLine("Why Wrong!!!");
                    return;
                }
            }
            Console.WriteLine("Accepted");
        }
    }
}
