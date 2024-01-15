using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4883try1
{
    internal class Program
    {
        static void CheckRowSum(ref int[] sum, int[] rowCost)
        {
            sum[1] = Math.Min(sum[1], rowCost[1] + sum[0]);
            sum[2] = Math.Min(sum[2], rowCost[2] + sum[1]);
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int testCount = 1;
            int[] currentLine = new int[3];

            // 가장 윗쪽의 왼쪽 칸은 도달할 수 없는 칸입니다. 따라서 그 칸에는 큰 값인 10_000을 입력합니다.
            // 각 포인트의 값은 해당 지점에 도달하는 방법중 가장 낮은 값을 저장합니다.


            for (int testNum = 1; true; testNum++)
            {
                int size = int.Parse(Console.ReadLine());
                if (size == 0) break;

                currentLine = new int[3] { 10000, 0, 10000 };
                string[] firstLine = Console.ReadLine().Split(' ');
                int[] oneRowCost = new int[3];
                for (int index = 0; index < 3; ++index)
                {
                    oneRowCost[index] = int.Parse(firstLine[index]);
                    currentLine[index] += oneRowCost[index];
                }
                CheckRowSum(ref currentLine, oneRowCost);
                    
                for (int i = 1; i < size; ++i)
                {
                    int[] tempSum = new int[3]
                    {
                        currentLine[0],
                        currentLine[1],
                        currentLine[2]
                    };
                    
                    string[] rowCostString = Console.ReadLine().Split(' ');
                    for (int index = 0; index < 3; ++index)
                    {
                        oneRowCost[index] = int.Parse(rowCostString[index]);
                    }

                    tempSum[0] = Math.Min(
                        oneRowCost[0] + currentLine[0],
                        oneRowCost[0] + currentLine[1]
                        );
                    tempSum[1] = Math.Min(
                        oneRowCost[1] + currentLine[0],
                        oneRowCost[1] + currentLine[1]
                        );
                    tempSum[1] = Math.Min(
                        tempSum[1],
                        oneRowCost[1] + currentLine[2]
                        );
                    tempSum[2] = Math.Min(
                        oneRowCost[2] + currentLine[1],
                        oneRowCost[2] + currentLine[2]
                        );

                    CheckRowSum(ref tempSum, oneRowCost);

                    currentLine = tempSum;
                }

                result.AppendLine($"{testNum}. {currentLine[1]}");
            }

            Console.Write(result);


        }
    }
}
