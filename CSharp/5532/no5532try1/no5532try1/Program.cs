using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5532try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int korean = int.Parse(Console.ReadLine());
            int math = int.Parse(Console.ReadLine());
            int solveKorean = int.Parse(Console.ReadLine());
            int solveMath = int.Parse(Console.ReadLine());

            int daysKorean = (korean % solveKorean == 0) ? korean / solveKorean : korean / solveKorean + 1;
            int daysMath = (math % solveMath == 0) ? math / solveMath : math / solveMath + 1;
            Console.WriteLine($"{days - Math.Max(daysKorean, daysMath)}");
        }
    }
}
