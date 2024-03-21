using System;
using System.Collections.Generic;

namespace no1897try1
{
    internal class Program
    {
        static bool IsNestStep(string prev, string next)
        {
            if (prev.Length + 1 != next.Length) return false;

            int rearIndex = 0;
            int headIndex = next.Length - 1;
            
            for (; rearIndex < next.Length - 1; rearIndex++)
            {
                //Console.WriteLine($"rear = {rearIndex} : {prev[rearIndex]}, {next[rearIndex]}");
                if (prev[rearIndex] != next[rearIndex]) break;
            }
            for (; headIndex > 0; headIndex--)
            {
                //Console.WriteLine($"hear = {headIndex} : {prev[headIndex - 1]}, {next[headIndex]}");
                if (prev[headIndex - 1] != next[headIndex]) break;
            }

            //Console.WriteLine($"head = {headIndex}, rear = {rearIndex}");
            return rearIndex >= headIndex;
        }

        class Node
        {
            public string name;
            public List<Node> next;
        }

        static void Main(string[] args)
        {


            string[] startLine = Console.ReadLine().Split(' ');
            
            string startStr = startLine[1];
            int startIndex = -1;
            Node[] words = new Node[int.Parse(startLine[0])];
            for (int index = 0; index < words.Length; ++index)
            {
                words[index] = new Node();
                words[index].name = Console.ReadLine();
                words[index].next = new List<Node>(words.Length);
                if (startStr.Equals(words[index].name)) startIndex = index;
                for (int subIndex = 0; subIndex < index; ++subIndex)
                {
                    if (IsNestStep(words[index].name, words[subIndex].name)) words[index].next.Add(words[subIndex]);
                    if (IsNestStep(words[subIndex].name, words[index].name)) words[subIndex].next.Add(words[index]);
                }
            }

            Queue<Node> next = new Queue<Node>();
            next.Enqueue(words[startIndex]);
            string result = words[startIndex].name;

            while (next.Count > 0)
            {
                Node one = next.Dequeue();

                for (int index = 0; index < one.next.Count; ++index)
                {
                    next.Enqueue(one.next[index]);
                    if (result.Length < one.next[index].name.Length)
                    {
                        result = one.next[index].name;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
