using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25589try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 누적합은 알겠는데
            // 다이나믹 프로그래밍은 어떻게?
            // 일단 값을 계산할 때, 두개의 정사각형은 겹치면 안된다.
            // 일단 사각형 값을 구하고, 그곳을 어딘가 저장.
            // 일단 "다른 곳은 잘 모르겠고" 라는 마인드가 중요. 즉 독립적이여야 함.

            // 400 ^ 3 < 1억, O(N^3) 이내로 해결해야 함.
            // 메모리 제한 상태를 보면 3차원 배열도 허용하는것 같은데.
            // 오른쪽 아래로 다이나믹  프로그래밍을 했을때, 사각지대가 존재하기 때문에,
            // 왼쪽 아래로도 다이나믹 프로그래밍을 진행하여 사각지대를 완전히 제거해야 함.
            // 두 경우를 모두 고려했을때, 가장 큰 값을 획득.
            // (오른쪽 아래 방향으로 DP를 한다는 가정)DP를 위한 배열[size, size]에서
            // 해당 원소는 [0, 0], [x, y]를 각 꼭짓점으로 하는 직사각형 구간에서 가장 값이 큰 값으로 한다.
            
        }
    }
}
