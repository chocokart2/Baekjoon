using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1269try1
{
    internal class Program
    {
        static int[] ConvertToIntArray(string line)
        {
            string[] strings = line.Split(' ');
            int[] result = new int[strings.Length];
            for (int index = 0; index < strings.Length; ++index)
                result[index] = int.Parse(strings[index]);
            return result;
        }

        static void Main(string[] args)
        {
            int[] length = ConvertToIntArray(Console.ReadLine());
            HashSet<int> setA = new HashSet<int>(
                ConvertToIntArray(Console.ReadLine()));
            HashSet<int> setB = new HashSet<int>(
                ConvertToIntArray(Console.ReadLine()));
            HashSet<int> middle = new HashSet<int>(setA);
            middle.IntersectWith(setB);
            setA.ExceptWith(middle);
            setB.ExceptWith(middle);
            HashSet<int> result = new HashSet<int>(setA.Union(setB));
            Console.WriteLine(result.Count);
        }
    }
}
