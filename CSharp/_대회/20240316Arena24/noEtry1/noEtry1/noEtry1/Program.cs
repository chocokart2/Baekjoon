using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noEtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 모두 비긴경우
            // 전부 D여야 한다.
            // - 모든 채소가 같은 종류 => ?는 같은거
            // - 3종류의 채소가 전부 등장해야 함 => ?는 아무거나
            // 
            // 전부 D가 아닌 경우
            // 조건
            // 1. W, L는 각각 다른 채소여야 한다
            // 1.1. 잡아먹히는 판정이 있어야 한다.
            // 2. D는 존재해선 안된다.
            // 3. W와 L은 모두 존재해야 한다.

            const int MIXED = 2;
            const int D_ONLY = 1;
            const int WL_ONLY = 0;

            StringBuilder result = new StringBuilder();

            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                Console.ReadLine();
                string pay = Console.ReadLine();
                string oneResult = Console.ReadLine();

                int a = 0;
                bool foundD = false;
                bool foundW = false;
                bool foundL = false;
                for (int index = 0; index < oneResult.Length; ++index)
                {
                    if (oneResult[index] == 'D') foundD = true;
                    if (oneResult[index] == 'W') foundW = true;
                    if (oneResult[index] == 'L') foundL = true;
                }

                if (foundD == true && foundL == false && foundW == false)
                {

                }
                else if (foundD == false && foundL == true && foundW == true)
                {

                }
                else
                {
                    result.AppendLine("NO");
                    continue;
                }

            }


        }
    }
}
