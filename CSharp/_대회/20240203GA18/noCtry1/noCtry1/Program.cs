using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCtry1
{
    internal class Program
    {
        static int Spin(int current, int add)
        {
            return (current + add) % 4;
        }

        static void Main(string[] args)
        {
            const bool IS_DEBUGGING = false;

            // 아리스는 아리스의 분신이 흰색 타일을 만날때마다 이동한 값을 덮어씁니다.
            int movedCount = 0;
            int tempMovedCount = 0;

            string[] recvLineSize = Console.ReadLine().Split(' ');
            int ySize = int.Parse(recvLineSize[0]);
            int xSize = int.Parse(recvLineSize[1]);
            string[] robot = Console.ReadLine().Split(' ');
            int xPos = int.Parse(robot[1]);
            int yPos = int.Parse(robot[0]);
            // 아리스는 아리스의 분신이 흰색 타일을 만날때마다 텔레포트합니다.
            int xPosTemp = xPos;
            int yPosTemp = yPos;
            bool hasTempMeetDirty = false;
            int direction = int.Parse(robot[2]); // 위 / 오른쪽 / 아래 / 왼쪽
            int[] deltaX = { 0, 1, 0, -1 }; // 방향을 인덱스로
            int[] deltaY = { -1, 0, 1, 0 }; // 방향을 인덱스로
            // 시뮬레이션 실행
            bool foundCleanedTile = false; // 더러운 타일을 만나게 되면 false, 아니라면 true
            int lastCleanedTileX = -1; // 만약 더러워진 타일을 만나면 청소 후 이동 위치를 현재의 타일로 덮어씌웁니다.
            int lastCleanedTileY = -1; // 만약 더러워진 타일을 만나면 청소 후 이동 위치를 현재의 타일로 덮어씌웁니다.
            int lastCleanedTileDirections = -1; // 만약 더러워진 타일을 만나면 청소 후 이동 위치를 현재의 타일로 덮어씌웁니다.
            bool[,] isCleanedTile = new bool[xSize, ySize];
            int[,] spinA = new int[xSize, ySize];
            int[,] spinB = new int[xSize, ySize];

            for (int yIndex = 0; yIndex < ySize; yIndex++)
            {
                string oneLine = Console.ReadLine();
                for (int xIndex = 0; xIndex < xSize; xIndex++)
                {
                    spinA[xIndex, yIndex] = oneLine[xIndex] - '0';
                }
            }
            for (int yIndex = 0; yIndex < ySize; yIndex++)
            {
                string oneLine = Console.ReadLine();
                for (int xIndex = 0; xIndex < xSize; xIndex++)
                {
                    spinB[xIndex, yIndex] = oneLine[xIndex] - '0';
                }
            }
            while (true)
            {
                if (IS_DEBUGGING) Console.WriteLine($">> 현재 위치 : (x = {xPosTemp}, y = {yPosTemp}), 깨끗한가? : {isCleanedTile[xPosTemp, yPosTemp]}");

                //

                // 현재가 먼지인지 판단

                if (isCleanedTile[xPosTemp, yPosTemp])
                {
                    // 현재 타일이 반복되었는지 체크

                    direction = Spin(direction, spinB[xPosTemp, yPosTemp]);


                }
                else
                {
                    // 청소하기
                    direction = Spin(direction, spinA[xPosTemp, yPosTemp]);

                    isCleanedTile[xPosTemp, yPosTemp] = true;
                    hasTempMeetDirty = true;
                }

                // 아리스 전진
                tempMovedCount++;
                xPosTemp += deltaX[direction];
                yPosTemp += deltaY[direction];
                if (IS_DEBUGGING) Console.WriteLine($">> 아리스 위치 : (x = {xPosTemp}, y = {yPosTemp})");






                if (IS_DEBUGGING) Console.WriteLine(">> moved");



                // 아리스의 분신이 더러운 타일을 만났는가?
                if (hasTempMeetDirty)
                {
                    // 이전까지의 상태는 "계속해서 연속적으로" 더러운 타일에 있었던겁니다.

                    // 만약 아리스가 바깥으로 나간경우.
                    if (0 > xPosTemp || xPosTemp >= xSize || 0 > yPosTemp || yPosTemp >= ySize)
                    {
                        if (IS_DEBUGGING) Console.WriteLine($">> 아리스가 가출했다 (x = {xPosTemp}, y = {yPosTemp})");

                        movedCount = tempMovedCount;
                        break;
                    }
                    
                    // 만약 아리스가 하얀 타일을 만난경우
                    if (isCleanedTile[xPosTemp, yPosTemp])
                    {
                        // 이동 상황을 저장합니다.
                        if (IS_DEBUGGING) Console.WriteLine($">> 이동 상황 저장");
                        xPos = xPosTemp;
                        yPos = yPosTemp;
                        movedCount = tempMovedCount;
                        hasTempMeetDirty = false;
                        lastCleanedTileX = xPosTemp;
                        lastCleanedTileY = yPosTemp;
                        lastCleanedTileDirections = direction;
                        continue;
                    }
                }
                else
                {
                    // 만약 아리스가 바깥으로 나간경우.
                    if (0 > xPosTemp || xPosTemp >= xSize || 0 > yPosTemp || yPosTemp >= ySize)
                    {
                        if (IS_DEBUGGING) Console.WriteLine($">> 아리스의 분신이 가출했다 (x = {xPosTemp}, y = {yPosTemp})");
                        break;
                    }
                    // 아리스가 뱅글뱅글 돈 경우

                    if (xPosTemp == lastCleanedTileX &&
                        yPosTemp == lastCleanedTileY &&
                        direction == lastCleanedTileDirections)
                    {
                        if (IS_DEBUGGING) Console.WriteLine($">> 아리스의 분신이 빙글빙글 돈다. (x = {xPosTemp}, y = {yPosTemp}, d = {direction})");

                        break;
                    }

                }
            }
            Console.WriteLine(movedCount);


        }
    }
}
