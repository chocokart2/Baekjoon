using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1025try1
{
    internal class Program
    {
        class NumTree
        {
            public NumTree[] daughterTree; // 존재하는 다음 자리의 자릿수입니다.

            public NumTree()
            {
                daughterTree = new NumTree[10];
            }

            public bool IsSquareNumber(int index, char[] number)
            {
                if (index == 9) return true; // number은 Length가 9이므로, 해당 숫자가 존재함으로 판정합니다. 인덱스가 9이상이면 에러를 내뿜습니다.

                int num = number[index] - '0';
                if (daughterTree[num] == null) return false;
                return daughterTree[num].IsSquareNumber(index + 1, number);
            }
        }

        // 9자리 숫자를 만듭니다. 9보다 작은 자리 갯수의 숫자가 들어오면, 왼쪽 빈칸을 0으로 채웁니다.
        //static char[] FillZeroPadding(char[] target)
        //{

        //}

        static int ConvertToInt(char[] numTarget)
        {
            int result = 0;
            int ten = 1;
            
            for (int index = numTarget.Length - 1; index > -1; --index)
            {
                ten *= 10;
                if (index == numTarget.Length - 1) ten = 1;

                result += (numTarget[index] - '0') * ten;
            }

            return result;
        }

        static void Main(string[] args)
        {
            // char의 배열을 제공하면 이 객체는 해당 숫자가 완전 제곱수인지 판단할 것입니다.
            // 약 120KB정도 소비하며, 9번의 탐색으로 해당 숫자가 완전 제곱수인지 판정할 수 있습니다.
            NumTree sqrNums = new NumTree();
            for (int i = 0; i <= 31_622; ++i)
            {
                string squareNumOne = (i * i).ToString();
                Console.WriteLine($"squareNumOne = {squareNumOne}");
                NumTree one = sqrNums;
                for (int index = 0; index < 9 - squareNumOne.Length; ++index) // one이 9자리보다 작은경우, 나머지 왼쪽의 빈 칸은 0으로 채웁니다.
                {
                    if (one.daughterTree[0] == null) one.daughterTree[0] = new NumTree();
                    one = one.daughterTree[0];
                }
                for (int index = squareNumOne.Length - 1; index > -1; ++index)
                {
                    Console.WriteLine(index);
                    int oneIndex = squareNumOne[index] - '0';
                    if (one.daughterTree[oneIndex] == null) one.daughterTree[oneIndex] = new NumTree();
                    one = one.daughterTree[oneIndex];
                }
            }

            // ===
            
            // 표 init
            string sizeRecvLine = Console.ReadLine();
            int xSize = sizeRecvLine[2] - '0';
            int ySize = sizeRecvLine[0] - '0';
            char[,] nums = new char[xSize, ySize]; // access : nums[x, y]
            for (int yIndex = 0; yIndex < ySize; ++yIndex)
            {
                string oneRecvLine = Console.ReadLine();

                for (int xIndex = 0; xIndex < xSize; ++xIndex)
                {
                    nums[xIndex, yIndex] = oneRecvLine[xIndex];
                }
            }

            // ===

            // 가능한 모든 경우의 수를 선택하는 과정입니다. 그리고 가장 큰 숫자를 가립니다.
            // 시작지점을 선택하는 루프, X등차, Y등차를 선택하는 루프,
            // 루프가 여러겹이기 때문에, 단일 while문을 사용하겠습니다.
            //int startX = 0;
            //int startY = 0;
            //int dX = 1; // x좌표로 변할 인덱스 // 서로 다른 칸을 선택해야 하므로, dX와 dY가 동시에 0이 될 수 없습니다 // !음수가 될 수 있습니다// 절댓값은 x크기 이내.
            //int dY = 0;
            //int max = 0; // char의 배열이 완전 제곱수인지 판별이 났을 때, 그 배열을 숫자로 변환하고, 해당 숫자들중 가장 큰 숫자를 저장하는 변수입니다.
            // 시작지점을 지정할때도 완전 제곱수인지 확인하고, dx, dy로 자리를 도약하여 숫자를 늘려갈 때마다, 해당 숫자가 완전 제곱수인지 확인합니다.

            int max = -1;

            // 4만번 x 9회를 돌 루프입니다.
            for (int startX = 0; startX < xSize; ++startX) // 10회 반복
            {
                for (int startY = 0; startY < ySize; ++startY) // 10회 반복
                {
                    for (int dX = -xSize + 1; dX < xSize; ++dX) // 20회 반복
                    {
                        for (int dY = -ySize + 1; dY < ySize; ++dY) // 20회 반복
                        {
                            if (dX == 0 && dY == 0) continue; // dx와 dy가 동시에 0이면 서로 다른 숫자를 선택할 수 없숩니다.

                            char[] numSlot = new char[9];
                            for (int coefficient = 0; ; coefficient++)
                            {
                                int x = startX + dX * coefficient;
                                int y = startY + dY * coefficient;
                                if (x < 0 || x >= xSize || y < 0 || y >= ySize) continue;

                                numSlot[8 - coefficient] = nums[x, y];
                                if (sqrNums.IsSquareNumber(0, numSlot) == false) continue;
                                int oneNum = ConvertToInt(numSlot);
                                
                                if (max > oneNum) max = oneNum;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
