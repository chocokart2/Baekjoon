using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace no5052try1
{
    internal class Program
    {
        class Trie<ListType, ElementTypeofList, ValueType>
            where ListType : IEnumerable<ElementTypeofList>
        {
            public ValueType endValue;


            const bool NOT_FOUND = false;
            /// <summary>
            ///     배열의 원소를 통해 인덱스를 가져오는 방식입니다.
            /// </summary>
            private System.Collections.Generic.Dictionary<ElementTypeofList,
                Trie<ListType, ElementTypeofList, ValueType>> next;
            private bool isFinish;
            private ValueType endValueDefault;

            public Trie(ValueType valueDefault)
            {
                next = new System.Collections.Generic.Dictionary<ElementTypeofList,
                    Trie<ListType, ElementTypeofList, ValueType>>();
                ListType A;
                isFinish = false;
                endValueDefault = valueDefault;
                endValue = valueDefault;
            }
            // 삽입
            public Trie<ListType, ElementTypeofList, ValueType> Add(ListType target)
            {
                IEnumerator<ElementTypeofList> enumerator = target.GetEnumerator();
                enumerator.MoveNext();
                return AddRecursive(enumerator, target, true);
            }
            public Trie<ListType, ElementTypeofList, ValueType> AddSub(ListType target)
            {
                IEnumerator<ElementTypeofList> enumerator = target.GetEnumerator();
                enumerator.MoveNext();
                return AddRecursive(enumerator, target, false);
            }
            public Trie<ListType, ElementTypeofList, ValueType> GetSubTrie(ListType SubList)
            {
                // 작은 리스트를 집어넣고, 서브 트라이를 리턴합니다.
                IEnumerator<ElementTypeofList> enumerator = SubList.GetEnumerator();
                enumerator.MoveNext();
                return VisitRecursive(enumerator);
            }
            public bool IsExist(ListType list)
            {
                IEnumerator<ElementTypeofList> enumerator = list.GetEnumerator();
                enumerator.MoveNext();
                Trie<ListType, ElementTypeofList, ValueType> trie = VisitRecursive(enumerator);
                return (trie == null) ? NOT_FOUND : trie.isFinish;
            }
            // 탐색
            /// <summary>
            /// 
            /// </summary>
            /// <remarks>
            ///     VisitRecursive와 비슷하지만, 존재하지 않는다면 확장시킨다는 점이 있습니다.
            /// </remarks>
            /// <param name="enumerator"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            private Trie<ListType, ElementTypeofList, ValueType> AddRecursive(
                IEnumerator<ElementTypeofList> enumerator, ListType target, bool SetFinish)
            {
                ElementTypeofList nextKey = enumerator.Current;
                if (next.ContainsKey(nextKey) == NOT_FOUND)
                {
                    next.Add(nextKey, new Trie<ListType, ElementTypeofList, ValueType>(endValueDefault));
                }
                if (enumerator.MoveNext() == NOT_FOUND)
                {
                    if (next[nextKey].next.Count > 0) return null; // 자신이 누군가의 접두어이다.

                    if (SetFinish) next[nextKey].isFinish = true;
                    return next[nextKey];
                }
                if (next[nextKey].isFinish) return null; // 자신이 설정하지 않은 isFinish를 만난 경우 접두어를 만남.
                return next[nextKey].AddRecursive(enumerator, target, SetFinish);
            }
            private Trie<ListType, ElementTypeofList, ValueType> VisitRecursive(
                IEnumerator<ElementTypeofList> enumerator)
            {
                if (next.ContainsKey(enumerator.Current) == NOT_FOUND)
                {
                    return null;
                }
                Trie<ListType, ElementTypeofList, ValueType> result
                    = next[enumerator.Current];

                if (enumerator.MoveNext() == NOT_FOUND)
                {
                    return result;
                }
                return result.VisitRecursive(enumerator);
            }
            
        }

        static void Main(string[] args)
        {
            StringBuilder answer = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                Trie<string, char, bool> trie = new Trie<string, char, bool>(false);
                bool oneResult = true;
                for (int n = int.Parse(Console.ReadLine()); n > 0; n--)
                {
                    Trie<string, char, bool> one = trie.Add(Console.ReadLine());
                    if (one == null)
                    {
                        oneResult = false;
                        break;
                    }
                }
                answer.AppendLine(oneResult ? "YES" : "NO");
            }
            Console.Write(answer);
        }
    }
}
