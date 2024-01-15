using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1356try1
{
    internal class Program
    {
        static int GetNum(string val)
        {
            int result = 1;
            for (int index = 0;index < val.Length; index++)
            {
                result *= (val[index] - '0');
            }
            return result;
        }

        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            for (int i = 1; i < num.Length; ++i)
            {
                // 숫자를 분리하고 유진수가 맞으면 yes 하고 리턴

                string left = num.Substring(0, i);
                string right = num.Substring(i, num.Length - i);

                if (GetNum(left) == GetNum(right))
                {
                    Console.WriteLine("YES");
                    return;
                }
            }


            Console.WriteLine("NO");
        }
    }
}
