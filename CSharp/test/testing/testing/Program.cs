using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;

namespace testing
{
    internal class Program
    {
        public class LongestIncreasingSubsequence<T>
        {
            private Func<T, T, bool> IsRightFirst; // 두번째 매개변수가 앞쪽(왼쪽)에 있어야 하는지 판정하는 함수입니다.
            private List<T> source; // 배열 기반의 객체입니다만, 동적으로 늘어날 수 있습니다.
            private int lisPosition = 0;


            public LongestIncreasingSubsequence(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                M_Init(_sourse, isRightFirst);
            }
            public LongestIncreasingSubsequence(T[] _sourse, Func<T, T, bool> isRightFirst)
            {
                M_Init(_sourse.ToList(), isRightFirst);
            }


            static T[] GetLIS(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                
            }
            static T[] GetLIS(T[] _sourse, Func<T, T, bool> isRightFirst)
                => GetLIS(_sourse.ToList(), isRightFirst);
            static int[] GetLIS(int[] _sourse)
                => LongestIncreasingSubsequence<int>.GetLIS(
                    _sourse.ToList(),
                    delegate (int left, int right)
                    {
                        return left > right;
                    }
                    );

            private void M_Init(List<T> _sourse, Func<T, T, bool> isRightFirst)
            {
                source = _sourse;
                IsRightFirst = isRightFirst; 
                M_BuildSubsequence();
            }
            private void M_BuildSubsequence()
            {
                

            }
        }

        static void Main(string[] args)
        {
            // 어떤 LIS 클래스
            // static 함수 LisON2: O(n^2)
            // static 함수 LisONLogN: O(N Log N)

            // 인스턴스
            // 리스트 기반 값 배열 (추가와 확인만 가능, 이전 값이 변경되게 되면, LIS가 호출됨)
            // LIS를 지원하는 배열
            // LIS 결과값
            // 백트래킹을 통해 얻어낸 LIS의 배열값.
            //
            // LIS 함수
            // LIS 추가 함수
            // 값 추가 함수
            // 값 확인 함수
            // 게으른 값 변경 함수
            // LIS 업데이트 함수

        }
    }
}
