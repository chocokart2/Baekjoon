using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5430try1
{
    internal class Program
    {
        // 객체 없이 단일 함수 호출로 결과를 리턴하는 방식을 채택했습니다. but... 더 쪼갤 수 있네요

        static string GetResult(string commands, int[] array)
        {
            StringBuilder result = new StringBuilder();
            bool isReverse = false; // 배열의 순서가 역순인가요?
            int firstIndex = 0; // 원소의 가장 첫번째 인덱스
            int rearIndex = array.Length - 1; // 마지막 원소의 인덱스
            int[] outArray = new int[array.Length]; // D커맨드로 출력될 배열


            for (int cursor = 0; cursor < commands.Length; ++cursor)
            {
                switch (commands[cursor])
                {
                    case 'R':
                        isReverse = !isReverse;
                        break;
                    case 'D':
                        // 첫 인덱스 > 뒷 인덱스인지 판단하기 => 만약 그렇다면 에러를 내뿜습니다.
                        if (firstIndex > rearIndex) return "error";

                        // isReverse에 따라서 앞에서 뺄지 뒤에서 뺄지를 결정합니다.
                        // ㄴ해당하는 인덱스를 한칸 옆으로 뺍니다.
                        if (isReverse)
                        {
                            --rearIndex;
                        }
                        else
                        {
                            ++firstIndex;
                        }
                        break;
                    default:
                        throw new Exception($"bad command : {commands[cursor]} of {commands}");
                }
            }

            int index;
            if (isReverse) index = rearIndex;
            else index = firstIndex;
            result.Append("[");
            for(;firstIndex <= index && index <= rearIndex ;)
            {
                result.Append($"{array[index]},");

                if (isReverse) --index;
                else ++index;
            }
            if(firstIndex > rearIndex == false)
                result.Remove(result.Length - 1, 1);
            result.Append("]");
            return result.ToString();
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string command = Console.ReadLine();
                
                Console.ReadLine();

                string rawArray = Console.ReadLine();
                rawArray = rawArray.Substring(1, rawArray.Length - 2);
                string[] numbers = rawArray.Split(',');
                int[] numArray = {};
                if (rawArray.Length > 0)
                {
                    numArray = new int[numbers.Length];
                    for (int index = 0; index < numArray.Length; ++index)
                        numArray[index] = int.Parse(numbers[index]);
                }


                Console.WriteLine(GetResult(command, numArray));
            }
        }
    }
}
