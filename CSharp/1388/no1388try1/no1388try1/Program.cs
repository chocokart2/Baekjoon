using System;
namespace no1388try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            string[] nums = Console.ReadLine().Split(' ');
            int N = int.Parse(nums[0]);
            int M = int.Parse(nums[1]);

            string[] tileDeco = new string[N];
            bool[,] isPlaced = new bool[N, M];
            
            char m_TryGetChar(int yIndex, int xIndex)
            {
                if (yIndex >= N || yIndex < 0) return '?';
                if (xIndex >= M || xIndex < 0) return '?';

                return tileDeco[yIndex][xIndex];
            }

            for (int index = 0; index < N; ++index)
                tileDeco[index] = Console.ReadLine();

            for (int indexY = 0; indexY < N; ++indexY)
            {
                for (int indexX = 0; indexX < M; ++indexX)
                {
                    if (isPlaced[indexY, indexX] == true) continue;
                    ++result;

                    if (tileDeco[indexY][indexX] == '-')
                    {
                        for (int tempX = indexX + 1; m_TryGetChar(indexY, tempX) == '-'; ++tempX)
                        {
                            isPlaced[indexY, tempX] = true;
                        }
                    }
                    if (tileDeco[indexY][indexX] == '|')
                    {
                        for (int tempY = indexY + 1; m_TryGetChar(tempY, indexX) == '|'; ++tempY)
                        {
                            isPlaced[tempY, indexX] = true;
                        }
                    }
                    // 비주얼 코드
                }
            }
            Console.WriteLine(result);
        }
    }
}
