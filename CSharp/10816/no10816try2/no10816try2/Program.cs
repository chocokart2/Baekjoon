using System;
using System.Collections.Generic;
using System.Text;

namespace no10816try2
{
    internal class Program
    {
        static Dictionary<int, int> source;

        static int GetNumberCount(int target)
        {
            if (source.ContainsKey(target)) return source[target];
            else return 0;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int sourceCount = int.Parse(Console.ReadLine());
            source = new Dictionary<int, int>();
            string[] numStrings = Console.ReadLine().Split(' ');
            
            for (int index = 0; index < sourceCount; ++index)
            {
                int oneSource = int.Parse(numStrings[index]);

                if (source.ContainsKey(oneSource))
                {
                    source[oneSource] = source[oneSource] + 1;
                }
                else
                {
                    source.Add(oneSource, 1);
                }
            }

            int findingCount = int.Parse(Console.ReadLine());
            Dictionary<int, int> finding = new Dictionary<int, int>();
            numStrings = Console.ReadLine().Split(' ');

            // 전제조건에 의해 numStrings[0] != null이 보장됩니다.
            result.Append(GetNumberCount(int.Parse(numStrings[0])));

            for (int index = 1; index < findingCount; ++index)
            {
                result.Append($" {GetNumberCount(int.Parse(numStrings[index]))}");
            }
            Console.WriteLine(result.ToString());
        }
    }
}
