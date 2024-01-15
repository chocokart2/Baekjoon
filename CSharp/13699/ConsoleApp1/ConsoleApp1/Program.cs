using System;

namespace ConsoleApp1
{
    internal class Program
    {

        static string GetPressedData(bool[,] original, int size)
        {
            bool isNeedToSplit = false;
            bool beginData = original[0,0];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (original[x, y] != beginData)
                    {
                        isNeedToSplit = true;
                        break;
                    }
                }
                if (isNeedToSplit) break;
            }

            if (isNeedToSplit == false)
            {
                return (beginData == true) ? "1" : "0";
            }

            int subSize = (size >> 1);

            bool[][,] subData = new bool[4][,]
            {
                new bool[subSize, subSize],
                new bool[subSize, subSize],
                new bool[subSize, subSize],
                new bool[subSize, subSize]
            };

            for (int halfX = 0; halfX < 2; halfX++)
            {
                for (int halfY = 0; halfY < 2; halfY++)
                {
                    for (int x = halfX * subSize; x < (halfX + 1) * subSize; x++)
                    {
                        for (int y = halfY * subSize; y < (halfY + 1) * subSize; y++)
                        {
                            subData[halfY * 2 + halfX][(x < subSize) ? x : x - subSize, (y < subSize) ? y : y - subSize] = original[x, y];
                        }
                    }
                }
            }

            return $"({GetPressedData(subData[0], subSize)}{GetPressedData(subData[1], subSize)}{GetPressedData(subData[2], subSize)}{GetPressedData(subData[3], subSize)})";
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            bool[,] data = new bool[size, size];

            for (int line = 0; line < size; ++line)
            {
                string recvLine = Console.ReadLine();

                for (int index = 0; index < size; ++index)
                {
                    data[index, line] = recvLine[index] == '1';
                }
            }

            Console.WriteLine(GetPressedData(data, size));
        }
    }
}
