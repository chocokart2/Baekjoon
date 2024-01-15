using System;
using System.Text;
using System.Collections.Generic;

namespace no1620try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            Dictionary<string, int> encyclopedia1 = new Dictionary<string, int>();
            Dictionary<int, string> encyclopedia2 = new Dictionary<int, string>();
            string[] nums = Console.ReadLine().Split(' ');
            int[] size = { int.Parse(nums[0]), int.Parse(nums[1]) };
            for (int index = 1; index <= size[0]; ++index)
            {
                string name = Console.ReadLine();
                encyclopedia1.Add(name, index);
                encyclopedia2.Add(index, name);
            }

            for (int i = 0; i < size[1]; ++i)
            {
                string recvLine = Console.ReadLine();
                if (int.TryParse(recvLine, out int recvNum))
                {
                    result.AppendLine(encyclopedia2[recvNum]);
                }
                else
                {
                    result.AppendLine(encyclopedia1[recvLine].ToString());
                }
            }

            Console.WriteLine(result);
        }
    }
}
