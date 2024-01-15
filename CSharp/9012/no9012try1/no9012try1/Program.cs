using System;

namespace no9012try1
{
    internal class Program
    {
        static bool CheckVPS(string value)
        {
            int stack = 0;
            for (int index = 0; index < value.Length; ++index)
            {
                switch (value[index])
                {
                    case '(':
                        ++stack;
                        break;
                    case ')':
                        if (stack == 0) return false;
                        --stack;
                        break;
                    default:
                        break;
                }
            }
            return stack.Equals(0);
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string result = CheckVPS(Console.ReadLine()) ? "YES" : "NO";
                Console.WriteLine(result);
            }
        }
    }
}
