using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1308try1
{
    internal class Program
    {
        static readonly int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // 그 해의 몇번째 날인지 계산합니다.
        static int GetDays(int year, int month, int date)
        {
            int result = 0;
            if (IsLeapYear(year) && month > 2) result += 1;
            for (int m = 0; m < month - 1; ++m)
            {
                result += daysInMonth[m];
            }
            result += date;
            return result;
        }

        static bool IsLeapYear(int year)
        {
            if (year % 400 == 0) return true;
            else if (year % 100 == 0) return false;
            else if (year % 4 == 0) return true;
            return false;
        }

        static void Main(string[] args)
        {
            string[] startString = Console.ReadLine().Split(' ');
            int[] start = new int[] { int.Parse(startString[0]), int.Parse(startString[1]), int.Parse(startString[2])};
            string[] endString = Console.ReadLine().Split(' ');
            int[] end = new int[] { int.Parse(endString[0]), int.Parse(endString[1]), int.Parse(endString[2]) };

            // 1000년보다 같거나 긴 경우 얼리 리턴
            // 연도 필터
            if (end[0] - start[0] > 1000)
            {
                Console.WriteLine("gg");
                return;
            }
            else if (end[0] - start[0] == 1000)
            {
                // 달 필터
                if (end[1] - start[1] > 0)
                {
                    Console.WriteLine("gg");
                    return;
                }
                // 날짜 필터
                else if (end[1] == start[1] && end[2] >= start[2])
                {
                    Console.WriteLine("gg");
                    return;
                }
            }

            int result = GetDays(end[0], end[1], end[2]) - GetDays(start[0], start[1], start[2]);
            //result += 365 * (end[0] - start[0]);
            for (int y = start[0]; y < end[0]; ++y)
            {
                if (IsLeapYear(y)) result += 366;
                else result += 365;
            }

            Console.WriteLine($"D-{result}");
        }
    }
}
