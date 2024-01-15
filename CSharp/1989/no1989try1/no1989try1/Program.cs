using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1989try1
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

            private const bool M_IS_DEBUGGING = true;
            private int functionCalledCount = 0;

            public SegmentTree(T[] data, Function function)
            {
                originalData = data;
                treeFunction = function;

                int m_size = 1;
                while (m_size * m_size <= originalData.Length)
                    m_size++;

                tree = new T[m_size * m_size * 2 * 10];
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
                functionCalledCount = 0;
                T returnValue = M_Find(startIndex, endIndex, 1, 0, originalData.Length - 1).returnValue;
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($">> Get({startIndex}, {endIndex}) Done : Function Called Count = {functionCalledCount}");
                }
                return returnValue;
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
                    functionCalledCount++;
                    Console.WriteLine($">> Function Called : M_Find(find[{targetStartIndex} ~ {targetEndIndex}], {currentTreeIndex}, range[{originalStartIndex} ~ {originalEndIndex}]);");
                }

                // 찾는 범위 < 데이터 범위 or 데이터 범위 < 찾는 범위인 경우
                if (originalStartIndex > targetEndIndex || originalEndIndex < targetStartIndex)
                {
                    if (M_IS_DEBUGGING) //Console.WriteLine(">> out of range");
                    return (false, default);
                }
                // 찾는 범위 시작 <
                if (targetStartIndex <= originalStartIndex && originalEndIndex <= targetEndIndex)
                {
                    if (M_IS_DEBUGGING) //Console.WriteLine($">> Range is inside Target : find = [{targetStartIndex} ~ {targetEndIndex}], dataRange = [{originalStartIndex} ~ {originalEndIndex}]");
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
                    //Console.WriteLine($"left(index = {currentTreeIndex * 2}, range = [{originalStartIndex} ~ {originalMiddleIndex}]) = {left.isFound}, {left.returnValue}");
                    //Console.WriteLine($"left(index = {currentTreeIndex * 2 + 1}, range = [{originalMiddleIndex + 1} ~ {originalEndIndex}]) = {right.isFound}, {right.returnValue}");
                }

                if (left.isFound && right.isFound) return (true, treeFunction(left.returnValue, right.returnValue));
                if (left.isFound) return left;
                else return right;

                // 둘다 찾은 경우 treeFunction 함수 호출하고, 연산 후 리턴
                // 둘중 하나만 찾은경우 존재하는 값만 리턴
                // 둘다 못찾은 경우 false 리턴
            }
        }
        static long[] arr;
        static SegmentTree<long> maxSegTree;
        static long GetSegMax(int start, int end)
        {
            if (start == end) return arr[start] * arr[start];
            int mid = (start + end) / 2;
            long leftSide = GetSegMax(start, mid);
            long rightSide = GetSegMax(mid + 1, end);
            long result = Math.Max(leftSide, rightSide);


            
        }


        static void Main(string[] args)
        {
            // 구간 함 + 세그먼트 트리(최솟값)
            int bufferSize = 800_000;
            StreamReader readStream = new StreamReader(Console.OpenStandardInput(bufferSize));

            readStream.ReadLine();
            string[] nums = readStream.ReadLine().Split(' ');
            long[] numberArr = new long[nums.Length];
            long[] sum = new long[nums.Length + 1];
            for (int index = 0; index < nums.Length; index++)
            {
                numberArr[index] = int.Parse(nums[index]);
                sum[index + 1] = numberArr[index] + sum[index];
            }

            SegmentTree<long> segTree = new SegmentTree<long>(numberArr, Math.Min);

            long maxVal = long.MinValue;
            long start = -1;
            long end = -1;
            for (int startIndex = 0; startIndex < nums.Length; ++startIndex)
            {
                for (int endIndex = startIndex; endIndex < nums.Length; ++endIndex)
                {
                    long one = (sum[endIndex + 1] - sum[startIndex]) * segTree.Get(startIndex, endIndex);
                    //Console.WriteLine($"{startIndex} ~ {endIndex} => sum = {(sum[endIndex + 1] - sum[startIndex])}, val = {one}");
                    if (maxVal < one)
                    {
                        maxVal = one;
                        start = startIndex;
                        end = endIndex;
                    }
                }
            }
            Console.WriteLine($"{maxVal}\n{start + 1} {end + 1}");

            readStream.Close();
        }
    }
}
