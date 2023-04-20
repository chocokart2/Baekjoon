using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7662try1
{
    internal class Program
    {
        private class DualPriorityQueue
        {

            const int EMPTY_QUEUE_LENGTH = 1;
            int[] data; // 가장 작은 값부터 가장 큰 값 순으로 정렬합니다. 인덱스가 낮을수록 낮은 값이 들어갑니다.
            int length;

            public DualPriorityQueue()
            {
                data = new int[1_000_001];
                data[0] = int.MinValue; // data[0]은 알고리즘을 위한 임시적 값입니다. 수정하면 안 됩니다.
                length = 1;
            }

            // 위치를 찾고 배열에 집어넣습니다.
            public void Insert(int value) // O(LogN + N)
            {
                int inputIndex = 0; // 여기서 -1이 리턴함.

                if(length > EMPTY_QUEUE_LENGTH)
                {
                    inputIndex = mFindIndex(value); // 여기서 -1이 리턴함.
                    // 사이에 빈공간을 하나 만들어야 하니까 인덱스를 한칸 위로 SHIFT합니다.
                    for (int index = length; index > inputIndex; --index)
                    {
                        data[index] = data[index - 1];
                    }
                }
                data[inputIndex] = value;
                ++length;
            }
            public override string ToString()
            {
                if (mIsEmpty()) return "EMPTY";
                return $"{data[length - 1]} {data[0]}";
            }
            public void DeleteLarge() //O(1)
            {
                if (mIsEmpty()) return;
                --length;
            }
            public void DeleteSmall() // O(N)
            {
                if (mIsEmpty()) return;
                for (int index = 1; index + 1 < length; ++index)// 시작 점부터 한칸씩 아래로 SHIFT합니다.
                {
                    data[index] = data[index + 1];
                }
                --length;
            }

            private bool mIsEmpty()
            {
                return length.Equals(1);
            }
            private int mFindIndex(int value) // O(logN)
            {
                // 값을 비교하고 적절한 위치에 삽입한다.
                int firstIndex = 1;
                int lastIndex = length - 1;
                int middleIndex = 1;
                while (lastIndex >= firstIndex)
                {
                    middleIndex = (firstIndex + lastIndex) >> 1;
                    switch (mCheckRightPosition(middleIndex, value))
                    {
                        case 0:
                            return middleIndex + 1;
                            break;
                        case -1:
                            lastIndex = middleIndex - 1;
                            break;
                        case 1:
                            firstIndex = middleIndex + 1;
                            break;
                        default:
                            throw new OutOfMemoryException(); // this is error value
                    }
                    // 여기서 값 변경하는거 있어야지
                    //Console.WriteLine($"mFindIndex() while 작동 : firstIndex={firstIndex}, lastIndex={lastIndex}");
                }
                return middleIndex + 1;
            }
            // 값을 삽입할 때 이 값이 옳은 위치인지 나타냅니다. index + 1에 값이 들어갈 예정 (data[index] <= value && value <= data[index + 1])인지 체크합니다.
            private int mCheckRightPosition(int index, int value)
            {
                if (index >= length) return int.MinValue; // 범위를 벗어나는 값입니다.

                // 오른쪽과 왼쪽을 비교((if exist : data[index] <=) value && value (if exist : <= data[index + 1]))했을 때 맞는 포지션인지 알아냅니다.
                if (index > -1) if (data[index] > value) return -1; // 인덱스 값을 낮추세요
                if (index + 1 < length) // lastIndex가 length - 1입니다. 따라서 lastindex보다 index가 클때 비교합니다
                    if (data[index + 1] < value) return 1; // 인덱스 값을 높이세요
                return 0;
            }
        }

        private static DualPriorityQueue queue = new DualPriorityQueue();
        private static StringBuilder answer = new StringBuilder();

        private static void TestCase()
        {
            queue = new DualPriorityQueue();
            // 명령 받기
            int commandCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < commandCount; ++i)
            {
                string command = Console.ReadLine();
                switch (command[0])
                {
                    case 'I':
                        queue.Insert(int.Parse(command.Split(' ')[1]));
                        break;
                    case 'D':
                        if (command[2].Equals('1')) queue.DeleteLarge();
                        else queue.DeleteSmall();
                        break;
                    default: // 의도하지 않은 입력
                        break;
                }
            }
            // 값 호출
            answer.Append($"{queue.ToString()}\n");
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
                TestCase();
            Console.WriteLine(answer);
        }
    }
}
