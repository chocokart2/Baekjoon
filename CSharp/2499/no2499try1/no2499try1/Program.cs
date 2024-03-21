using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace no2499try1
{
    internal class Program
    {
        static sbyte size;

        // TraceBack.sum <= sum / 2이므로 최적해가 나오지 않을수도 있다.
        // 따라서 동생 입장에서도 계산해보고, 형 입장에서도 계산해본다.
        // 
        class TraceBack
        {
            public int sum;
            public sbyte currentXPosition; // 형은 증가하면서, 동생은 감소하면서 yPositions을 채웁니다.
            public sbyte[] yPositions; // 각 Y좌표에서 차지하는 땅의 갯수입니다. 형은 해당 Y좌표의 오른쪽 땅, 동생은 왼쪽 땅을 가집니다. 

            public TraceBack()
            {
                yPositions = new sbyte[size];
            }
            public TraceBack Copy()
            {
                TraceBack result = new TraceBack();
                result.sum = sum;
                result.currentXPosition = currentXPosition;
                for (int index = 0; index < yPositions.Length; index++)
                {
                    result.yPositions[index] = yPositions[index];
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            const bool IS_DEBUGGING = false;

            size = sbyte.Parse(Console.ReadLine());
            int sum = 0;
            int[,] points = new int[size, size];
            //int[,] horizontalSum = new int[size + 1, size]; // 누적 합
            int[,] verticalSum = new int[size, size + 1]; // [x, y]은 [x, 0]에서 [x, y]까지의 합을 나타냅니다.
            //TraceBack[,,] knapsackTop;
            TraceBack[,,] reuseableFarmplan; // 형이나 동생이 사용할 농장 계획서입니다.
            TraceBack bigBrother = new TraceBack() { sum = 0 };

            int[,,] yPos; // oneY를 O(1)로 찾기 위한 값입니다. 인덱스 용법 [allowedKnapsackSecond, 호출자의 x좌표 + 1, 호출자의 y좌표] = 해당 Y 라인중(Y가 0부터 시작하여 Y값일때까지)에서 가장 값이 큰 값.
            int knapSackLimit;
            for (int y = 0; y < size; ++y)
            {
                string[] oneLine = Console.ReadLine().Split(' ');
                for (int x = 0; x < size; ++x)
                {
                    points[x, y] = int.Parse(oneLine[x]);
                    sum += points[x, y];
                    //horizontalSum[x + 1, y] = points[x, y] + horizontalSum[x, y];
                    verticalSum[x, y + 1] = points[x, y] + verticalSum[x, y];
                }
            }
            knapSackLimit = sum / 2; // sum <= 40000, knapSackLimit <= 20000

            // 가장 첫번째 칸은 비워둡니다. x = size or y = size일경우 해당 값은 0
            //knapsackTop = new TraceBack[knapSackLimit + 1, size + 1, size + 1]; // 
            reuseableFarmplan = new TraceBack[knapSackLimit + 1, size + 1, size + 1];
            yPos = new int[knapSackLimit + 1, size + 1, size + 1];

            if (true)
            {
                // 형의 값을 저장합니다.
                for (int allowedKnapsackCurrent = 0; allowedKnapsackCurrent <= knapSackLimit; allowedKnapsackCurrent++)
                {

                    sbyte x = size;

                    for (int y = 0; y <= size; ++y)
                    {
                        reuseableFarmplan[allowedKnapsackCurrent, x, y] = new TraceBack()
                        {
                            sum = 0,
                            currentXPosition = x,
                            yPositions = new sbyte[size]
                        };
                        yPos[allowedKnapsackCurrent, x, y] = 0;
                    }
                }
                // O(3_2000_0000) => 감당 할 수 없다!
                // 20_000 * 20 * 20 * 20 * 2
                // 20_000 * 20 * 20 * 5 * 2 => O(8000_0000) => 이건 가능!

                for (int allowedKnapsackCurrent = 0; allowedKnapsackCurrent <= knapSackLimit; allowedKnapsackCurrent++) // 
                {
                    if (IS_DEBUGGING)
                    {
                        Console.WriteLine($">> allowedKnapsackCurrent = {allowedKnapsackCurrent}");
                    }
                    // 형
                    // x와 y는 냅색을 채우기 위한 좌표값입니다.
                    // oneY는 참조할 대상입니다.
                    // allowedKnapsackDP는 냅색을 진행할때, 이전의 무게에 대한 정보입니다. 구간 [allowedKnapsack -> 0], step = -1
                    for (sbyte x = (sbyte)(size - 1); x > -1; x--) // 구간 [size - 1 -> 0], step -1
                    {
                        if (IS_DEBUGGING)
                        {
                            Console.WriteLine($">> x = {x}");
                        }
                        for (sbyte y = size; y > -1; y--)
                        {
                            if (IS_DEBUGGING)
                            {
                                Console.WriteLine($">>\t y = {y}");
                            }
                            // 해당 좌표의 값 (knapsackBottom)
                            // [x, size - 1]부터 [x, y]까지의 합 + [x + 1, y] ~ [x + 1, 0]중에서 가장 값이 큰 값
                            int differ = verticalSum[x, size] - verticalSum[x, y];
                            int allowedKnapsackSecond = allowedKnapsackCurrent - differ;

                            // 각 oneY값에 해당하는 값을 구함
                            if (IS_DEBUGGING)
                            {
                                StringBuilder lineOneY = new StringBuilder();
                                lineOneY.Append($">>\t\t differ = {differ}, allowedKnapsackSecond = {allowedKnapsackSecond}, allowedKnapsackCurrent = {allowedKnapsackCurrent}");
                                if (allowedKnapsackSecond >= 0)
                                {
                                    lineOneY.Append("\n>>\t\t dp가 참고할 각 값\t");
                                    for (int oneY = 0; oneY <= y; ++oneY)
                                    {
                                        lineOneY.Append($"[{oneY}]{(reuseableFarmplan[allowedKnapsackSecond, x + 1, oneY] == null ? "??" : reuseableFarmplan[allowedKnapsackSecond, x + 1, oneY].sum.ToString())}\t");
                                    }
                                }
                                Console.WriteLine(lineOneY);
                            }

                            if (true)
                            {
                                if (allowedKnapsackSecond < 0) continue;
                                if (reuseableFarmplan[
                                    allowedKnapsackSecond, x + 1,
                                    yPos[allowedKnapsackSecond, x + 1, y]] == null)
                                {
                                    continue;
                                }
                                int newSum = differ + reuseableFarmplan[
                                    allowedKnapsackSecond, x + 1,
                                    yPos[allowedKnapsackSecond, x + 1, y]].sum;

                                if (newSum > allowedKnapsackCurrent) continue;

                                if (reuseableFarmplan[allowedKnapsackCurrent, x, y] != null)
                                {
                                    if (newSum <= reuseableFarmplan[allowedKnapsackCurrent, x, y].sum)
                                    {
                                        continue;
                                    }
                                }

                                if (IS_DEBUGGING)
                                {
                                    Console.WriteLine($">> 값 업데이트 knapsackBottom[{allowedKnapsackCurrent}, {x}, {y}] = {((reuseableFarmplan[allowedKnapsackCurrent, x, y] == null) ? "??" : reuseableFarmplan[allowedKnapsackCurrent, x, y].sum.ToString())} -> {newSum} from knapsackBottom[{allowedKnapsackSecond}, {x + 1}]");
                                }

                                reuseableFarmplan[allowedKnapsackCurrent, x, y] =
                                    reuseableFarmplan[allowedKnapsackSecond, x + 1, yPos[allowedKnapsackSecond, x + 1, y]].Copy();
                                reuseableFarmplan[allowedKnapsackCurrent, x, y].sum = newSum;
                                reuseableFarmplan[allowedKnapsackCurrent, x, y].currentXPosition = x;
                                reuseableFarmplan[allowedKnapsackCurrent, x, y].yPositions[x] = y;

                                // 0부터 Y까지 복붙하기
                                for (int oneY = y; oneY <= size; ++oneY)
                                {
                                    if (reuseableFarmplan[allowedKnapsackCurrent, x, yPos[allowedKnapsackCurrent, x, oneY]] != null)
                                    {
                                        if (reuseableFarmplan[allowedKnapsackCurrent, x, yPos[allowedKnapsackCurrent, x, oneY]]
                                            .sum >= reuseableFarmplan[allowedKnapsackCurrent, x, y].sum)
                                        {
                                            continue;
                                        }
                                    }
                                    yPos[allowedKnapsackCurrent, x, oneY] = y;
                                }

                            }
                        }
                    }
                }



                // 가장 knapSackLimit에 가까운 값을 구한다.
                for (int y = 0; y <= size; ++y) // 20
                {
                    int x = 0;
                    if (reuseableFarmplan[knapSackLimit, x, y] != null)
                    {
                        if (bigBrother.sum < reuseableFarmplan[knapSackLimit, x, y].sum)
                        {
                            bigBrother = reuseableFarmplan[knapSackLimit, x, y];
                        }
                    }
                }
            }

            // 동생 값 구하기.



            reuseableFarmplan = new TraceBack[knapSackLimit + 1, size + 1, size + 1];

            yPos = new int[knapSackLimit + 1, size + 1, size + 1];
            yPos[knapSackLimit, 0, 0] = 0;
            GC.Collect();


            for (int allowedKnapsackCurrent = 0; allowedKnapsackCurrent <= knapSackLimit; allowedKnapsackCurrent++)
            {
                sbyte x = 0;
                for (int y = 0; y <= size; ++y)
                {
                    if (IS_DEBUGGING)
                    {
                        Console.WriteLine($">> allowedKnapsackCurrent = {allowedKnapsackCurrent}, x = {x}, y = {y}");
                    }

                    reuseableFarmplan[allowedKnapsackCurrent, x, y] = new TraceBack()
                    {
                        sum = 0,
                        currentXPosition = x,
                        yPositions = new sbyte[size]
                    };
                    yPos[allowedKnapsackCurrent, x, y] = 0;
                }
            }

                
            // x는 1부터 시작하여 size까지 도달    
            for (int allowedKnapsackCurrent = 0; allowedKnapsackCurrent <= knapSackLimit; allowedKnapsackCurrent++)
            {
                for (sbyte x = 1; x <= size; ++x)
                {
                    for (sbyte y = 0; y <= size; ++y)
                    {
                        int differ = verticalSum[x - 1, y];
                        int allowedKnapsackSecond = allowedKnapsackCurrent - differ;

                        if (allowedKnapsackSecond < 0) continue;
                        if (reuseableFarmplan[
                            allowedKnapsackSecond, x - 1,
                            yPos[allowedKnapsackSecond, x - 1, y]] == null)
                        {
                            continue;
                        }
                        int newSum = differ + reuseableFarmplan[
                            allowedKnapsackSecond, x - 1,
                            yPos[allowedKnapsackSecond, x - 1, y]].sum;

                        if (newSum > allowedKnapsackCurrent) continue;
                        if (reuseableFarmplan[allowedKnapsackCurrent, x, y] != null)
                        {
                            if (newSum <= reuseableFarmplan[allowedKnapsackCurrent, x, y].sum)
                            {
                                continue;
                            }
                        }

                        reuseableFarmplan[allowedKnapsackCurrent, x, y] =
                            reuseableFarmplan[allowedKnapsackSecond, x - 1, yPos[allowedKnapsackSecond, x - 1, y]].Copy();
                        reuseableFarmplan[allowedKnapsackCurrent, x, y].sum = newSum;
                        reuseableFarmplan[allowedKnapsackCurrent, x, y].currentXPosition = x;
                        reuseableFarmplan[allowedKnapsackCurrent, x, y].yPositions[x - 1] = y;

                        for (int oneY = y; oneY >= 0; --oneY)
                        {
                            if (reuseableFarmplan[allowedKnapsackCurrent, x, yPos[allowedKnapsackCurrent, x, oneY]] != null)
                            {
                                if (reuseableFarmplan[allowedKnapsackCurrent, x, yPos[allowedKnapsackCurrent, x, oneY]]
                                    .sum >= reuseableFarmplan[allowedKnapsackCurrent, x, y].sum)
                                {
                                    continue;
                                }
                            }
                            yPos[allowedKnapsackCurrent, x, oneY] = y;
                        }
                    }
                }
            }
            if (size >= 20)
            {
                throw new Exception(); // 메모리 초과 -> 윗부분이 문제란 뜻임
            }
            TraceBack smallBrother = new TraceBack() { sum = 0 };
            for (int y = 0; y <= size; ++y) // 20
            {
                int x = size;
                if (reuseableFarmplan[knapSackLimit, x, y] != null)
                {
                    if (smallBrother.sum < reuseableFarmplan[knapSackLimit, x, y].sum)
                    {
                        smallBrother = reuseableFarmplan[knapSackLimit, x, y];
                    }
                }
            }

            bool isReversed = true;
            isReversed = sum - 2 * bigBrother.sum > sum - 2 * smallBrother.sum;
            TraceBack result = isReversed ? smallBrother : bigBrother;

            StringBuilder answer = new StringBuilder();
            answer.AppendLine($"{(sum - result.sum) - result.sum}");
            for (int index = 0; index < size; ++index)
            {
                answer.Append($"{(isReversed ? size - result.yPositions[index] : size - result.yPositions[index])} ");
            }
            Console.WriteLine(answer);

            //Console.WriteLine("");
        }
    }
}
