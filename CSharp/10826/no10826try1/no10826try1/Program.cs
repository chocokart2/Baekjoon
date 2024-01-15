using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10826try1
{
    internal class Program
    {
        static int Convert(char a) => a - '0';

        static string Plus(string a, string b)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            int prevNum = 0; // 올리는 숫자, 해당 자리 숫자의 합이 10을 넘어가는 경우, 1로 표현, 아니면 0

            while (indexA > -1 || indexB > -1)
            {
                int aNum = 0;
                int bNum = 0;
                int sum;

                if (indexA > -1)
                {
                    aNum = Convert(a[indexA]);
                    indexA--;
                }
                if (indexB > -1)
                {
                    bNum = Convert(b[indexB]);
                    indexB--;
                }

                sum = prevNum + aNum + bNum;
                prevNum = 0;

                if (sum > 9)
                {
                    sum -= 10;
                    prevNum = 1;
                }

                sb.Append(sum.ToString());
            }
            if (prevNum == 1) sb.Append("1");
            for (int index = sb.Length - 1; index > -1; --index)
            {
                result.Append(sb[index]);
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            string[] sums = new string[10001];
            sums[0] = "0";
            sums[1] = "1";
            for (int index = 2; index < sums.Length; ++index)
                sums[index] = Plus(sums[index - 1], sums[index - 2]);
            Console.WriteLine(sums[int.Parse(Console.ReadLine())]);
        }
    }
}
