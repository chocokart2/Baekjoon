using System;

namespace no1003try1
{
    internal class Program
    {
        struct FibonacciResult
        {
            public bool isNotNull;
            public int zero;
            public int one;

            static public FibonacciResult Add(FibonacciResult left, FibonacciResult right)
            {
                return new FibonacciResult()
                {
                    isNotNull = true,
                    zero = left.zero + right.zero,
                    one = left.one + right.one
                };
            }
        }

        // memory for dynamic programming
        static FibonacciResult[] memory = new FibonacciResult[41];

        static FibonacciResult GetFibonacci(int target)
        {
            if (memory[target].isNotNull == false)
            {
                memory[target] = FibonacciResult.Add(
                    GetFibonacci(target - 1),
                    GetFibonacci(target - 2));
            }
            return memory[target];
        }

        static void Main(string[] args)
        {
            // memory for dynamic programming
            memory[0] = new FibonacciResult() { isNotNull = true, one = 0, zero = 1};
            memory[1] = new FibonacciResult() { isNotNull = true, one = 1, zero = 0};

            int caseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < caseCount; ++i)
            {
                int target = int.Parse(Console.ReadLine());
                FibonacciResult result = GetFibonacci(target);
                Console.WriteLine($"{result.zero} {result.one}");
            }
        }
    }
}
