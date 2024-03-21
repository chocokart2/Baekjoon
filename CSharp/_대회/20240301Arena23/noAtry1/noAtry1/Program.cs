using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                string recvline = Console.ReadLine();
                int count = 0;
                int num = 0;
                bool isFoundNum = false;
                bool tail = false;

                for (int index = 0; index < recvline.Length; index++)
                {
                    if ((isFoundNum == false) && recvline[index] == '!')
                    {
                        count++;
                        continue;
                    }
                    else if (recvline[index] == '1')
                    {
                        num = 1;
                        isFoundNum = true;
                        continue;
                    }
                    else if (recvline[index] == '0')
                    {
                        isFoundNum = true;
                        continue;
                    }
                    else if (isFoundNum && recvline[index] == '!')
                    {
                        tail = true;
                        break;
                    }
                }

                // 논리 반전
                if (tail) { num = 1; }

                if (count % 2 == 1) num = (num == 0) ? 1 : 0;

                result.AppendLine(num.ToString());
            }
            Console.Write(result);

        }
    }
}
