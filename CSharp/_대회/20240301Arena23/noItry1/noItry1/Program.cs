using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noItry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                string[] nums = Console.ReadLine().Split(' ');
                ulong xLength = ulong.Parse(nums[0]);
                ulong yLength = ulong.Parse(nums[1]);
                ulong xMove = ulong.Parse(nums[2]);
                ulong yMove = ulong.Parse(nums[3]);
                ulong oneResultDown = 0;
                ulong oneResultRight = 0;

                for (ulong yPos = 0; yPos < yLength; yPos += yMove * 2)
                {
                    // 각 스텝마다 나이트 초콜릿의 라인을 추가합니다.
                    // 큰 직사각형 - 작은 직사각형
                    oneResultDown +=
                        (xLength) * (yLength - yPos)
                            - ((yPos + yMove < yLength) ?
                                ((xLength) * (yLength - yPos - yMove)) : 0);
                }
                for (ulong xPos = 0; xPos < xLength; xPos += xMove * 2)
                {
                    // 각 스텝마다 나이트 초콜릿의 라인을 추가합니다.
                    // 큰 직사각형 - 작은 직사각형
                    oneResultRight +=
                        (xLength -  xPos) * (yLength)
                            - ((xPos + xMove < xLength) ?
                                ((xLength - xPos - xMove) * (yLength)) : 0);
                }
                result.AppendLine(Math.Max(oneResultDown, oneResultRight).ToString());
            }

            Console.Write(result);

        }
    }
}
