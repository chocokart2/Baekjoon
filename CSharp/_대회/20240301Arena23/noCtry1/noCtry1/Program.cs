using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int xLength = int.Parse(nums[0]);
                int yLength = int.Parse(nums[1]);
                int xMove = int.Parse(nums[2]);
                int yMove = int.Parse(nums[3]);
                int oneResult = 0;

                for (int 
                    xPos = 0, 
                    yPos = 0
                    ; 
                    xPos < xLength && yPos < yLength
                    ;
                    xPos += xMove * 2,
                    yPos += yMove * 2
                    )
                {
                    // 각 스텝마다 나이트 초콜릿의 라인을 추가합니다.
                    // 큰 직사각형 - 작은 직사각형
                    oneResult +=
                        (xLength - xPos) * (yLength - yPos)
                            - ((xPos + xMove < xLength && yPos + yMove < yLength) ?
                                ((xLength - xPos - xMove) * (yLength - yPos - yMove)) : 0);
                }
                result.AppendLine(oneResult.ToString());
            }

            Console.Write(result);

        }
    }
}
