using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {





            int m_n = int.Parse(Console.ReadLine());
            int result = 0;

            int GetCount(int k) => Math.Abs(k - m_n) + 1 + m_n;


            for (int i = -m_n; i <= m_n; i++)
            {
                int one = 1 - i;


                if (i == 0)
                {
                    result += (2 * m_n + 1) * (2 * m_n + 1);
                }
                else if (one > m_n)
                {
                    result += m_n;
                }
                else
                {
                    result += GetCount(Math.Abs(one));
                }
                //Console.WriteLine($">> {result}");
            }
            Console.WriteLine(result);





        }
    }
}
