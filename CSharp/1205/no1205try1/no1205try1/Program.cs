using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1205try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineNSP = Console.ReadLine().Split(' ');
            int score = int.Parse(recvLineNSP[1]);
            int limit = int.Parse(recvLineNSP[2]);
            int result = 1;
            int plus = 0; // 동점자가 생긴 경우에만 적용
            int lastOne = -1;

            string[] numStr = new string[0];
            if (int.Parse(recvLineNSP[0]) > 0)
            {
                numStr = Console.ReadLine().Split(' ');
            }
            
            
            for (; result <= numStr.Length; result++)
            {
                int one = int.Parse(numStr[result - 1]);
                if (one == score)
                {
                    plus++;
                }

                if (score > one)
                {
                    break;
                }

            }

            if (result > limit)
            {
                Console.WriteLine(-1);
                return;
            }
            else
            {
                Console.WriteLine(result - plus);
            }
        }
    }
}
