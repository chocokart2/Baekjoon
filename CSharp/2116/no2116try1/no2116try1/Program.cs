using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2116try1
{

    internal class Program
    {
        class Dice
        {
            // [어떤 면인가 <--> 이 면의 숫자]를 대응해주는 1대1 대응을 이룹니다.
            public int[] side = new int[6];
            public int[] sideToIndex = new int[6]; // 번호를 집어넣으면 인덱스 번호를 리턴해줍니다. 메모리를 희생하고 속도를 얻습니다.
            
            public int downSide = -1; // 아랫면의 숫자가 무엇인지를 가집니다. 다른 객체가 이를 정의해줍니다.
            
            static private int[] faceToFaceIndex = { 5, 3, 4, 1, 2, 0 }; // 건너편의 면의 인덱스를 리턴해줍니다.

            public Dice (int[] num)
            {
                side = num;
                for(int index = 0; index < num.Length; ++index)
                {
                    sideToIndex[num[index] - 1] = index;
                }
            }
            public Dice(Dice target)
            {
                // Deep Copy here
                this.side = target.side; this.sideToIndex = target.sideToIndex; downSide = target.downSide;
            }

            public int GetUpNumber()
            {
                return side[faceToFaceIndex[sideToIndex[downSide - 1]]];
            }
            // 아랫면을 보고 자신의 윗면을 리턴하는 함수
            public int[] GetSideNumber()
            {
                int forbidden = GetUpNumber();
                return side.Where(x => x != downSide && x != forbidden).ToArray();
            }
        }

        class DicePillar
        {
            public Dice[] dices;
        }

        static DicePillar[] PileDice(Dice[] target)
        {
            // 가장 아래의 블럭에 따라 6가지의 방법이 있습니다.


            DicePillar[] result = new DicePillar[6];
            for (int index = 0; index < 6; ++index)
            {
                result[index] = new DicePillar() { dices = new Dice[target.Length] };
                for (int diceIndex = 0; diceIndex < target.Length; ++diceIndex)
                    result[index].dices[diceIndex] = new Dice(target[diceIndex]);
            }
            // 가장 아래의 블럭의 바닥을 결정합니다. -> 그 위 블럭을 결정합니다.

            for (int index = 0; index < 6; ++index) // index + 1 -> 가장 아래 주사위의 바닥 숫자
            {
                result[index].dices[0].downSide = index + 1;
                for (int diceIndex = 1; diceIndex < result[index].dices.Length; ++diceIndex) // 2번째 블록부터 하나씩 올립니다.
                {
                    result[index].dices[diceIndex].downSide = result[index].dices[diceIndex - 1].GetUpNumber();
                }
            }
            result[3].dices[0].downSide = 1;
 
            return result;
        }

        static int GetMax(DicePillar target)
        {
            int result = 0;
            for(int index = 0; index < target.dices.Length; ++index)
            {
                int[] sideNum = target.dices[index].GetSideNumber();
                result += Math.Max(
                    Math.Max(sideNum[0], sideNum[1]),
                    Math.Max(sideNum[2], sideNum[3]));
            }
            return result;
        }

        static int[] ParseStrings(string[] strings)
        {
            int[] result = new int[strings.Length];
            for(int index = 0; index < strings.Length; ++index)
            {
                result[index] = int.Parse(strings[index]);
            }
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dice[] dices = new Dice[count];
            DicePillar[] availablePiles; // 가능한 방법들이 나열되어 있습니다
            int result = int.MinValue;
            int[] resultList;

            for(int index = 0; index < count; ++index)
            {
                dices[index] = new Dice(ParseStrings(Console.ReadLine().Split(' ')));
            }

            availablePiles = PileDice(dices);
            resultList = new int[availablePiles.Length];
            for (int index = 0; index < resultList.Length; ++index)
            {
                int onePileMax = GetMax(availablePiles[index]);
                if (result < onePileMax) result = onePileMax;
            }
            Console.WriteLine(result);
        }
    }
}
