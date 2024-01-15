using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2231try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = 0;

            for (int i = 1; i < n; i++)
            {
                string oneStr = i.ToString();
                int sum = i;
                for (int index = 0; index < oneStr.Length; ++index)
                {
                    sum += oneStr[index] - '0';
                }

                if (sum == n)
                {
                    result = i;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
