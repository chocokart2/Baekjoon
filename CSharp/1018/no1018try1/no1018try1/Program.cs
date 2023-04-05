using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1018try1
{
    internal class Program
    {
        private const int NOT_FOUND = int.MaxValue; // 최솟값을 찾는 알고리즘에 의해 max value로 정의

        // 2차원 배열이며 [가로, 세로]인 특이한 배열입니다.
        private class ChessBoard
        {
            int coloringCount = 0; // 맨 왼쪽 윗칸이 흰색인 경우 색칠해야 하는 횟수입니다.
            int coloringCountReverse = 0; // 맨 왼쪽 윗칸이 검은색인 경우 색칠해야 하는 횟수입니다.
            int line = 0;

            public string GetMember() { return $"WBWBWBWB: {coloringCount},\tBWBWBWBW: {coloringCountReverse},\t처리후 line: {line}\tvalue: {GetColoringCount()}"; }
            public void AddNewLine(string eightSquareColor)
            {
                if (line >= 8) return; // early return pattern

                int count = CountDiffernetColorPattern(eightSquareColor);

                if (line % 2 == 0)
                {
                    
                    coloringCount += count;// wbwbwbwb
                    coloringCountReverse += (8 - count);//bwbwbwbw
                }
                else
                {
                    coloringCount += (8 - count);//bwbwbwbw
                    coloringCountReverse += count;//wbwbwbwb
                }
                ++line;
            }
            public int GetColoringCount()
            {
                if (line < 8) return NOT_FOUND;
                return Math.Min(coloringCount, coloringCountReverse);
            }
            // WBWBWBWB 패턴과 얼마나 불일치한지 리턴합니다.
            // 만약 그 반대 패턴을 원한다면 8 - returnValue를 하면 됩니다.
            private int CountDiffernetColorPattern(string eightColor)
            {
                int result = 0;
                for(int index = 0; index < 8; ++index)
                {
                    if(index % 2 == 0)
                    {
                        if (eightColor[index].Equals('B')) ++result;
                    }
                    else
                    {
                        if (eightColor[index].Equals('W')) ++result;
                    }
                }
                return result;
            }
        }
        static private void PrintChessBoardArray(ChessBoard[,] chessBoards, int width, int height)
        {
            for (int column = 0; column < height; ++column)
            {
                for (int row = 0; row < width - 7; ++row)
                {
                    Console.WriteLine($"ChessBoard[{row}, {column}] : {chessBoards[row, column].GetColoringCount()}");
                }
            }
        }

        static void Main(string[] args)
        {
            // 적당한 내용으로 자르는 파트도 필요
            string[] ReceiveLine = Console.ReadLine().Split(' ');

            int width = int.Parse(ReceiveLine[1]);
            int height = int.Parse(ReceiveLine[0]);
            ChessBoard[,] chessBoards = new ChessBoard[width - 7, height];
            
            for(int column = 0; column < height; ++column) // 세로 카운트
            {
                string ReceiveColorLine = Console.ReadLine();
                for(int row = 0; row < width - 7; ++row)
                {
                    chessBoards[row, column] = new ChessBoard();
                    for(int columnCursor = 0; columnCursor <= column; ++columnCursor)
                    {
                        chessBoards[row, columnCursor].AddNewLine(ReceiveColorLine.Substring(row, 8));
                        //Console.WriteLine($"chessBoards[{row}, {columnCursor}]{chessBoards[row, columnCursor].GetMember()}");
                    }
                }
            }

            // DEBUG
            //PrintChessBoardArray(chessBoards, width, height);
            int result = int.MaxValue;
            foreach (ChessBoard one in chessBoards)
            {
                int value = one.GetColoringCount();
                if (result > value) result = value; 
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
