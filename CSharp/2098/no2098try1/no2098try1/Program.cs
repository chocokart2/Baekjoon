using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2098try1
{
    internal class Program
    {
        public class Debugger
        {
            bool isDebugMode;
            int funcStack = 0;
            int loopcount = 0;

            public Debugger(bool isDebugMode = true)
            {
                this.isDebugMode = isDebugMode;
            }
            public void EnterFunction(string message)
            {
                if (isDebugMode)
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < funcStack; ++i)
                    {
                        result.Append("| ");
                    }
                    result.Append(message);

                    Console.WriteLine(result);
                }
                ++funcStack;
            }
            public void ExitFunction(string message)
            {
                funcStack -= 1;
                if (isDebugMode)
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < funcStack; ++i)
                    {
                        result.Append("| ");
                    }
                    result.Append(message);

                    Console.WriteLine(result);
                }
            }
        }

        static Debugger myDebugger;

        static int size;
        static int finishBitCode;
        static int[,] visitCost; // [start, end]
        static int[,] memory; // [position, visitingStatus]

        //sus
        static int LoiterAround(int currentPosition, int visitingStatus)
        {
            myDebugger.EnterFunction($"LoiterAround({currentPosition}, {visitingStatus})");

            if (visitingStatus == finishBitCode)
            {
                if (visitCost[currentPosition, 0] > 0)
                {
                    myDebugger.ExitFunction($"LoiterAround({currentPosition}, {visitingStatus}) = (visitCost){visitCost[currentPosition, 0]}");
                    return visitCost[currentPosition, 0];
                }
                myDebugger.ExitFunction($"LoiterAround({currentPosition}, {visitingStatus}) = int.MaxValue");
                return (int.MaxValue >> 1);
            }


            if (memory[currentPosition, visitingStatus] != 0)
            {
                myDebugger.ExitFunction($"LoiterAround({currentPosition}, {visitingStatus}) = {memory[currentPosition, visitingStatus]}");
                return memory[currentPosition, visitingStatus];
            }
            else memory[currentPosition, visitingStatus] = (int.MaxValue >> 1);

            for (int nextPosition = 0; nextPosition < size; ++nextPosition)
            {
                // 갈 수 없거나, 이미 방문한 노드인 경우 무시
                if (visitCost[currentPosition, nextPosition] == 0) continue;
                if ((visitingStatus & (1 << nextPosition)).Equals(1 << nextPosition)) continue;

                memory[currentPosition, visitingStatus] =
                    Math.Min(
                        memory[currentPosition, visitingStatus],
                        visitCost[currentPosition, nextPosition]
                        + LoiterAround(nextPosition, visitingStatus | (1 << nextPosition))
                    );
            }
            
            myDebugger.ExitFunction($"LoiterAround({currentPosition}, {visitingStatus}) = {memory[currentPosition, visitingStatus]}");
            return memory[currentPosition, visitingStatus];
        }



        static void Main(string[] args)
        {
            myDebugger = new Debugger(false);
            size = int.Parse(Console.ReadLine());

            finishBitCode = (1 << size) - 1;
            //visitCost = new int[size, size];
            visitCost = new int[16, 16];
            //memory = new int[size, (1 << size)];
            memory = new int[16, (1 << 16)];

            for (int indexStart = 0; indexStart < size; ++indexStart)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                for (int indexEnd = 0; indexEnd < size; ++indexEnd)
                {
                    visitCost[indexStart, indexEnd]
                        = int.Parse(recvLine[indexEnd]);
                }
            }

            Console.WriteLine(
                LoiterAround(0, 1));
        }
    }
}
