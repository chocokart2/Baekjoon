using System;
using System.Collections.Generic;
using System.Text;

namespace no4378try1
{
    internal class Program
    {
        static StringBuilder sb = new StringBuilder();

        static readonly Dictionary<char, char> charPairs = new Dictionary<char, char>()
        {
            { '1', '`' },
            { '2', '1' },
            { '3', '2' },
            { '4', '3' },
            { '5', '4' },
            { '6', '5' },
            { '7', '6' },
            { '8', '7' },
            { '9', '8' },
            { '0', '9' },
            { '-', '0' },
            { '=', '-' },

            { 'W', 'Q' },
            { 'E', 'W' },
            { 'R', 'E' },
            { 'T', 'R' },
            { 'Y', 'T' },
            { 'U', 'Y' },
            { 'I', 'U' },
            { 'O', 'I' },
            { 'P', 'O' },
            { '[', 'P' },
            { ']', '[' },
            { '\\', ']' },
            
            { 'S', 'A' },
            { 'D', 'S' },
            { 'F', 'D' },
            { 'G', 'F' },
            { 'H', 'G' },
            { 'J', 'H' },
            { 'K', 'J' },
            { 'L', 'K' },
            { ';', 'L' },
            { '\'', ';' },

            { 'X', 'Z' },
            { 'C', 'X' },
            { 'V', 'C' },
            { 'B', 'V' },
            { 'N', 'B' },
            { 'M', 'N' },
            { ',', 'M' },
            { '.', ',' },
            { '/', '.' },

            { ' ', ' ' }
        };


        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                    break;
                for (int index = 0; index < input.Length; ++index)
                    sb.Append(charPairs[input[index]]);
                sb.Append('\n');
            }

            Console.Write(sb);
        }
    }
}
