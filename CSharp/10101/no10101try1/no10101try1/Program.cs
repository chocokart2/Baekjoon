using System;

namespace no10101try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] angles = new int[3];
            angles = new int[] {
                int.Parse(Console.ReadLine()), 
                int.Parse(Console.ReadLine()), 
                int.Parse(Console.ReadLine()) 
            };

            if (angles[0].Equals(60) && angles[1].Equals(60) && angles[2].Equals(60))
                Console.WriteLine("Equilateral");
            else if ((angles[0] + angles[1] + angles[2]) != 180)
                Console.WriteLine("Error");
            else if (angles[0].Equals(angles[1]) || angles[2].Equals(angles[1]) || angles[0].Equals(angles[2]))
                Console.WriteLine("Isosceles");                
            else
                Console.WriteLine("Scalene");
        }
    }
}
