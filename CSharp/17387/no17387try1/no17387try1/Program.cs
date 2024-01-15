using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17387try1
{
    internal class Program
    {
        // 바로 int로 받아버리면 소숫점에서 정밀도를 얻을 수 없습니다. 따라서 대충 아무 큰 값을 곱해줍니다.
        static long bigNumberForPrecision = 100;
        static bool IsDebug = false;

        class Number
        {
            public string value;
        }


        class LineSegmentEquation
        {
            public long startX;
            public long startY;
            public long endX;
            public long endY;

            public LineSegmentEquation(string input)
            {
                string[] recvLine = input.Split(' ');
                long[] nums = new long[4];
                for (int index = 0; index < recvLine.Length; ++index)
                {
                    nums[index] = long.Parse(recvLine[index]) * bigNumberForPrecision;
                }

                if (nums[0] <= nums[2])
                {
                    startX = nums[0];
                    startY = nums[1];
                    endX = nums[2];
                    endY = nums[3];
                }
                else
                {
                    startX = nums[2];
                    startY = nums[3];
                    endX = nums[0];
                    endY = nums[1];
                }
            }

            public (int result, long pointA, long pointB) GetY(long xPos)
            {
                // 값의 갯수 0 : 없음
                // 1 : 값, -1
                // 2 : 최솟값, 최댓값
                if (!IsInsideRange(xPos))
                {
                    Say($">> DEBUG_GetY : 해당 좌표({xPos})는 정의역을 벗어났습니다.");
                    return (0, -1, -1);
                }
                if (startX == endX)
                {
                    Say(">> DEBUG_GetY : 해당 선은 Y축에 수직입니다.");
                    return (2, Math.Min(startY, endY), Math.Max(startY, endY));
                }

                Say($">> 값 : {((xPos - startX) * (endY - startY)) / (endX - startX) + startY}");
                return (1, ((xPos - startX) * (endY - startY)) / (endX - startX) + startY, 0);
            }
            public bool IsInsideRange(long xPos)
            {
                return (startX <= xPos) && (xPos <= endX);
            }
            public bool ISInsideRangeY(long yPos)
            {
                return (Math.Min(startY, endY) <= yPos) && (yPos <= Math.Max(startY, endY));
            }
            public bool IsParallelToY() => startX == endX;
        }

        static bool IsInsideRange(long question, long start, long end)
            => (start <= question) && (question <= end);
        static bool IsLinesCrossInOneLine(long startLineA, long endLineA, long startLineB, long endLineB)
        {
            return IsInsideRange(startLineB, startLineA, endLineA) ||
                IsInsideRange(endLineB, startLineA, endLineA) ||
                IsInsideRange(startLineA, startLineB, endLineB) ||
                IsInsideRange(endLineA, startLineB, endLineB);
        }
        static void Say(string value)
        {
            if (IsDebug) Console.WriteLine(value);
        }
        static void Main(string[] args)
        {
            LineSegmentEquation lineA = new LineSegmentEquation(Console.ReadLine());
            LineSegmentEquation lineB = new LineSegmentEquation(Console.ReadLine());

            // 선분의 방정식들의 정의역이 겹치는지 판단
            if (! IsLinesCrossInOneLine(lineA.startX, lineA.endX, lineB.startX, lineB.endX))
            {
                // 정의역이 겹쳐지지 않습니다.
                Console.WriteLine(0);
                Say(">> Debug : X 범위가 겹처지지 않음");
                return;
            }

            long startX = Math.Max(lineA.startX, lineB.startX);
            long endX = Math.Min(lineA.endX, lineB.endX);
            Say($">> DEBUG : 시작 X = {startX}, 종료 X = {endX}");

            // 해당 선이 Y와 평행한 경우
            // 한 선이 평행 => Y과 평행하지 않은 선의 해당 X 좌표의 Y좌표가, Y축과 평행한 선의 InsideRange에 포함하는지 판정할 것.
            // 두 선이 평행 => (X값 판정은 이미 통과됨) && Y값이 서로 겹치는지 판정

            // 두 선이 평행
            if (lineA.IsParallelToY() && lineB.IsParallelToY())
            {
                Say(">> Debug : 두 선이 Y축과 평행합니다.");
                Console.WriteLine(
                    IsLinesCrossInOneLine(
                        Math.Min(lineA.startY, lineA.endY), 
                        Math.Max(lineA.startY, lineA.endY), 
                        Math.Min(lineB.startY, lineB.endY), 
                        Math.Max(lineB.startY, lineB.endY))
                    ? "1" : "0");
                return;
            }
            else if (lineA.IsParallelToY())
            {
                Say(">> DEBUG : 첫 번째 선은 Y축과 평행합니다.");
                Console.WriteLine(
                    lineA.ISInsideRangeY(
                        lineB.GetY(startX).pointA
                        )
                    ? "1" : "0");
                return;
            }
            else if (lineB.IsParallelToY())
            {
                Say(">> DEBUG : 두 번째 선은 Y축과 평행합니다.");

                Console.WriteLine(
                    lineB.ISInsideRangeY(
                        lineA.GetY(startX).pointA
                        )
                    ? "1" : "0");
                return;
            }
            else
            {
                // 해피 루트입니다.
                Say(">> DEBUG : 두 선은 Y축과 평행하지 않습니다.");
                bool result =
                    ((lineA.GetY(startX).pointA - lineB.GetY(startX).pointA) *
                    (lineA.GetY(endX).pointA - lineB.GetY(endX).pointA)) <= 0;

                Console.WriteLine(result ? "1" : "0");
            }
        }
    }
}
