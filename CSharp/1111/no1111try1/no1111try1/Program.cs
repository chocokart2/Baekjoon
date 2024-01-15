using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1111try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 전략 : 어떤 패턴인지 먼저 가정을 함, 그 다음 실제로 적용하여 그 패턴이 맞는지 체크할 것,
            // 그 어떤 패턴도 맞지 않으면 B, 한 패턴이 남으면 다음 값, 여러 패턴이 남고 여러 값이 남으면 A를 출력.

            // a와 b의 범위를 구하는게 관건
            // x, xa + b, xa^2 +ab + b, xa^3 + ba^2 + ba+ b
            // [1] - [0] => (xa + b - x) = ((a - 1)x + b) == 3
            // [2] - [1] => (xa^2 - xa + ab) = ((a - 1)x + b)a == 9
            // [3] - [2] => (xa^3 - xa^2 + ba^2) = ((a - 1)x + b)a^2 == 27

            // 3 이상일수록 연산이 가능합니다.

        }
    }
}
