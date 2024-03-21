using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1681try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int count = int.Parse(recvLine[0]);
            
            for (int num = 1; count > 0; ++num)
            {
                string one = num.ToString();
                bool isFountL = false;
                for (int index = 0; index < one.Length; ++index)
                {
                    if (one[index] == recvLine[1][0])
                    {
                        isFountL = true;
                        break;
                    }
                }

                if (!isFountL)
                {
                    count--;
                }
                if (count == 0)
                {
                    Console.WriteLine(num);
                    break;
                }
            }


        }
    }
}
