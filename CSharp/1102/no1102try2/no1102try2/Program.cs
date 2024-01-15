using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1102try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const bool IS_DEBUGGING = false;
            const int EMPTY = -1;
            const int AVAILABLE = 0;

            int result = -1; // not Found
            int existEnergyPlantCount;
            int targetPlantCount;
            int startPlantStatus;
            int startWorkingPlantCount = 0;
            int[] leftEnergy;
            int[] workingEnergyPlantCount; // 작동하는 발전소의 갯수
            int[,] cost; // envoker, target
            Queue<int> updatedElementIndex = new Queue<int>(); // 새 값이 들어왔을때마다 업데이트
            existEnergyPlantCount = int.Parse(Console.ReadLine());
            cost = new int[existEnergyPlantCount, existEnergyPlantCount];
            leftEnergy = new int[(1 << existEnergyPlantCount)];
            for (int index = 0; index < leftEnergy.Length; ++index)
            {
                leftEnergy[index] = EMPTY;
            }
            workingEnergyPlantCount = new int[(1 << existEnergyPlantCount)];
            for (int invoker = 0; invoker < existEnergyPlantCount; ++invoker)
            {
                string[] oneLine = Console.ReadLine().Split(' ');

                for (int target = 0; target < existEnergyPlantCount; ++target)
                {
                    cost[invoker, target] = int.Parse(oneLine[target]);
                }
            }

            startPlantStatus = 0;
            string plantStatusString = Console.ReadLine();
            for (int index = 0; index < plantStatusString.Length; ++index)
            {
                if (plantStatusString[index] == 'Y')
                {
                    //startPlantStatus += (1 << (plantStatusString.Length - index - 1));
                    startPlantStatus += (1 << index);
                    startWorkingPlantCount++;
                }
            }

            targetPlantCount = int.Parse(Console.ReadLine());
            leftEnergy[startPlantStatus] = AVAILABLE;
            workingEnergyPlantCount[startPlantStatus] = startWorkingPlantCount;

            // 문제 풀이가 불가능한 경우인 모두 off인 상태를 필터링한다.

            // int leftEnergy[energyPlantStatus][inputEnergy] (-1은 null이고 처음에 모든 값을 -1로 초기화.)
            // leftEnergy[첨 시작할때 비트 상황][0] = 0으로 시작. 값 = 남는 에너지 값, (null이면 값이 -1임)
            // inputEnergy가 0인 상황인것부터 발전기가 최대한 전기를 잡아먹는 상황까지 조건부 하에 루프를 돌립니다. 만약 루프 도중 원하는 값이 발견된다면, 즉시 루프를 종료합니다.
            // inputEnergy를 1씩 늘렸을때 leftEnergy = 0이 아닌 상황에는 1씩 증가시키기
            // inputEnergy가 이 증가되었을때, EMPTY가 아닌 상황들중에서, updatedElementIndex에 해당 비트 상황을 집어넣기

            // updatedElementIndex에 들어간 숫자를 꺼내 leftEnergy에 넣기.
            // ㄴ 해당 상황의 비트가 workingEnergyPlantCount[해당 비트]가 targetPlantCount보다 크면 루프를 종료합니다.
            // ㄴ 해당 상황에서 새로 작동가능한 발전소 있는지 or 이미 원래 값이 있는데 더 낮은 값으로 해당 발전소를 킬 수 있는지 체크
            // ㄴㄴ 이때, 현재 상황에서 켜져있는 발전소를 다시 키려는 경우는 무시합니다.
            // ㄴㄴ 있으면 해당 비트 값을 구하고, leftEnergy[해당비트][inputEnergy] = leftEnergy[과거비트][inputEnergy] - 해당 발전소를 작동시키는 방법중 가장 낮은 값
            // ㄴㄴ updatedElementIndex에 해당 비트 값을 Enqueue한다.
            // ㄴㄴ 만약 꺼진 발전소를 키는 경우 workingEnergyPlantCount[해당비트] = workingEnergyPlantCount[과거 비트] + 1입니다.
            int maxLoopCount = existEnergyPlantCount * 35;
            for (int inputEnergy = 0; inputEnergy <= maxLoopCount; ++inputEnergy)
            {
                bool isFoundResult = false;

                for (int bitSituation = 0; bitSituation < leftEnergy.Length; ++bitSituation)
                {
                    if (leftEnergy[bitSituation] > EMPTY)
                    {
                        updatedElementIndex.Enqueue(bitSituation);
                    }
                }

                while (updatedElementIndex.Count > 0)
                {
                    int oneSituation = updatedElementIndex.Dequeue();

                    // 정답 체크
                    if (workingEnergyPlantCount[oneSituation] >= targetPlantCount)
                    {
                        result = inputEnergy;
                        if (IS_DEBUGGING)
                        {
                            Console.WriteLine($">> inputEnergy = {inputEnergy}");
                            Console.WriteLine($">> leftEnergy[{oneSituation}] = {leftEnergy[oneSituation]}");
                            Console.WriteLine($">> workingEnergyPlantCount[{oneSituation}] = {workingEnergyPlantCount[oneSituation]}");
                            Console.WriteLine($">> targetPlantCount = {targetPlantCount}");
                        }
                        isFoundResult = true;
                        break;
                    }

                    // 해당상황에서 작동시킬 수 있는 발전소가 있는지 체크합니다.
                    for (int plantID = 0; plantID < existEnergyPlantCount; ++plantID)
                    {
                        int selectedPlantID = 1 << plantID;

                        if ((oneSituation & selectedPlantID).Equals(selectedPlantID))
                        {
                            // 해당 발전소는 이미 작동하고 있어서 가동시킬 필요가 없습니다.
                            continue;
                        }

                        // 현재 상황에서 켜져있는 각각의 발전소로, 선택한 꺼져있는 발전소(plantID)를 하나씩 켜봅니다.
                        for (int invoker = 0; invoker < existEnergyPlantCount; ++invoker)
                        {
                            // 다른 발전소를 작동시키려는 해당 발전소가 꺼져 있어서 다른 발전소를 켤 수 없습니다.
                            if ((oneSituation & (1 << invoker)).Equals((1 << invoker)) == false)
                            {
                                continue;
                            }

                            // 해당 발전소로 켰을때, 남는 에너지가 더 큰 경우
                            int selectedPlantWorkingSituation = oneSituation | selectedPlantID;
                            if (leftEnergy[selectedPlantWorkingSituation] < leftEnergy[oneSituation] - cost[invoker, plantID])
                            {

                                leftEnergy[selectedPlantWorkingSituation] = leftEnergy[oneSituation] - cost[invoker, plantID];
                                workingEnergyPlantCount[selectedPlantWorkingSituation] = workingEnergyPlantCount[oneSituation] + 1;
                                updatedElementIndex.Enqueue(selectedPlantWorkingSituation);

                                if (IS_DEBUGGING)
                                {
                                    Console.WriteLine($">> inputEnergy = {inputEnergy}");
                                    Console.WriteLine($">> leftEnergy[{oneSituation}] = {leftEnergy[oneSituation]}");
                                    Console.WriteLine($">> workingEnergyPlantCount[{oneSituation}] = {workingEnergyPlantCount[oneSituation]}");
                                    Console.WriteLine($">> targetPlantCount = {targetPlantCount}");
                                    Console.WriteLine($">> leftEnergy[{selectedPlantWorkingSituation}] = {leftEnergy[selectedPlantWorkingSituation]}");
                                    Console.WriteLine($">> leftEnergy[{oneSituation}] = {leftEnergy[oneSituation]}, cost[{invoker}, {plantID}] = {cost[invoker, plantID]}, ");
                                    Console.WriteLine($">> leftEnergy[{oneSituation}] - cost[{invoker}, {plantID}] = {leftEnergy[oneSituation] - cost[invoker, plantID]}");
                                    Console.WriteLine($">> workingEnergyPlantCount[{selectedPlantWorkingSituation}] = {workingEnergyPlantCount[selectedPlantWorkingSituation]}");
                                    Console.WriteLine($"updatedElementIndex.Count = {updatedElementIndex.Count}");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
                if (isFoundResult) break;

                for (int bitSituation = 0; bitSituation < leftEnergy.Length; ++bitSituation)
                {
                    if (leftEnergy[bitSituation] > EMPTY)
                    {
                        leftEnergy[bitSituation]++;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
