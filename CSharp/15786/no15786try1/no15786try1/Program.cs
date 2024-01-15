using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15786try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Split(' ')[1]);
            string piece = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                string one = Console.ReadLine();
                int pieceIndex = 0;
                bool oneResult = false;
                for (int oneIndex = 0; oneIndex < one.Length && pieceIndex < piece.Length; oneIndex++)
                {
                    if (one[oneIndex] == piece[pieceIndex])
                    {
                        pieceIndex++;
                    }
                }
                result.AppendLine((pieceIndex == piece.Length) ? "true" : "false");
            }
            Console.Write(result);
        }
    }
}
