using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10757try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // - 자릿수 맞추기, 문자열 길이 맘ㅈ추기
            string[] numbers = Console.ReadLine().Split(' ');
            int maxLength = Math.Max(numbers[0].Length, numbers[1].Length);
            int countDifferent = numbers[0].Length - numbers[1].Length;
            if(countDifferent > 0) for (int i = 0; i < countDifferent; ++i) numbers[1] = numbers[1].Insert(0, "0");
            else for (int i = 0; i < -countDifferent; ++i) numbers[0] = numbers[0].Insert(0, "0");
            numbers[0] = numbers[0].Insert(0, "0"); numbers[1] = numbers[1].Insert(0, "0");
            // - 가장 뒷자리수부터 한자리씩 더해서 저장
            string result = "";
            int temp = 0; // 두 수를 합쳤을 때 10이 넘을때 여기에 저장.

            for(int index = maxLength; index >= 0; --index)
            {
                int singleCalculate = int.Parse(Convert.ToString(numbers[0][index])) + int.Parse(Convert.ToString(numbers[1][index])) + temp;
                if (singleCalculate > 9)
                {
                    temp = 1;
                    singleCalculate -= 10;
                }
                else
                {
                    temp = 0;
                }
                result = result.Insert(0, Convert.ToString(singleCalculate));
            }
            if (result.StartsWith("0")) result = result.Remove(0, 1);
            // - 출력
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}