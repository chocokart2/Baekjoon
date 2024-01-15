using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2338try1
{
    internal class Program
    {
        static int GetNum(char a)
        {
            switch (a)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default: return -1;
            }
        }

        static (char num2, int pos)[] PlusOne((char num, int pos) a, (char num, int pos) b)
        {
            string nums = (GetNum(a.num) * GetNum(b.num)).ToString();

            (char num2, int pos)[] result =
            {
                ((nums.Length == 2) ? nums[0] : '0', a.pos + b.pos + 1),
                ((nums.Length == 2) ? nums[1] : nums[0], a.pos + b.pos)
            };
            return result;
        }

        // 한 자리를 연산합니다. for 문 내에 들어갈 존재입니다.
        // pos는 길이 - 인덱스 - 1의 값입니다.
        static (char num2, int pos)[] MultiplyOne((char num, int pos)a, (char num, int pos) b)
        {
            string nums = (GetNum(a.num) * GetNum(b.num)).ToString();

            (char num2, int pos)[] result =
            {
                ((nums.Length == 2) ? nums[0] : '0', a.pos + b.pos + 1),
                ((nums.Length == 2) ? nums[1] : nums[0], a.pos + b.pos)
            };
            return result;
        }

        static string Muitiply(string a, string b)
        {
            char[]  
        }

        static void Main(string[] args)
        {
        }
    }
}
