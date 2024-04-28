using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no19585try1
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
                    if (SetFinish) next[nextKey].isFinish = true;
                    return next[nextKey];
                }
                return next[nextKey].AddRecursive(enumerator, target, SetFinish);
            }
            private Trie<ListType, ElementTypeofList, ValueType> VisitRecursive(
                IEnumerator<ElementTypeofList> enumerator)
            {
                Trie<ListType, ElementTypeofList, ValueType> result = null;
                if (next.TryGetValue(enumerator.Current, out result) == NOT_FOUND)
                {
                    return null;
                }
                if (enumerator.MoveNext() == NOT_FOUND)
                {
                    return result;
                }
                return result.VisitRecursive(enumerator);
            }
        }

        static void Main(string[] args)
        {
            Trie<string, char, bool> trie = new Trie<string, char, bool>(false);
            string[] nums = Console.ReadLine().Split(' ');
            string[] color = new string[int.Parse(nums[0])];
            string[] name = new string[int.Parse(nums[1])];
            StringBuilder answer = new StringBuilder();
            for (int index = 0; index < color.Length; ++index)
            {
                color[index] = Console.ReadLine();
            }
            for (int index = 0; index < name.Length; ++index)
            {
                name[index] = Console.ReadLine();
            }

            int count = int.Parse(Console.ReadLine());
            Trie<string, char, bool>[] results = new Trie<string, char, bool>[count];

            for (int index = 0; index < count; ++index)
            {
                results[index] = trie.Add(Console.ReadLine());
            }
            for (int colorIndex = 0; colorIndex < color.Length; colorIndex++)
            {
                Trie<string, char, bool> subTrie = trie.GetSubTrie(color[colorIndex]);
                for (int nameIndex = 0; nameIndex < name.Length; nameIndex++)
                {
                    Trie<string, char, bool> end = subTrie.GetSubTrie(name[nameIndex]);
                    if (end != null) end.endValue = true;
                }
            }
            for (int index = 0; index < count; ++index)
            {
                answer.AppendLine(results[index].endValue ? "Yes" : "No");
            }
            Console.Write(answer);
        }
    }
}
