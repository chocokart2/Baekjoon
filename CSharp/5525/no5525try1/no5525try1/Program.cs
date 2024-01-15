using System;

namespace no5525try1
{
    internal class Program
    {
        const int UNSTACKED = 10;
        const int STACKING = 11;

        static int GetCount(int source, int target) => source - target + 1;

        static void Main(string[] args)
        {
            int result = 0;
            // 스트링에 몇레벨 IOIOI인지 저장한다.
            // N레벨은 X레벨이 N - X + 1개만큼 있다.


            // 문자열 => 각각의 덩어리가 몇레벨인지를 저장한다.
            // ㄴ만약 I를 발견
            // 이후에 OI가 몇개나 연속적으로 이어져 있는지 체크한다.
            int targetLevel = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            string S = Console.ReadLine();
            int[] mountains = new int[length];
            int mountainsIndex = -1;
            bool isStacking = false;

            for (int index = 0; index < length; ++index)
            {
                if (isStacking)
                {
                    if (index + 1 == length) break;
                    if (S[index] == 'O' && S[index + 1] == 'I')
                    {

                        mountains[mountainsIndex]++;
                        ++index;
                    }
                    else if (S[index] == 'I')
                    {
                        ++mountainsIndex;
                    }
                    else
                    {
                        isStacking = false;
                    }
                }
                else
                {
                    if (S[index] == 'I')
                    {
                        // 이후 두 원소가 'O'와 'I'인지 판정한다. 그리고 반복하며 레벨을 올린다!
                        isStacking = true;
                        ++mountainsIndex;
                    }
                }
            }

            for (int index = 0; index <= mountainsIndex; ++index)
            {

                //debug
                //Console.WriteLine($"DEBUG : mountains[{index}] = {mountains[index]}");
                int single = GetCount(mountains[index], targetLevel);
                result += single > 0 ? single : 0;
            }

            

            Console.WriteLine(result);
        }
    }
}
