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
                return new T[0];
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
        static long[] GetPrimeNumArray(long range)
        {
            List<long> resultList = new List<long>();

            for (long i = 2; i < range; ++i)
            {
                bool isPrimeNum = true;
                for (int index = 0; index < resultList.Count; ++index)
                {
                    if (i % resultList[index] == 0)
                    {
                        isPrimeNum = false;
                        break;
                    }
                }
                if (isPrimeNum) resultList.Add(i);
            }
            return resultList.ToArray();
        }



        // 주체(Subject) 인터페이스
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        // 옵저버(Observer) 인터페이스
        public interface IObserver
        {
            void Update();
        }

        // 구체적인 주체 클래스
        public class ConcreteSubject : ISubject
        {
            private List<IObserver> observers = new List<IObserver>();
            private int state;

            public int State
            {
                get { return state; }
                set
                {
                    state = value;
                    Notify(); // 상태 변경 시 옵저버들에게 알림
                }
            }

            public void Attach(IObserver observer)
            {
                observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in observers)
                {
                    observer.Update();
                }
            }
        }

        // 구체적인 옵저버 클래스
        public class ConcreteObserver : IObserver
        {
            private ConcreteSubject subject;
            private string observerName;

            public ConcreteObserver(ConcreteSubject subject, string name)
            {
                this.subject = subject;
                observerName = name;
            }

            public void Update()
            {
                Console.WriteLine($"{observerName} has been notified: Subject's state is now {subject.State}");
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

            // 주체 객체 생성
            ConcreteSubject subject = new ConcreteSubject();

            // 옵저버 객체들 생성 및 주체에 등록
            ConcreteObserver observer1 = new ConcreteObserver(subject, "Observer 1");
            ConcreteObserver observer2 = new ConcreteObserver(subject, "Observer 2");

            subject.Attach(observer1);
            subject.Attach(observer2);

            // 주체의 상태 변경 및 알림 발생
            subject.State = 5;

            // 옵저버들을 주체에서 제거
            subject.Detach(observer1);

            // 다시 상태 변경 및 알림 발생
            subject.State = 10;
            subject.State = 15;

            Console.ReadLine();

        }
    }
}
