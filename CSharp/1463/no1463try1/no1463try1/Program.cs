using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1463try1
{
    internal class Program
    {
        const int EMPTY = -1;
        const int FALSE = -2;

        static int[] memory = Enumerable.Repeat(EMPTY, 1000001).ToArray(); // 값을 기억해둡니다.
        // 3으로 나누는 연산자는 비트 연산보다 훨씬 느립니다.
        // 첫 1바이트는 3으로 나뉘어지는지 저장합니다. (0x00 = unknown, 0x01 = true, 0x02 = false)
        // 나머지 세 바이트는 3으로 나눴을때의 값입니다. value >> 8을 통해 값을 구할 수 있습니다.
        static int[] divideThreeMemory = Enumerable.Repeat(EMPTY, 1000001).ToArray();

        static int[] wantedValueStack = new int[1000000]; // 찾으려는 값의 목록입니다. 재귀함수 호출시 발생하는 스택 오버플로우를 막습니다. 가장 위쪽에 있는 값은 찾으려는 값이고 아래로 내려갈수록 찾는 값이 세분화됩니다.
        static int stackCursor = EMPTY; // 스택에 가장 마지막에 들어간 값의 인덱스 번호입니다.



        static int Search(int num)
        {
            if (memory[num].Equals(EMPTY))
            {
                int a = int.MaxValue, b = int.MaxValue, c;
                if ((num % 3).Equals(0))
                {
                    a = 1 + Search(num / 3);
                }
                if ((num & 1).Equals(0))
                {
                    b = 1 + Search(num >> 1);
                }
                c = 1 + Search(num - 1);
                memory[num] = Math.Min(Math.Min(a, b), c);
            }

            return memory[num];
        }
        static int SearchWhile(int num)
        {
            if (num.Equals(1)) return 0;

            Push(num);
            do // 스택의 값을 하나씩 뽑습니다. // 값을 못 찾으면 내버려두고, 아니면 pop합니다.
            {

                int searchingNumber = Top();
                //Console.WriteLine($"{searchingNumber}->");
                bool isSearchReady = true;
                int triple = int.MaxValue, duel = int.MaxValue, plus = int.MaxValue;

                //Console.WriteLine($"memory[{searchingNumber - 1}]->{memory[searchingNumber - 1]}");
                if (memory[searchingNumber - 1].Equals(EMPTY))
                {
                    isSearchReady = false;
                    ++stackCursor;
                    wantedValueStack[stackCursor] = searchingNumber - 1;
                    //Push(searchingNumber - 1);
                }
                else plus = 1 + memory[searchingNumber - 1];

                if ((searchingNumber & 1).Equals(0))
                {
                    if (memory[searchingNumber >> 1].Equals(EMPTY))
                    {
                        isSearchReady = false;
                        ++stackCursor;
                        wantedValueStack[stackCursor] = searchingNumber >> 1;
                        //Push(searchingNumber >> 1);
                    }
                    else duel = 1 + memory[searchingNumber >> 1];
                }

                if (divideThreeMemory[searchingNumber].Equals(EMPTY))
                {
                    if ((searchingNumber % 3).Equals(0))
                    {
                        divideThreeMemory[searchingNumber] = searchingNumber / 3;
                        divideThreeMemory[searchingNumber] = divideThreeMemory[searchingNumber] << 8;
                        divideThreeMemory[searchingNumber] = divideThreeMemory[searchingNumber] | 1;
                    }
                    else
                    {
                        divideThreeMemory[searchingNumber] = 2;
                    }
                }
                if ((divideThreeMemory[searchingNumber] & 1).Equals(1))
                {
                    int divideThree = divideThreeMemory[searchingNumber] >> 8;
                    if (memory[divideThree].Equals(EMPTY))
                    {
                        isSearchReady = false;
                        ++stackCursor;
                        wantedValueStack[stackCursor] = divideThree;
                        //Push(divideThree);
                    }
                    else triple = 1 + memory[divideThree];
                }

                if (isSearchReady)
                {
                    memory[searchingNumber] = Math.Min(Math.Min(triple, duel), plus);
                    //Console.WriteLine($"RES-{searchingNumber}->{memory[searchingNumber]}");
                    --stackCursor;
                }
            }
            while (stackCursor.Equals(EMPTY).Equals(false));
            return memory[num];
        }
        static void Push(int value)
        {
            ++stackCursor;
            wantedValueStack[stackCursor] = value;
        }
        static int Top()
        {
            return wantedValueStack[stackCursor];
        }

        static void Main(string[] args)
        {
            memory[1] = 0;
            int receiveNum = int.Parse(Console.ReadLine());
            Console.WriteLine(SearchWhile(receiveNum));
        }
    }
}
