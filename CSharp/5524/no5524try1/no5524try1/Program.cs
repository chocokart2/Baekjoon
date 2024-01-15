using System;
using System.Text;

namespace no5524try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string name = Console.ReadLine();
                StringBuilder resultOne = new StringBuilder();

                for (int index = 0; index < name.Length; ++index)
                {
                    if (name[index] <= 'Z') resultOne.Append((char)(name[index] - 'A' + 'a'));
                    else resultOne.Append(name[index]);
                }
                Console.WriteLine(resultOne);
            }
        }
    }
}
