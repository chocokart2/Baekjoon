using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11650try1
{
    internal class Program
    {
        // 메모리 초과를 방지합니다.
        static Vector2[] temporaryMemory;

        struct Vector2 : IComparable<Vector2>
        {
            public int x;
            public int y;
            
            public int CompareTo(Vector2 target)
            {

                if (x < target.x) return -1;
                else if (x > target.x) return 1;
                else
                {
                    if (y < target.y) return -1;
                    else if (y > target.y) return 1;
                    else return 0;
                }
            }

            public override string ToString()
            {
                return $"{x} {y}";
            }
        }

        static Vector2[] Merge(Vector2[] original, int pos, int size1, int size2)
        {
            for (int index = 0; index < original.Length; ++index) temporaryMemory[index] = original[index];

            int cursor2End = Math.Min(pos + (size1 << 1), original.Length); // 끝의 다음 인덱스 < 연산자 사용

            for (int cursorResult = pos, cursor1 = pos, cursor2 = pos + size1;
                (cursor1 < pos + size1) || (cursor2 < cursor2End);)
            {
                if (cursor1 >= pos + size1)
                {
                    //Console.WriteLine(">>[1] label put second");
                    temporaryMemory[cursorResult] = original[cursor2];
                    ++cursorResult;
                    ++cursor2;
                }
                else if (cursor2 >= pos + size1 + size2)
                {
                    //Console.WriteLine(">>[2] label put first");
                    temporaryMemory[cursorResult] = original[cursor1];
                    ++cursorResult;
                    ++cursor1;
                }
                else if (original[cursor1].CompareTo(original[cursor2]).Equals(-1))
                {
                    //Console.WriteLine(">>[3] label put first");
                    temporaryMemory[cursorResult] = original[cursor1];
                    ++cursorResult;
                    ++cursor1;
                }
                else
                {
                    //Console.WriteLine(">>[4] label put second");
                    temporaryMemory[cursorResult] = original[cursor2];
                    ++cursorResult;
                    ++cursor2;
                }
            }
            return temporaryMemory;
        }

        static Vector2[] MergeSort(Vector2[] posArray)
        {
            for (int size = 1; size <= posArray.Length; size <<= 1)
            {
                for (int cursor = 0; cursor < posArray.Length; cursor += (size << 1))
                {
                    // 잘라서 두 배열 구하기
                    if (posArray.Length - 1 < cursor + size) // 여기서 잘못됬구나 len : 3, cur : 0, size 2일때 반례
                        // 두번째 파트의 length가 0 이하일때 통과
                        // => 커서 + 사이즈가 length보다 크다(음수) or 커서 + 사이즈(두번째 시작지점)가 length와 같다. (0)
                    {
                        //Console.WriteLine("For 루프 : 컷!");
                        break;
                    }
                    // 첫번째 사이즈는 size입니다 아니라면 이미 걸러졌습니다.
                    // 두번째 사이즈는 size와 동일하나, 시작점부터 어레이의 끝점까지의 길이가 size보다 작으면 그 사이즈로 정합니다.

                    // 풀어 쓰기  //int secondSize = posArray.Length > cursor + (size << 1) ? size : (posArray.Length - cursor - size - 1);
                    //int secondSize = posArray.Length >= cursor + (size << 1) ? size : (posArray.Length - cursor - size - 1);

                    int secondSize;
                    //Console.WriteLine($"For루프 : posArray.Length = {posArray.Length}, cursor({cursor}) + (size({size}) << 1) = {cursor + (size << 1)}");
                    if (posArray.Length >= cursor + (size << 1)) // 두번째 덩어리의 끝점의 다음 인덱스이기 때문
                    {
                        //Console.WriteLine("두번째 값은 사이즈 그대로 들어갑니다");
                        secondSize = size;
                    }
                    else
                    {
                        //Console.WriteLine("공간이 부족하여 두번째 값을 깎습니다.");
                        secondSize = posArray.Length - cursor - size - 1;
                    }

                    // 자른 두 배열을 병합하기
                    posArray = Merge(posArray, cursor, size, secondSize);
                }
            }
            return posArray;
        }

        static void Main(string[] args)
        {
            // 값을 받고 리턴함

            int count = int.Parse(Console.ReadLine());
            Vector2[] positions = new Vector2[count];
            //temporaryMemory = new Vector2[count];
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < count; ++index)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                positions[index] = new Vector2() { x = int.Parse(inputs[0]), y = int.Parse(inputs[1]) };
            }
            Array.Sort(positions);
            //positions = MergeSort(positions);
            for (int index = 0; index < positions.Length; ++index)
                stringBuilder.Append($"{positions[index].ToString()}\n");
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
// 기수정렬
// 삽입 정보 
// 정렬을 위한 정보 -> 삽입 정보로
