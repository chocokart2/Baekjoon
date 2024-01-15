using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15683try1
{
    internal class Program
    {
        class CameraData
        {
            public int positionX;
            public int positionY;
            public bool[] data = new bool[4]; // 동, 남, 서, 북

            public static CameraData GetCamera(int type, int positionX, int positionY)
            {
                CameraData result = new CameraData() { positionX = positionX, positionY = positionY };
                switch (type)
                {
                    case 1: result.data = new bool[] { true, false, false, false }; break;
                    case 2: result.data = new bool[] { true, false, true, false }; break;
                    case 3: result.data = new bool[] { true, false, false, true }; break;
                    case 4: result.data = new bool[] { true, false, true, true }; break;
                    case 5: result.data = new bool[] { true, true, true, true }; break;
                    default: return null;
                }
                return result;
            }
            public void Spin()
            {
                bool temp = data[0];
                for (int index = 1; index < 4; ++index) data[index - 1] = data[index];
                data[3] = temp;
            }
        }




        class Map
        {
            enum EBlocks
            {
                empty = 0,
                camera1 = 1,
                camera2 = 2,
                camera3 = 3,
                camera4 = 4,
                camera5 = 5,
                wall = 6
            }

            int emptyAmount = 0; // 취약하지만, 빠른 연산을 지원합니다.
            int xSize;
            int ySize;
            EBlocks[,] data;
            public CameraData[] cameras;

            public void Init()
            {
                string[] recvLineSize = Console.ReadLine().Split(' ');
                

                xSize = int.Parse(recvLineSize[1]);
                ySize = int.Parse(recvLineSize[0]);
                data = new EBlocks[xSize, ySize];
                // 배열로 바꾸기 전의 리스트입니다. 읽는 동안에 카메라가 몇개인지는 알 수 없습니다.
                List<CameraData> camerasPreList = new List<CameraData>();

                for (int line = 0; line < ySize; ++line)
                {
                    string recvLineOne = Console.ReadLine();

                    for (int xIndex = 0; (xIndex << 1) < recvLineOne.Length; ++xIndex)
                    {
                        EBlocks one = (EBlocks)(recvLineOne[xIndex << 1] - '0');

                        data[xIndex, line] = one;
                        if (one == EBlocks.empty)
                        {
                            emptyAmount++;
                        }
                        else if (one != EBlocks.empty && one != EBlocks.wall)
                        {
                            camerasPreList.Add(CameraData.GetCamera((int)one, xIndex, line));
                        }
                    }
                }

                cameras = camerasPreList.ToArray();
            }

            // sus
            public int GetBlindSpot()
            {
                int result = emptyAmount;
                // 카메라 방향대로 뻗어나갑니다. wall이면 뻗어나가는걸 중지합니다.

                bool[,] isVisivlePlace = new bool[xSize, ySize]; // true로 변할 때마다 result의 값이 1씩 줄어듭니다.
                
                for (int camIndex = 0; camIndex < cameras.Length; ++camIndex)
                {
                    CameraData oneCam = cameras[camIndex];
                    for (int directionIndex = 0; directionIndex < 4; ++directionIndex) // 동, 남, 서, 북
                    {
                        if (oneCam.data[directionIndex] == false)
                        {
                            // 이 카메라는 해당 방향으로 바라보고 있지 않습니다!
                            continue;
                        }

                        int currentX = oneCam.positionX; // 시작지점
                        int currentY = oneCam.positionY; // 시작지점
                        int dx = 0; // x인덱스의 변화량
                        int dy = 0; // y인덱스의 변화량

                        switch (directionIndex)
                        {
                            case 0: dx = 1; break;
                            case 1: dy = 1; break;
                            case 2: dx = -1; break;
                            case 3: dy = -1; break;
                            default: break;
                        }

                        while (true)
                        {
                            currentX += dx;
                            currentY += dy;
                            
                            // 해당 좌표가 맵 밖으로 나갔는지 판별합니다.
                            if (((0 <= currentX) && (currentX < xSize) && (0 <= currentY) && (currentY < ySize)) == false)
                            {
                                break;
                            }

                            if (data[currentX, currentY] == EBlocks.wall)
                            {
                                break;
                            }

                            if (data[currentX, currentY] == EBlocks.empty &&
                                isVisivlePlace[currentX, currentY] == false)
                            {
                                result--;
                                isVisivlePlace[currentX, currentY] = true;
                            }
                            // 만약 해당 위치가 카메라가 있는 곳이거나, 이미 카메라를 통해 바라보고 있는 곳이라면 무시합니다.
                        }
                    }
                }

                return result;
            }

        }


        static void Main(string[] args)
        {
            // a[index] = 4^(index)
            long[] spinTime = new long[9] // 최대 카메라 갯수는 8개입니다.
            {
                1 << 0,
                1 << 2,
                1 << 4,
                1 << 6,
                1 << 8,
                1 << 10,
                1 << 12,
                1 << 14,
                1 << 16
            };

            Map map = new Map();
            map.Init();
            int min = int.MaxValue;
            for (long attempt = 0; attempt < spinTime[map.cameras.Length]; ++attempt)
            {
                // n번째 인덱스의 카메라는
                // attempt % spinTime[n] == 0 일때 회전시킵니다.

                int oneResult = map.GetBlindSpot();
                if (oneResult < min) min = oneResult;

                for (int index = 0; index < map.cameras.Length; ++index)
                {
                    if (attempt % spinTime[index] == 0)
                    {
                        map.cameras[index].Spin();
                    }
                }
            }

            Console.WriteLine(min);
        }
    }
}
