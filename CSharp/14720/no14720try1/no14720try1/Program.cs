using System;

namespace no14720try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            string demand = "0";

            Console.ReadLine();
            string[] line = Console.ReadLine().Split(' ');

            for (int index = 0; index < line.Length; ++index)
            {
                if (line[index] == demand)
                {
                    ++result;
                    switch (demand)
                    {
                        case "0": demand = "1"; break;
                        case "1": demand = "2"; break;
                        case "2": demand = "0"; break;
                        default: break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
