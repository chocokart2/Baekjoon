using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1043try1
{
    internal class Program
    {
        static void Say(object target) => Console.WriteLine($"DEBUG:{target}");

        // Person과 Party는 맴버를 통해 참조로 원본에 접근 해야 하므로,
        // 구조체가 아니라 클래스로 만들었습니다

        class Person
        {
            public int index;
            public List<Party> parties;
        }
        class Party
        {
            public int index;
            public List<Person> participant; // 그래프를 만들기 위해 존재하는 변수입니다.
            public List<Party> connectedParties; // 그래프 탐색을 위해 존재합니다.
        }

        // 리턴 값은 접근한 값에 대해서는 true, 접근할 수 없는 대상에는 false를 리턴. 나중에 리턴 값 || 저장 값 하여 겹치는 false 값을 골라낸다.
        static bool[] CheckGraphWhichAccessable(Party[] graph, int targetIndex)
        {
            bool[] result = new bool[graph.Length]; // 방문 처리가 된 대상입니다.

            Stack<Party> stack = new Stack<Party>();
            stack.Push(graph[targetIndex]);
            result[targetIndex] = true;

            while (stack.Count > 0)
            {

                bool isFound = false;
                // 연결된 객체를 모두 탐색하여 그 중에서 result[연결.index] == false인 대상을 올립니다.
                for (int index = 0; index < stack.Peek().connectedParties.Count; ++index)
                {
                    //Say($"인덱스 : {index}, 카운트 값 : {stack.Peek().connectedParties.Count}");

                    if (result[stack.Peek().connectedParties[index].index] == false) // 접근할 수 있는데 방문처리가 안 된 노드가 있음
                    {
                        Party target = stack.Peek().connectedParties[index];
                        stack.Push(target);
                        result[target.index] = true;
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    continue;
                }
                else
                {
                    stack.Pop();
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            // 변수를 준비합니다.
            // 사람들의 목록, 파티의 목록, 거짓말이 불가능한 파티의 목록, 진실을 아는 이들의 사람들이 주요 변수입니다.
            int result = 0;

            string[] peopleAndParties = Console.ReadLine().Split(' ');
            Person[] people = new Person[int.Parse(peopleAndParties[0])];
            for (int i = 0; i < int.Parse(peopleAndParties[0]); ++i) people[i] = new Person() { index = i, parties = new List<Party>() };
            Party[] parties = new Party[int.Parse(peopleAndParties[1])];
            bool[] isLieNotAllowedParty = new bool[parties.Length];
            // ㄴ 탐색을 통해 접근한 대상에는 true로 하고, 나중에 결과를 도출할 떄는 false를 대상으로 합니다.
            string[] blackList = Console.ReadLine().Split(' ');
            int[] peopleKnowTruth = new int[int.Parse(blackList[0])];
            for (int index = 0; index < peopleKnowTruth.Length; ++index)
                peopleKnowTruth[index] = int.Parse(blackList[index + 1]) - 1;

            // 그래프를 구성합니다.
            for (int partyIndex = 0; partyIndex < parties.Length; ++partyIndex)
            {
                string[] countAndMember = Console.ReadLine().Split(' ');
                parties[partyIndex] = new Party() {
                    index = partyIndex,
                    participant = new List<Person>(),
                    connectedParties = new List<Party>(),
                };

                // 파티의 참가자 설정
                for (int index = 1; index < countAndMember.Length; ++index)
                {
                    int personIndex = int.Parse(countAndMember[index]) - 1;

                    parties[partyIndex].participant.Add(people[personIndex]);
                    people[personIndex].parties.Add(parties[partyIndex]);
                }
            }

            // 디버그
            //foreach (Party one in parties)
            //{
            //    Console.Write($"DEBUG : 파티 {one.index}의 멤버 : ");
            //    foreach (Person single in one.participant)
            //    {
            //        Console.Write($"{single.index} ");
            //    }
            //    Console.WriteLine();
            //}
            //foreach (Person one in people)
            //{
            //    Console.Write($"DEBUG : 인간{one.index}의 참여 파티 : ");
            //    foreach (Party single in one.parties)
            //        Console.Write($"{single.index} ");
            //    Console.WriteLine();
            //}

            // 버그 이유 : parties[partyIndexOne]에서 오류! partyIndexOne는 인간의 파티 목록 내부에서만 유효함.
            // 사람을 기반으로 파티와 파티를 연결하기 시작합니다.
            for (int personIndex = 0; personIndex < people.Length; ++personIndex)
            {
                //Say($"for loop 인간\t : personIndex = {personIndex}");
                // 이 사람이 들어있는 파티는 다른 파티와 연결하기 시작합니다. O(p * n * (n -1) * t) 작업이 요구됩니다.
                for (int partyIndexOne = 0; partyIndexOne < people[personIndex].parties.Count - 1; ++partyIndexOne)
                {
                    for (int partyIndexTwo = partyIndexOne + 1; partyIndexTwo < people[personIndex].parties.Count; ++partyIndexTwo)
                    {
                        //Say($"for loop 연결\t : personIndex = {personIndex}, partyIndexOne = {partyIndexOne}, partyIndexTwo = {partyIndexTwo}");

                        // 실제로 ㅍ해당 파티와 연결되어 있는지 체크하고, 없으면 추가합니다.
                        bool isConnected = false;
                        //for (int connectIndex = 0; connectIndex < parties[partyIndexOne].connectedParties.Count; ++connectIndex)
                        for (int connectIndex = 0; connectIndex < parties[people[personIndex].parties[partyIndexOne].index].connectedParties.Count; ++connectIndex)
                        {
                            //Say($"for loop 탐색\t : personIndex = {personIndex}, partyIndexOne = {partyIndexOne}, partyIndexTwo = {partyIndexTwo}, connectIndex = {connectIndex}");

                            // 해당 파티와 연결되어 있습니다.
                            // 파티 인덱스1이 가리키는 파티가, 파티 인덱스 2를 가리키는 파티를 포함하고 있는경우 패스합니다.
                            
                            //if (parties[partyIndexOne].connectedParties[connectIndex].index == parties[partyIndexTwo].index)
                            if (people[personIndex].parties[partyIndexOne].connectedParties[connectIndex].index
                                == people[personIndex].parties[partyIndexTwo].index)
                            {
                                //Say("ReferenceEquals() : 동일한 파티를 찾았습니다.");
                                isConnected = true;
                                break;
                            }
                        }

                        if (isConnected == false)
                        {
                            people[personIndex].parties[partyIndexOne].connectedParties.Add(people[personIndex].parties[partyIndexTwo]);
                            people[personIndex].parties[partyIndexTwo].connectedParties.Add(people[personIndex].parties[partyIndexOne]);
                        }
                    }
                }
            }

            // 디버그 : 연결된 파티의 목록을 각각 출력합니다.
            //for (int index1 = 0; index1 < parties.Length; ++index1)
            //{
            //    Console.Write($"DEBUG : {index1}번 파티에 연결된 파티 : ");
            //    for (int index2 = 0; index2 < parties[index1].connectedParties.Count; ++index2)
            //    {
            //        Console.Write($"{parties[index1].connectedParties[index2].index} ");
            //    }
            //    Console.WriteLine();
            //}

            // 블랙리스트의 값을 기반으로 깊이 우선 탐색을 하여, 거짓말을 할 수 없는 Party에 표시를 합니다
            for (int personIndex = 0; personIndex < peopleKnowTruth.Length; ++personIndex)
            {
                for (int partyIndex = 0; 
                    partyIndex < people[peopleKnowTruth[personIndex]].parties.Count; 
                    ++partyIndex)
                {
                    bool[] graphPath = CheckGraphWhichAccessable(
                        parties, people[peopleKnowTruth[personIndex]].parties[partyIndex].index);

                    for (int index = 0; index < graphPath.Length; ++index)
                        isLieNotAllowedParty[index] |= graphPath[index];
                }
            }

            for (int index = 0; index < isLieNotAllowedParty.Length; ++index)
            {
                if (isLieNotAllowedParty[index] == false) ++result;
            }
            Console.WriteLine(result);
        }
    }
}
