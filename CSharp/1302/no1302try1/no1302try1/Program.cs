using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1302try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int books = int.Parse(Console.ReadLine());
            Dictionary<string, int> mapNameToSales = new Dictionary<string, int>();
            List<string> bookNames;
            string result;

            for (int i = 0; i < books; ++i)
            {
                string one = Console.ReadLine();

                if (mapNameToSales.ContainsKey(one))
                {
                    mapNameToSales[one]++;
                }
                else
                {
                    mapNameToSales.Add(one, 1);
                }
            }

            bookNames = mapNameToSales.Keys.ToList();
            bookNames.Sort();
            result = bookNames[0];
            

            for (int index = 1; index < bookNames.Count; ++index)
            {
                if (mapNameToSales[result] < mapNameToSales[bookNames[index]])
                {
                    result = bookNames[index];
                }
            }

            Console.WriteLine(result);
        }
    }
}
