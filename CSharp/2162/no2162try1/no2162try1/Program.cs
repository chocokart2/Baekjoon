using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2162try1
{
    internal class Program
    {
        static class LineSegmentIntersection
        {
            public class BadLineSyntaxException : Exception
            {
                public BadLineSyntaxException() : base("선분을 표현하는 배열의 형식이 잘못되었습니다. 한 선분을 표현하는 배열의 올바른 형식 : {시작x, 시작y, 종료x, 종료y}") { }
                public BadLineSyntaxException(string message) : base(message) { }
            }

            private const bool IS_DEBUGGING = false;
            private const int START_X = 0;
            private const int START_Y = 1;
            private const int END_X = 2;
            private const int END_Y = 3;

            public static bool IsTwoLineMeet1D(double[] LineA, double[] LineB)
            {
                if ((LineA.Length != 2) || (LineB.Length != 2)) throw new BadLineSyntaxException();

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
                        (isLineParraelToY[1]) ? LineA : LineB;
                    double[] lineParrelToY =
                        (isLineParraelToY[0]) ? LineA : LineB;

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
        public class DisjointSetInt // 서로소 집합
        {
            public int[] Origin { get => parent; }
            private int[] parent;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="size">
            ///     서로소 집합의 갯수. 이때, 이후의 함수들은 0-기반으로하는 인덱싱입니다.
            /// </param>
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
            public int GetSetCount()
            {
                int result = 0;
                for (int index = 0; index < parent.Length; ++index)
                {
                    if (index == parent[index]) result++;
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            double[][] lines = new double[int.Parse(Console.ReadLine())][];
            int[] size = new int[lines.Length];
            for (int index = 0; index < size.Length; ++index)
            {
                size[index] = 1;
            }
            DisjointSetInt set = new DisjointSetInt(lines.Length);

            for (int index = 0; index < lines.Length; ++index)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                lines[index] = new double[]
                {
                    double.Parse(recvLine[0]),
                    double.Parse(recvLine[1]),
                    double.Parse(recvLine[2]),
                    double.Parse(recvLine[3])
                };

                // 이전의 선과 비교해봄
                for (int prevIndex = 0; prevIndex < index; ++prevIndex)
                {
                    if (set.IsSame(index, prevIndex)) continue; // 두 선은 이미 연결된 대상
                    if (LineSegmentIntersection // 두 선이 겹쳐진 대상이 아닌 경우
                        .IsTwoLineMeet2D(lines[index], lines[prevIndex]) == false) continue;

                    size[set.Origin[index]] += size[set.Origin[prevIndex]];
                    set.Union(index, prevIndex);

                    //Console.WriteLine($">> {index + 1}번 선과 {prevIndex + 1}번 선이 크로스합니다.");
                }
            }

            Console.WriteLine(set.GetSetCount());
            int answer = 0;
            for (int index = 0; index < size.Length; ++index)
            {
                //Console.WriteLine(size[index]);
                answer = Math.Max(answer, size[index]);
            }
            Console.WriteLine(answer);
        }
    }
}
