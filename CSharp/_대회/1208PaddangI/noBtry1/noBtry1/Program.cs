using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        class Hamburger
        {
            public string[] str;
            public Hamburger(string value)
            {
                str = new string[3];
                str[0] = "........";
                str[1] = value;
                str[2] = "........";

                // 덧씌웁니다.
                bool isLengthFive = str[1][6] == '.';
                int rightNumber = isLengthFive ? (str[1][5] - '0') : int.Parse(str[1].Substring(5, 2));
                bool result = (str[1][1] + str[1][3] - '0' - '0') == rightNumber;

                if (result)
                {
                    if (isLengthFive)
                    {
                        str[0] = ".*****..";
                        str[1] = $"*{str[1].Substring(1, 5)}*.";
                        str[2] = ".*****..";
                    }
                    else
                    {
                        str[0] = ".******.";
                        str[1] = $"*{str[1].Substring(1, 6)}*";
                        str[2] = ".******.";
                    }
                }
                else
                {
                    str[0] = ".../....";
                    str[1] = $"{str[1].Substring(0, 2)}/{str[1].Substring(3, 5)}";
                    str[2] = "./......";
                }
            }
        }


        static void Main(string[] args)
        {
            string[] sizeNM = Console.ReadLine().Split(' ');
            int sizeY = int.Parse(sizeNM[0]);
            int sizeX = int.Parse(sizeNM[1]);
            StringBuilder result = new StringBuilder();
            for (int y = 0; y < sizeY; ++y)
            {
                Hamburger[] line = new Hamburger[sizeX];

                Console.ReadLine();
                string recvLine = Console.ReadLine();
                for (int x = 0; x < sizeX; ++x)
                {
                    line[x] = new Hamburger(recvLine.Substring(x * 8, 8));
                }
                Console.ReadLine();
                for (int threeLine = 0; threeLine < 3; ++threeLine)
                {
                    for (int x = 0; x < sizeX; ++x)
                    {
                        result.Append(line[x].str[threeLine]);
                    }
                    result.Append('\n');
                }
            }
            Console.Write(result);
        }
    }
}
