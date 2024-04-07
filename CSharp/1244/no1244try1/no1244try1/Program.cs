using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1244try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] swichies = new bool[int.Parse(Console.ReadLine())];
            bool m_IsOutside(int index)
            {
                return (index < 0) || (index >= swichies.Length);
            }


            string recvLine = Console.ReadLine();
            for (int index = 0; index < swichies.Length; index++)
            {
                swichies[index] = recvLine[index * 2] == '1';
            }

            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                string[] message = Console.ReadLine().Split(' ');
                int i = int.Parse(message[1]);

                if (message[0][0] == '1')
                {
                    for (int index = 0; index < swichies.Length; ++index)
                    {
                        if ((index + 1) % i == 0) swichies[index] = !swichies[index];
                    }
                }
                else
                {
                    swichies[i - 1] = !swichies[i - 1];

                    for (int d = 1; true; d++)
                    {
                        if (m_IsOutside(i + d - 1) || m_IsOutside(i - d - 1)) break;
                        if (swichies[i + d - 1] != swichies[i - d - 1]) break;
                        swichies[i + d - 1] = !swichies[i + d - 1];
                        swichies[i - d - 1] = !swichies[i - d - 1];
                    }
                }
            }

            for (int y = 0; y < ((swichies.Length - 1) / 20) + 1; ++y)
            {
                for (int x = 0; x + y * 4 < Math.Min(swichies.Length, 20); ++x)
                {
                    Console.Write($"{(swichies[x + y * 20] ? "1" : "0")} ");
                }
                Console.WriteLine();
            }


        }
    }
}
