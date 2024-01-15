using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12787try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');

                if (nums[0][0] == '1')
                {
                    string[] address = nums[1].Split('.');
                    ulong digitNumber = 0;
                    for (int index = 0; index < 8; ++index)
                    {
                        digitNumber |= (ulong.Parse(address[index]) << ((7 - index) * 8));
                    }
                    Console.WriteLine(digitNumber);
                }
                else
                {
                    ulong digitNumber = ulong.Parse(nums[1]);
                    ulong[] address = new ulong[8];

                    for (int byteIndex = 0; byteIndex < 8; byteIndex++)
                    {
                        address[byteIndex] = (digitNumber >> ((7 - byteIndex) * 8)) & 0b_1111_1111;
                    }

                    Console.WriteLine(
                        $"{address[0]}.{address[1]}.{address[2]}.{address[3]}.{address[4]}.{address[5]}.{address[6]}.{address[7]}");
                }
            }




        }
    }
}
