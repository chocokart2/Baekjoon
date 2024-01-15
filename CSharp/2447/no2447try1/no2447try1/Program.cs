using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2447try1
{
    internal class Program
    {
        struct CharMatrix
        {
            public string[] value;

            // 가로 합치기를 지원
            static public CharMatrix HorizontalAdd(CharMatrix a, CharMatrix b)
            {
                CharMatrix result = new CharMatrix();
                result.value = new string[a.value.Length];
                for (int index = 0; index < a.value.Length; ++index)
                {
                    StringBuilder singleLine = new StringBuilder();
                    singleLine.Append(a.value[index]);
                    singleLine.Append(b.value[index]);
                    result.value[index] = singleLine.ToString();
                }
                return result;
            }
            // 세로 합치기 지원
            static public CharMatrix VerticalAdd(CharMatrix a, CharMatrix b)
            {
                CharMatrix result = new CharMatrix();
                result.value = new string[a.value.Length + b.value.Length];
                for (int index = 0; index < a.value.Length; ++index)
                {
                    result.value[index] = a.value[index].ToString();
                }
                for (int index = 0; index < b.value.Length; ++index)
                {
                    result.value[index + a.value.Length] = b.value[index];
                }
                return result;
            }
            static public CharMatrix FillSquare(char a, int x)
            {
                CharMatrix result = new CharMatrix();
                result.value = new string[x];
                for (int index = 0; index < x; ++index)
                {
                    result.value[index] = new string(a, x);
                }
                return result;
            }

            // 답변 호출용 함수
            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                for (int index = 0; index < value.Length; ++index)
                {
                    result.Append($"{value[index]}\n");
                }
                return result.ToString();
            }
        }

        static CharMatrix GetPattern(int size)
        {
            if (size == 0) return CharMatrix.FillSquare('*', 1);

            else return
                    CharMatrix.VerticalAdd(CharMatrix.VerticalAdd(
                        CharMatrix.HorizontalAdd(CharMatrix.HorizontalAdd(GetPattern(size - 1), GetPattern(size - 1)), GetPattern(size - 1)),
                        CharMatrix.HorizontalAdd(CharMatrix.HorizontalAdd(GetPattern(size - 1), CharMatrix.FillSquare(' ', (int)Math.Pow(3, size - 1))), GetPattern(size - 1))
                    ), CharMatrix.HorizontalAdd(CharMatrix.HorizontalAdd(GetPattern(size - 1), GetPattern(size - 1)), GetPattern(size - 1))
                    );
        }


        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int k = 0;
            for (int tempN = N; tempN > 1; tempN /= 3) k++;

            Console.Write(GetPattern(k).ToString());
        }
    }
}
