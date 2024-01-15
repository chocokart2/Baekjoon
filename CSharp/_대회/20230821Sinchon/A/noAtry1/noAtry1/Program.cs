using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char direction = Console.ReadLine()[0];
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string result = "?";

            if (direction == 'E')
            {
                if (a.Equals("O.") && b.Equals(".P")) result = "T";
                if (a.Equals(".P") && b.Equals("I.")) result = "F";
                if (a.Equals(".P") && b.Equals("O.")) result = "Lz";
            }
            if (direction == 'W')
            {
                if (a.Equals("O.") && b.Equals(".P")) result = "T";
                if (a.Equals(".P") && b.Equals("I.")) result = "F";
                if (a.Equals(".P") && b.Equals("O.")) result = "Lz";
            }
            if (direction == 'S')
            {
                if (a.Equals(".O") && b.Equals("P.")) result = "T";
                if (a.Equals(".P") && b.Equals("I.")) result = "F";
                if (a.Equals(".P") && b.Equals("O.")) result = "Lz";
            }
            if (direction == 'N')
            {
                if (a.Equals("O.") && b.Equals(".P")) result = "T";
                if (a.Equals(".P") && b.Equals("I.")) result = "F";
                if (a.Equals(".P") && b.Equals("O.")) result = "Lz";
            }


            Console.WriteLine(result);
        }
    }
}
