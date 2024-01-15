using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10815try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            bool[] isExist = new bool[20_000_001]; // index = num + 10_000_000;
            Console.ReadLine();
            string[] card = Console.ReadLine().Split(' ');
            for (int index = 0; index < card.Length; ++index)
                isExist[int.Parse(card[index]) + 10_000_000] = true;
            Console.ReadLine();
            string[] search = Console.ReadLine().Split(' ');
            for (int index = 0; index < search.Length; ++index)
                result.Append((isExist[int.Parse(search[index]) + 10_000_000]) ? "1 " : "0 ");
            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result);
        }
    }
}
