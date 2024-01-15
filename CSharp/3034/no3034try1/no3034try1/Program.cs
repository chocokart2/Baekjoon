using System;
using System.Text;

namespace no3034try1
{
    internal class Program
    {
        static int GetSquare(int a) => a * a;

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string[] nums = Console.ReadLine().Split(' ');
            int count = int.Parse(nums[0]);
            int maxSquare = GetSquare(int.Parse(nums[1])) + GetSquare(int.Parse(nums[2]));
            
            for (int i = 0; i < count; ++i)
            {
                result.Append((maxSquare < GetSquare(int.Parse(Console.ReadLine()))) ? "NE\n" : "DA\n");
            }

            Console.Write(result);
        }
    }
}
