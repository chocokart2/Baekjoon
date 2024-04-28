using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1159try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] count = new int[26];
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                count[(int)(Console.ReadLine()[0] - 'a')]++;
            }
            bool isFound = false;
            for (int index = 0; index < count.Length; index++)
            {
                if (count[index] >= 5)
                {
                    isFound = true;
                    Console.Write((char)(index + 'a'));
                }
            }
            if (isFound == false) Console.WriteLine("PREDAJA");
        }
    }
}
