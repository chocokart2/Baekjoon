using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;

namespace testing
{
    internal class Program
    {
        public class LongestIncreasingSubsequence<T>
        {
            private Func<T, T, bool> IsRightFirst; // 두번째 매개변수가 앞쪽(왼쪽)에 있어야 하는지 판정하는 함수입니다.
            private List<T> source; // 배열 기반의 객체입니다만, 동적으로 늘어날 수 있습니다.
            private int lisPosition = 0;


            public LongestIncreasingSubsequence(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                M_Init(_sourse, isRightFirst);
            }
            public LongestIncreasingSubsequence(T[] _sourse, Func<T, T, bool> isRightFirst)
            {
                M_Init(_sourse.ToList(), isRightFirst);
            }


            static T[] GetLIS(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                return new T[0];
            }
            static T[] GetLIS(T[] _sourse, Func<T, T, bool> isRightFirst)
                => GetLIS(_sourse.ToList(), isRightFirst);
            static int[] GetLIS(int[] _sourse)
                => LongestIncreasingSubsequence<int>.GetLIS(
                    _sourse.ToList(),
                    delegate (int left, int right)
                    {
                        return left > right;
                    }
                    );

            private void M_Init(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                source = _sourse;
                IsRightFirst = isRightFirst; 
                M_BuildSubsequence();
            }
            private void M_BuildSubsequence()
            {
                

            }
        }
        static long[] GetPrimeNumArray(long range)
        {
            List<long> resultList = new List<long>();

            for (long i = 2; i < range; ++i)
            {
                bool isPrimeNum = true;
                for (int index = 0; index < resultList.Count; ++index)
                {
                    if (i % resultList[index] == 0)
                    {
                        isPrimeNum = false;
                        break;
                    }
                }
                if (isPrimeNum) resultList.Add(i);
            }
            return resultList.ToArray();
        }

        public class DisjointSetInt // 서로소 집합
        {
            private int[] parent;

            public DisjointSetInt(int size)
            {
                parent = new int[size];
                for (int index = 0; index < size; ++index)
                {
                    parent[index] = index;
                }
            }
            public bool IsSame(int x, int y)
            {
                return FindRootRecursive(x) == FindRootRecursive(y);
            }
            public void Union(int x, int y)
            {
                parent[FindRootRecursive(y)] = FindRootRecursive(x);
            }
            public int FindRootRecursive(int target)
            {
                if (parent[target] == target) return target; // 재귀의 종료
                int root = FindRootRecursive(parent[target]);
                parent[target] = root; // 경로 압축
                return root;
            }
        }
        static class LineSegmentIntersection
        {
            public class BadLineSyntaxException : Exception
            {
                public BadLineSyntaxException() : base("선분을 표현하는 배열의 형식이 잘못되었습니다. 한 선분을 표현하는 배열의 올바른 형식 : {시작x, 시작y, 종료x, 종료y}") { }
                public BadLineSyntaxException(string message) : base(message) { }
            }

            private const int START_X = 0;
            private const int START_Y = 1;
            private const int END_X = 2;
            private const int END_Y = 3;

            public static bool IsTwoLineMeet1D(double[] LineA, double[] LineB)
            {
                if ((LineA.Length != 2) || (LineB.Length != 2))
                    throw new BadLineSyntaxException(
                        "선분을 표현하는 배열의 형식이 잘못되었습니다. 한 선분을 표현하는 배열의 올바른 형식 : {시작, 종료}"
                        );

                double LineAMin = Math.Min(LineA[0], LineA[1]);
                double LineBMin = Math.Min(LineB[0], LineB[1]);
                double LineAMax = Math.Max(LineA[0], LineA[1]);
                double LineBMax = Math.Max(LineB[0], LineB[1]);

                if (LineAMax < LineBMin) return false;
                if (LineBMax < LineAMin) return false;
                return true;
            }
            public static bool IsTwoLineMeet2D(double[] LineA, double[] LineB)
            {
                if ((LineA.Length != 4) || (LineB.Length != 4)) throw new BadLineSyntaxException();

                // y값이 맞는 순간을 체크합니다.
                bool[] isLineParraelToY = new bool[2];
                if (LineA[START_X] == LineA[END_X]) isLineParraelToY[0] = true;
                if (LineB[START_X] == LineB[END_X]) isLineParraelToY[1] = true;

                if (isLineParraelToY[0] && isLineParraelToY[1])
                {
                    if (LineA[0] != LineB[0]) return false;
                    return IsTwoLineMeet1D(
                        new double[2] { LineA[START_Y], LineA[END_Y] },
                        new double[2] { LineB[START_Y], LineB[END_Y] }
                        );
                }
                else if (isLineParraelToY[0] || isLineParraelToY[1])
                {
                    if (IsTwoLineMeet1D(
                        new double[2] { LineA[START_X], LineA[END_X] },
                        new double[2] { LineB[START_X], LineB[END_X] }
                        ) == false) return false;

                    double[] lineNotParrelToY =
                        (LineA[START_X] != LineA[END_X]) ? LineA : LineB;
                    double[] lineParrelToY =
                        (LineA[START_X] == LineA[END_X]) ? LineA : LineB;

                    double pointX = lineParrelToY[START_X];
                    double _y = GetY2DLine(pointX, lineNotParrelToY);
                    return IsTwoLineMeet1D(
                        new double[2] { lineParrelToY[START_Y], lineParrelToY[END_Y] },
                        new double[2] { _y, _y });
                }
                else
                {
                    double LineAMinX = Math.Min(LineA[START_X], LineA[END_X]);
                    double LineBMinX = Math.Min(LineB[START_X], LineB[END_X]);
                    double LineAMaxX = Math.Max(LineA[START_X], LineA[END_X]);
                    double LineBMaxX = Math.Max(LineB[START_X], LineB[END_X]);

                    if (LineAMaxX < LineBMinX) return false;
                    if (LineBMaxX < LineAMinX) return false;

                    // 공통된 정의역을 구한다.
                    double startX = Math.Max(LineAMinX, LineBMinX);
                    double endX = Math.Min(LineAMaxX, LineBMaxX);

                    double startY = GetY2DLine(startX, LineA) - GetY2DLine(startX, LineB);
                    double endY = GetY2DLine(endX, LineA) - GetY2DLine(endX, LineB);

                    if (startY * endY > 0.0f) return false;
                    else return true;
                }

            }
            public static double GetY2DLine(double inputX, double[] line)
            {
                return (inputX - line[START_X])
                    * (line[END_Y] - line[START_Y])
                    / (line[END_X] - line[START_X]) + line[START_Y];
            }
        }

        static void Main(string[] args)
        {
            // 어떤 LIS 클래스
            // static 함수 LisON2: O(n^2)
            // static 함수 LisONLogN: O(N Log N)

            // 인스턴스
            // 리스트 기반 값 배열 (추가와 확인만 가능, 이전 값이 변경되게 되면, LIS가 호출됨)
            // LIS를 지원하는 배열
            // LIS 결과값
            // 백트래킹을 통해 얻어낸 LIS의 배열값.
            //
            // LIS 함수
            // LIS 추가 함수
            // 값 추가 함수
            // 값 확인 함수
            // 게으른 값 변경 함수
            // LIS 업데이트 함수

            double[] LineA = new double[]
            {
                0.0, 1.0,
                0.0, 5.0
            };
            double[] LineB = new double[]
            {
                0.0, 7.0,
                0.0, 5.0
            };

            Console.WriteLine(
                LineSegmentIntersection.IsTwoLineMeet2D(LineA, LineB)
                );


        }
    }
}
