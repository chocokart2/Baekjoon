using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        // 다른 숫자를 가리킬 수 있는 존재
        class PrimeNumBox

        static int GetIndex(int num)
        {

        }



        static void Main(string[] args)
        {
            // 1. 배열 만들기
            // 2. 프라임 넘버 찾으면서, 각 수의 프라임 넘버로 된 약수 구하기
            // 2.1. 약수를 구하면서 동시에 1을 제외한 프라임 배열의 원소는 자신의 배수를 가리키기. // 그러면 객체?
            // 3. 서로소를 찾을 때,
            // 3.1. 자신의 첫번째 숫자는 시작부터 끝까지 고르고, 두번째 숫자는 반드시 첫번째 숫자보다 큰 숫자를 고르기
            // 3.2. 자신의 첫번째 숫자들의, 자신의 프라임 넘버 약수들이 가리키는 배수들은 전부 제거하기.
            // 3.3. 제거하고 남은 숫자들은 전부 자신들의 서로소입니다. // bool
            // 3.4. 찾았으면 그 쌍을 제거함, 그리고 3번 반복!
            // 4. 1부터 3까지의 과정이 A일때, 가능한 A의 모든 경우를 찾아야 함. 그리고 모두 제거할 수 있어야 함.
            // 일단 현재의 과정을 두 인덱스가 원소인 스택으로 만들어야 함. 만약 원소는 있는데 서로소가 없어 돌아가야 하는 상황이 있으면 pop을통해
            // 되돌아가는 과정을 통해 가능한 경우를 모두 탐색 할 수 있음.
            // 모든 과정을 탐색해야 함. 치울 수 있는 경우의 목록을 발견하면 배열에 저장하고, 계속 진행.
            // 탐색이 끝나면 그 배열을 리턴합니다.
            // 브루트 포스로 찾아야 하나요?
            //

            string[] nums = Console.ReadLine().Split(' ');
            int n = int.Parse(nums[0]);
            int a = int.Parse(nums[1]);
            int b = int.Parse(nums[2]);
            int[] s = new int[2 * n];
            for (int index = 0; index < s.Length; ++index)
                s[index] = a + b * index;
            // 1_000_000_000
            int[] primeNumToIndex = new int[2 * n]; // 인덱스의 프라임 넘버를 넣으면 아래 배열에 그 숫자가 있는의 원소의 인덱스를 가리켜 줍니다.
            int[] primeNumbers = new int[2 * n]; // 프라임 넘버의 배열입니다.
            
            int primeNumbersSize = 0; // 이때까지 찾은 프라임 넘버의 갯수입니다.

            List<int> x = new List<int>();
            var xx = x.GetEnumerator();
            x
            // 
            for (int index = 0; index < s.Length; ++index)
            {
                    


            }


        }
    }
}
