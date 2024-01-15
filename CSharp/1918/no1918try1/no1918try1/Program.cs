using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1918try1
{
    internal class Program
    {
        // 일단 괄호 상태를 저장한다.
        // 그러니까 어떤 문자열이 괄호가 몇개나 중첩된 상태인지를 저장한다.

        // 저장될 정보는 인덱스 : 괄호 겹수.

        // 배열 : 연산이 완료된 괄호의 결과값 클래스 + 연산자 + 문자
        // 각 연산자, 문자, 클래스는 레벨이 있었다.

        abstract class Chunk
        {
            public enum EClassification
            {
                value = 0, // 단순 변수, 이미 연산이 완료된 괄호의 결과값
                lowPrecedenceOperator = 1, // 덧셈과 뺄셈 등 우선순위가 낮은 연산자.
                HighPrecedenceOperator = 2, // 곱셈ㄷ과 나눗셈 등 우선순위가 낮은 연산자.
            }

            public int parenthesesCoverCount;
            public EClassification ChunkType { protected set; get; }

            public abstract string GetString();
        }
        // 변수와 연산기호
        class Symbol : Chunk
        {
            public char value; // 연산자 혹은 변수s
            public Symbol(char value, int level)
            {
                this.value = value;
                this.parenthesesCoverCount = level;
                
                switch (value)
                {
                    case '*':
                    case '/':
                        ChunkType = EClassification.HighPrecedenceOperator;
                        break;
                    case '+':
                    case '-':
                        ChunkType = EClassification.lowPrecedenceOperator;
                        break;
                    default:
                        ChunkType = EClassification.value;
                        break;
                }
            }

            public override string GetString()
            {
                return value.ToString();
            }
        }
        // 변수와 동일하나, 괄호 내부의 값
        class CalculationResult : Chunk
        {
            char operationSymbol;
            Chunk leftValue;
            Chunk rightValue;

            public CalculationResult()
            {
                ChunkType = EClassification.value;
            }

            static public CalculationResult Merge(Chunk leftValue, Chunk symbol, Chunk rightValue)
            {
                return new CalculationResult()
                {
                    operationSymbol = symbol.GetString()[0],
                    leftValue = leftValue,
                    rightValue = rightValue,
                    parenthesesCoverCount = leftValue.parenthesesCoverCount
                };
            }
            // 매개변수 범위의 안에 들어 있는 여러 연산 기호, 변수, 그리고 괄호 덩어리들의 나열을 하나의 결과로 나타냅니다.
            static public CalculationResult MergeAll(int level, Chunk[] chunks) // 괄호가 n번 둘러싸인 식을 합병하는 경우, level의 값은 n - 1입니다.
            {
                // chunks의 특징은 연산자와 값(혹은 연산이 완료된 괄호의 범위)가 번갈아 가면서 나타납니다.
                // 먼저 우선순위가 높은 연산자를 봅니다. 왼쪽부터 옆으로 차례로 읽어나갑니다.
                // 합칠 세 부위를 고릅니다. 그리고 해당하는 세 원소 null로 만들고, 가장 인덱스 번호가 가장 높은 값을 합병한 객체로 만듭니다.
                // ㄴ이때 합칠 세 부위는 값 / 연산자 / 값 이여야 하며, 이순간의 연산자는 높은 우선순위 연산자이여야 합니다.
                // 완료 되었으면, null 원소의 자리를 뺀 줄어든 새 배열을 만듭니다.
                // 그리고 낮은 우선순위 연산지를 기준으로 다시 실행합니다.
                // 원소 줄이기를 하지 않고, 해당 배열의 가장 마지막 원소를 CalculationResult로 캐스팅하고 리턴합니다.

                int length = chunks.Length;
                EClassification[] operatorFilter = { EClassification.HighPrecedenceOperator, EClassification.lowPrecedenceOperator };
                
                for (int i = 0; i < 2; ++i)
                {
                    // 값과 연산자가 번갈아가면서 있으므로, 두번째 자리부터 읽고 2칸씩 읽습니다.
                    for (int operatorIndex = 1; operatorIndex < chunks.Length; operatorIndex += 2)
                    {
                        if (chunks[operatorIndex].ChunkType != operatorFilter[i]) continue;

                        CalculationResult one =
                            new CalculationResult()
                            {
                                operationSymbol = chunks[operatorIndex].GetString()[0],
                                leftValue = chunks[operatorIndex - 1],
                                rightValue = chunks[operatorIndex + 1],
                                parenthesesCoverCount = level
                            };
                        chunks[operatorIndex - 1] = null;
                        chunks[operatorIndex] = null;
                        chunks[operatorIndex + 1] = one;
                        length -= 2;
                    }

                    if (i == 1) break;

                    // null 원소의 자리를 뺀 줄어든 새 배열을 만듭니다.
                    chunks = RemoveNulls(chunks, length);
                }
                return chunks[chunks.Length - 1] as CalculationResult;
            }
            public override string GetString()
            {
                return $"{leftValue.GetString()}{rightValue.GetString()}{operationSymbol}";
            }
        }
        static Chunk[] Merge(Chunk[] chunks, int startIndex, int endIndex, int level)
        {
            Chunk[] subChunk = new Chunk[endIndex - startIndex + 1];
            for (int index = startIndex; index <= endIndex; ++index)
            {
                subChunk[index - startIndex] = chunks[index];
                chunks[index] = null;
            }
            chunks[endIndex] = CalculationResult.MergeAll(level, subChunk);
            return chunks;
        }
        static Chunk[] RemoveNulls(Chunk[] chunks, int length)
        {
            Chunk[] nextArray = new Chunk[length];
            for (int index = 0, nextIndex = 0; index < chunks.Length; ++index)
            {
                if (chunks[index] == null) continue;

                nextArray[nextIndex] = chunks[index];
                ++nextIndex;
            }
            return nextArray;
        }
        // 문자열을 Chunk의 배열로 만듭니다. 
        static (Chunk[] chunks, int highestLevel) ConvertToChunks(string formula)
        {
            int parenthesesLevel = 0;
            int maxLevel = 0;
            List<Chunk> resultList = new List<Chunk>();
            for (int index = 0; index < formula.Length; ++index)
            {
                if (formula[index] == '(')
                {
                    parenthesesLevel++;
                    if (parenthesesLevel > maxLevel) maxLevel = parenthesesLevel;
                    continue;
                }
                if (formula[index] == ')')
                {
                    parenthesesLevel--;
                    continue;
                }
                resultList.Add(new Symbol(formula[index], parenthesesLevel));
            }
            return (resultList.ToArray(), maxLevel);
        }
        static void Main(string[] args)
        {
            string formula = Console.ReadLine();

            (Chunk[] chunks, int maxLevel) = ConvertToChunks(formula);
            
            // maxlevel만큼 반복합니다.
            // maxLevel이 같은 인덱스 상 연속하는 원소끼리 배열을 만듭니다.
            // 그리고 배열 하나를 완성하면, 즉시 괄호 안 내용을 하나로 즉시 합병합니다.
            for (int level = maxLevel; level > -1; --level)
            {
                bool isHighestLevel = false; // true에서 false 혹은 formula배열의 끝에 도달하면 CalculationResult.MergeAll을 진행합니다.
                int startIndex = -1; // 선택한 괄호 레벨을 가진 범위가 시작되는 인덱스입니다.
                int nextChunksLength = chunks.Length;

                for (int index = 0; index < chunks.Length; ++index)
                {
                    if (chunks[index].parenthesesCoverCount > level) // 발생해선 안되는 곳입니다.
                    {
                        Console.WriteLine("!!!!!");
                        return;
                    }

                    // 괄호가 시작되는 경우
                    if (chunks[index].parenthesesCoverCount == level && isHighestLevel == false)
                    {
                        startIndex = index;
                        isHighestLevel = true;
                    }

                    // 2. 괄호가 끝나는 경우 (최소한 괄호 시작을 맞이해야 함)
                    if (isHighestLevel)
                    {
                        // 2.1. index는 배열의 마지막 원소의 인덱스에 도달했고, 해당하는 범위의 괄호 열기를 맞이했습니다(isHighestLevel == true)
                        if (index == chunks.Length - 1)
                        {
                            if (index == startIndex)
                            {
                                chunks[index].parenthesesCoverCount--;
                                break;
                            }

                            // 합병을 시도합니다.
                            chunks = Merge(chunks, startIndex, chunks.Length - 1, level - 1);
                            nextChunksLength -= chunks.Length - 1 - startIndex; 
                            break;
                        }
                        // 2.2. 괄호 열기를 맞이했는데, 그 다음의 값이 선택한 괄호 레벨이 아닙니다. 끝은 index - 1입니다.
                        if (chunks[index].parenthesesCoverCount < level)
                        {
                            if (index - 1 == startIndex) // 괄호가 둘러싼 것들이 연산자가 없이 값 하나입니다.
                            {
                                chunks[index - 1].parenthesesCoverCount--;
                            }
                            else // 괄호가 둘러싼 것들이 여러 값과 여러 연산자입니다.
                            {
                                // 합병을 시도합니다.
                                chunks = Merge(chunks, startIndex, index - 1, level - 1);
                                nextChunksLength -= index - 1 - startIndex;
                            }

                            isHighestLevel = false;
                        }
                    }
                }

                if (level == 0)
                {
                    break;
                }

                chunks = RemoveNulls(chunks, nextChunksLength);
            }

            Console.WriteLine(chunks[chunks.Length - 1].GetString());
        }
    }
}
// 내일 살거
// 실내용 운동화
// 작은 샴푸, 작은 바디워시, 혹은 그러한 종류를 담을 수 있는 작은 무언가
// 액체가 새어나오지 못하는 작은 지퍼백
// 맘스터치 딥치즈버거