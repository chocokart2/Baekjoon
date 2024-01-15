using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10868try1
{
    internal class Program
    {
        public class SegmentTree<T>
        {
            //장충동 왕족발 보쌈
            //이거보세요오
            //이르케 이러케 이렇게

            public T[] originalData;
            public T[] tree;
            public delegate T Function(T left, T right); // example int Add(int left, int right) => left + right;
            Function treeFunction;

            private const bool M_IS_DEBUGGING = false;

            public SegmentTree(T[] data, Function function)
            {
                originalData = data;
                treeFunction = function;

                int m_size = 1;
                while (m_size * m_size <= originalData.Length)
                    m_size++;

                tree = new T[m_size * m_size * 2 * 2];
                M_Init(0, data.Length - 1, 1);
            }
            public string GetTreeString(bool showIndex = false)
            {
                StringBuilder result = new StringBuilder();
                if (showIndex)
                {
                    for (int index = 0; index < tree.Length; ++index)
                    {
                        result.Append($"tree[{index}] = {tree[index].ToString()}\n");
                    }
                }
                else
                {
                    for (int index = 0; index < tree.Length; ++index)
                    {
                        result.Append($"{tree[index].ToString()} ");
                    }
                }
                return result.ToString();
            }
            public T Get(int startIndex, int endIndex)
            {
                return M_Find(startIndex, endIndex, 1, 0, originalData.Length - 1).returnValue;
            }



            private T M_Init(int dataStartIndex, int dataEndIndex, int treeIndex)
            {
                if (dataStartIndex == dataEndIndex)
                {
                    tree[treeIndex] = originalData[dataStartIndex];
                    return tree[treeIndex];
                }

                int dataMiddleIndex = (dataStartIndex + dataEndIndex) / 2;
                tree[treeIndex] =
                    treeFunction(
                        M_Init(dataStartIndex, dataMiddleIndex, treeIndex * 2),
                        M_Init(dataMiddleIndex + 1, dataEndIndex, treeIndex * 2 + 1));
                return tree[treeIndex];
            }
            private (bool isFound, T returnValue) M_Find(int targetStartIndex, int targetEndIndex, int currentTreeIndex, int originalStartIndex, int originalEndIndex)
            {
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($">> Function Called : M_Find(find[{targetStartIndex} ~ {targetEndIndex}], {currentTreeIndex}, range[{originalStartIndex} ~ {originalEndIndex}]);");
                }

                // 찾는 범위 < 데이터 범위 or 데이터 범위 < 찾는 범위인 경우
                if (originalStartIndex > targetEndIndex || originalEndIndex < targetStartIndex)
                {
                    if (M_IS_DEBUGGING) Console.WriteLine("out of range");
                    return (false, default);
                }
                // 찾는 범위 시작 <
                if (targetStartIndex <= originalStartIndex && originalEndIndex <= targetEndIndex)
                {
                    if (M_IS_DEBUGGING) Console.WriteLine($">> Range is inside Target : find = [{targetStartIndex} ~ {targetEndIndex}], dataRange = [{originalStartIndex} ~ {originalEndIndex}]");
                    return (true, tree[currentTreeIndex]);
                }
                // 일부분만 걸쳐져 있는 상황
                int originalMiddleIndex = (originalStartIndex + originalEndIndex) / 2;
                (bool isFound, T returnValue) left =
                    M_Find(targetStartIndex, targetEndIndex, currentTreeIndex * 2, originalStartIndex, originalMiddleIndex);
                (bool isFound, T returnValue) right =
                    M_Find(targetStartIndex, targetEndIndex, currentTreeIndex * 2 + 1, originalMiddleIndex + 1, originalEndIndex);

                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"left(index = {currentTreeIndex * 2}, range = [{originalStartIndex} ~ {originalMiddleIndex}]) = {left.isFound}, {left.returnValue}");
                    Console.WriteLine($"left(index = {currentTreeIndex * 2 + 1}, range = [{originalMiddleIndex + 1} ~ {originalEndIndex}]) = {right.isFound}, {right.returnValue}");
                }

                if (left.isFound && right.isFound) return (true, treeFunction(left.returnValue, right.returnValue));
                if (left.isFound) return left;
                else return right;

                // 둘다 찾은 경우 treeFunction 함수 호출하고, 연산 후 리턴
                // 둘중 하나만 찾은경우 존재하는 값만 리턴
                // 둘다 못찾은 경우 false 리턴
            }
        }

        static void Main(string[] args)
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            int size = int.Parse(recvLineNM[0]);
            int querry = int.Parse(recvLineNM[1]);

            int[] nums = new int[size];
            for (int index = 0; index < size; ++index)
            {
                nums[index] = int.Parse(Console.ReadLine());
            }

            SegmentTree<int> selecter = new SegmentTree<int>(nums, Math.Min);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < querry; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                result.AppendLine(selecter.Get(
                    int.Parse(recvLine[0]) - 1,
                    int.Parse(recvLine[1]) - 1
                    ).ToString());
            }

            Console.Write(result);
        }
    }
}
