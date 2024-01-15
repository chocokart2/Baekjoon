using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no6764try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] depth = new int[4]
            {
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine())
            };

            bool isRising = true;
            bool isDiving = true;
            bool isEqual = true;

            for (int i = 1; i < depth.Length; i++)
            {
                if (depth[i - 1] != depth[i]) isEqual = false;
                if (depth[i - 1] >= depth[i]) isRising = false;
                if (depth[i - 1] <= depth[i]) isDiving = false;
            }
            if (isRising) Console.WriteLine("Fish Rising");
            else if (isDiving) Console.WriteLine("Fish Diving");
            else if (isEqual) Console.WriteLine("Fish At Constant Depth");
            else Console.WriteLine("No Fish");

        }
    }
}
