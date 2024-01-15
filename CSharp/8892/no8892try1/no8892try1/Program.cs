using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no8892try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                string[] words = new string[int.Parse(Console.ReadLine())];
                for (int index = 0; index < words.Length; index++)
                {
                    words[index] = Console.ReadLine();
                }

                bool isFound = false;
                for (int left = 0; left < words.Length; ++left)
                {
                    for (int right = 0; right < words.Length; ++right)
                    {
                        if (left == right) continue;
                        string one = $"{words[left]}{words[right]}";

                        isFound = true;

                        for (int index = 0; index < one.Length / 2; ++index)
                        {
                            if (one[index] != one[one.Length - 1 - index])
                            {
                                isFound = false;
                                break;
                            }
                        }

                        if (isFound)
                        {
                            result.AppendLine(one);
                            break;
                        }
                    }
                    if (isFound) { break; }
                }
                if (!isFound)
                {
                    result.Append("0\n");
                }
            }
            Console.Write(result);

        }
    }
}
