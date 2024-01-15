using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10989try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit = 500;
            int waiting = 0;
            int[] data = new int[10001];
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput(40_000));

            for (int i = 0; i < count; i++)
            {
                data[int.Parse(Console.ReadLine())]++;
            }
            
            for (int index = 1; index < 10001; ++index)
            {
                while (data[index] > 0)
                {
                    writer.Write($"{index}\n");
                    data[index]--;
                    waiting++;
                    if (waiting > limit)
                    {
                        writer.Flush();
                        waiting = 0;
                    }
                }
            }

            writer.Flush();
            writer.Close();
        }
    }
}
