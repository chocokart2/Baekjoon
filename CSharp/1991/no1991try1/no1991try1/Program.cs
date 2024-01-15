using System;
using System.Collections.Generic;

namespace no1991try1
{
    internal class Program
    {
        class Tree
        {
            public char letter;
            public Tree left;
            public Tree right;

            public string GetPreorder() => $"{letter}{left?.GetPreorder() ?? ""}{right?.GetPreorder() ?? ""}";
            public string GetInorder() => $"{left?.GetInorder() ?? ""}{letter}{right?.GetInorder() ?? ""}";
            public string GetPostorder() => $"{left?.GetPostorder() ?? ""}{right?.GetPostorder() ?? ""}{letter}";
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Tree[] binaryTree = new Tree[size];

            string[] recvLine = new string[size];
            Dictionary<char, int> convertCharToIndex = new Dictionary<char, int>();

            for (int index = 0; index < size; ++index)
            {
                recvLine[index] = Console.ReadLine();
                convertCharToIndex.Add(recvLine[index][0], index);
                binaryTree[index] = new Tree()
                {
                    letter = recvLine[index][0]
                };
            }

            for (int index = 0; index < size; ++index)
            {
                if (recvLine[index][2] != '.')
                {
                    binaryTree[index].left = binaryTree[convertCharToIndex[recvLine[index][2]]];
                }
                if (recvLine[index][4] != '.')
                {
                    binaryTree[index].right = binaryTree[convertCharToIndex[recvLine[index][4]]];
                }
            }

            Console.WriteLine(binaryTree[0].GetPreorder());
            Console.WriteLine(binaryTree[0].GetInorder());
            Console.WriteLine(binaryTree[0].GetPostorder());
        }
    }
}
