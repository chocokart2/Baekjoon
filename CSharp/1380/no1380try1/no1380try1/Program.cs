using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace no1380try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int caseCount = 1; ;caseCount++)
            {
                int students = int.Parse(Console.ReadLine());
                if (students == 0) break;

                string[] studentsName = new string[students];
                for (int index = 0; index < students; ++index)
                {
                    studentsName[index] = Console.ReadLine();
                }
                HashSet<int> earrings = new HashSet<int>();
                for (int i = 1; i < students * 2; ++i)
                {
                    int one = int.Parse(Console.ReadLine().Split(' ')[0]);

                    if (earrings.Contains(one)) { earrings.Remove(one); }
                    else earrings.Add(one);
                }
                Console.WriteLine($"{caseCount} {studentsName[earrings.ToArray()[0] - 1]}");
            }


        }
    }
}
