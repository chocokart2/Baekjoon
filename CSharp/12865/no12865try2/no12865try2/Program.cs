using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12865try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 만약 가방 안에 물건을 넣지 못하는 크기면 패스한다.
            // 가방의 총 견딜 수 있는 무게 >= 물건의 무게인 경우, 그 무게만큼 가방의 물건을 빼고 물건을 넣는다

            string[] recvLineNK = Console.ReadLine().Split(' ');
            // N
            int countOfItems = int.Parse(recvLineNK[0]);
            // K
            int capacityOfWeight = int.Parse(recvLineNK[1]);
            int[] weights = new int[countOfItems];
            int[] values = new int[countOfItems];
            int[,] maxValueOfBag = new int[countOfItems, capacityOfWeight + 1];

            for (int index = 0; index < countOfItems; index++)
            {
                string[] recvLineItem = Console.ReadLine().Split(' ');
                weights[index] = int.Parse(recvLineItem[0]);
                values[index] = int.Parse(recvLineItem[1]);
            }

            // 점화식의 1번 식을 만듭니다.
            // 1번 아이템
            for (int weightIndex = weights[0]; weightIndex < capacityOfWeight + 1; ++weightIndex)
            {
                maxValueOfBag[0, weightIndex] = values[0];
            }
            // 점화식의 n번 식을 만듭니다.

            for (int itemIndex = 1; itemIndex < countOfItems; ++itemIndex)
            {
                for (int weightIndex = 1; weightIndex < capacityOfWeight + 1; ++weightIndex)
                {
                    if (weightIndex < weights[itemIndex]) maxValueOfBag[itemIndex, weightIndex] = maxValueOfBag[itemIndex - 1, weightIndex];
                    else
                    {
                        int alternative = maxValueOfBag[itemIndex - 1, weightIndex - weights[itemIndex]] + values[itemIndex];
                        maxValueOfBag[itemIndex, weightIndex] = (maxValueOfBag[itemIndex - 1, weightIndex] < alternative) ? alternative : maxValueOfBag[itemIndex - 1, weightIndex];
                    }
                }
            }


            // 확인용 코드
            //for (int itemIndex = 0; itemIndex < countOfItems; ++itemIndex)
            //{
            //    for (int weightIndex = 0; weightIndex < capacityOfWeight + 1; ++weightIndex)
            //    {
            //        Console.Write($"{maxValueOfBag[itemIndex, weightIndex]}\t");
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine(maxValueOfBag[countOfItems - 1, capacityOfWeight]);
        }
    }
}
