using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1817try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0; // 지금까지 배송에 사용한 박스의 갯수

            string[] countAndBox = Console.ReadLine().Split(' ');

            int count = int.Parse(countAndBox[0]);
            int box = int.Parse(countAndBox[1]);
            
            if (count == 0)
            {
                Console.WriteLine(0); return;
            }

            string[] items = Console.ReadLine().Split(' ');

            int currentBox = 0;

            for (int index = 0; index < count; ++index)
            {
                int oneWeight = int.Parse(items[index]);

                if (currentBox + oneWeight > box)
                {
                    currentBox = oneWeight;
                    result++;
                }
                else currentBox += oneWeight;
            }

            if (currentBox > 0) result++;

            Console.WriteLine(result);
        }
    }
}
