using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no26068try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i < count; ++i)
            {
                int days = int.Parse(Console.ReadLine().Substring(2));
                if (days <= 90) result++;
            }
            Console.WriteLine(result);
        }
    }
}
