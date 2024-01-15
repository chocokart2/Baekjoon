using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11726try2
{
    internal class Program
    {
        static int n;
        static int[] remainderOfCombination; // == (n-x 조합 x) % 10_007

        // n-xCx * G(n, x) = n-x-1Cx+1
        static int GetTop(int n, int x) => ((n - 2 * x) * (n - (2 * x) - 1));
        static int GetSub(int n, int x) => ((n - x) * (x + 1));

        static void Init(int _n)
        {
            n = _n;

            remainderOfCombination = new int[n];
            remainderOfCombination[0] = 1;
            
            for (int index = 1; index <= (n >> 1) + 1; ++index)
            {
                Console.WriteLine($"Init({_n}) Loop : index = {index}");

                remainderOfCombination[index] =
                    ((remainderOfCombination[index - 1] * GetTop(n, index - 1)) / GetSub(n, index - 1)) % 10_007 ;
            }

        }
            
        static void Main(string[] args)
        {
            int result = 0;
            Init(int.Parse(Console.ReadLine()));

            for (int index = 0; index <= (n >> 1); ++index)
            {
                result += remainderOfCombination[index];
            }
            result %= 10_007;

            for(int index = 0; index < remainderOfCombination.Length; ++index)
            {
                Console.WriteLine($"DEBUG : remainderOfCombination[{index}] = {remainderOfCombination[index]}");
            }
            Console.WriteLine(result);
        }
    }
}
