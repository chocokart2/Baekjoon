using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3085try1
{
    internal class Program
    {
        // 시간 제한에 비해 메모리를 후하게 주네요.
        static int size;
        static char[,] candies;

        static void Swap(int x1, int y1, int x2, int y2)
        {
            char temp = candies[x1, y1];
            candies[x1, y1] = candies[x2, y2];
            candies[x2, y2] = temp;
        }
        static int Search()
        {
            int result = 0; // rowValue가 업데이트할때마다 바뀔 수 있습니다.
            (char candy, int count)[] columnsValue = new (char, int)[size]; // null이거나, 값이 다른경우 count를 1로 초기화
            (char candy, int count) rowValue = ('X', -1);
            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    if (y == 0)
                    {
                        columnsValue[x] = (candies[x, y], 1);
                    }
                    else
                    {
                        if (columnsValue[x].candy == candies[x, y]) columnsValue[x] = (candies[x, y], columnsValue[x].count + 1);
                        else
                        {
                            result = Math.Max(result, columnsValue[x].count);
                            columnsValue[x] = (candies[x, y], 1);
                        }
                    }
                    if (x == 0)
                    {
                        rowValue = (candies[x, y], 1);
                    }
                    else
                    {
                        if (rowValue.candy == candies[x, y]) rowValue.count++;
                        else
                        {
                            result = Math.Max(result, rowValue.count);
                            rowValue = (candies[x, y], 1);
                        }
                    }
                }
                result = Math.Max(result, rowValue.count);
            }

            for (int index = 0; index < size; ++index)
                result = Math.Max(result, columnsValue[index].count);
            return result;
        }

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            candies = new char[size, size];
            int result;


            for (int y = 0; y < size; ++y)
            {
                string line = Console.ReadLine();

                for (int x = 0; x < size; ++x)
                {
                    candies[x, y] = line[x];
                }
            }
            result = Search();

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    // 오른쪽 스왑
                    // 왼쪽 스왑
                    
                    // 오른쪽 스왑 시도
                    if (x < size - 1)
                    {
                        Swap(x, y, x + 1, y);
                        result = Math.Max(result, Search());
                        Swap(x, y, x + 1, y);
                    }
                    if (y < size - 1)
                    {
                        Swap(x, y, x, y + 1);
                        result = Math.Max(result, Search());
                        Swap(x, y, x, y + 1);
                    }
                }
            }

            Console.WriteLine(result);

            // 각 0 ~ size의 포지션에서 오른쪽 / 아랫쪽으로 스왑 시도.
            // 각 시도에서 최대한의 값 계산하기.
            // 이후 되돌리기 스왑
        }
    }
}
