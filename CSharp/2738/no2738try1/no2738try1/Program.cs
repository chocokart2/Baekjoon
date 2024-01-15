using System;

namespace no2738try1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine().Split(' ');
            int column = int.Parse(numbers[0]);
            int row = int.Parse(numbers[1]);

            int[,] matrix = new int[column, row];

            for (int attempt = 1; attempt <= 2; ++attempt)
            {
                for (int indexColumn = 0; indexColumn < column; ++indexColumn)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');

                    for (int indexRow = 0; indexRow < row; ++indexRow)
                    {
                        matrix[indexColumn, indexRow] += int.Parse(recvLine[indexRow]);
                    }
                }
            }

            for (int indexColumn = 0; indexColumn < column; ++indexColumn)
            {
                for (int indexRow = 0; ; ++indexRow)
                {
                    if (indexRow == row - 1)
                    {
                        Console.Write(matrix[indexColumn, indexRow]);
                        break;
                    }
                    else
                    {
                        Console.Write($"{matrix[indexColumn, indexRow]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
