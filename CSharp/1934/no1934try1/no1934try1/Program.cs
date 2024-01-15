using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1934try1
{
    internal class Program
    {
        static Dictionary<int, int> GetMeasure(int a)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 2; i <= a;)
            {
                if (a % i == 0) // i는 a의 약수
                {
                    if (result.ContainsKey(i)) result[i] += 1;
                    else result[i] = 1;
                    a /= i;
                }
                else
                {
                    ++i;
                }
            }
            return result;
        }

        static int GetLeastCommonMultiple(int a, int b)
        {
            int result = 1;
            Dictionary<int, int> measureA = GetMeasure(a);
            Dictionary<int, int> measureB = GetMeasure(b);
            
            List<int> measureList = new List<int>();

            measureList = measureA.Keys.ToList();
            foreach(int one in measureB.Keys.ToList())
            {
                if (measureList.Contains(one) == false)
                    measureList.Add(one);
            }

            foreach (int one in measureList)
            {
                int measureCounts = 0;
                if (measureA.ContainsKey(one)) measureCounts = measureA[one];
                if (measureB.ContainsKey(one))
                    if (measureCounts < measureB[one])
                        measureCounts = measureB[one];
                result *= (int)Math.Pow(one, measureCounts);
            }
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                Console.WriteLine(GetLeastCommonMultiple(
                    int.Parse(numbers[0]), int.Parse(numbers[1])));
            }
        }
    }
}
