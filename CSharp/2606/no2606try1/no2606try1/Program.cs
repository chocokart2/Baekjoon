using System;

namespace no2606try1
{
    internal class Program
    {
        class Computer
        {
            public bool Infected { get; private set; }
            int num;
            public int connectedCursor;
            public Computer[] connected;
            
            public Computer(int size, int index)
            {
                Infected = false;
                num = index;
                connectedCursor = 0;
                connected = new Computer[size];
            }
            public void Infect() => Infected = true;

            public static void ConnectComputers(Computer left, Computer right)
            {
                left.connected[left.connectedCursor] = right;
                left.connectedCursor++;
                right.connected[right.connectedCursor] = left;
                right.connectedCursor++;
            }
        }


        static void Main(string[] args)
        {
            int result = 0;
            Computer[] networks = new Computer[int.Parse(Console.ReadLine())];
            for (int index = 0; index < networks.Length; ++index)
            {
                networks[index] = new Computer(networks.Length, index);
            }
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                Computer.ConnectComputers(networks[int.Parse(nums[0]) - 1], networks[int.Parse(nums[1]) - 1]);
            }

            Computer[] stackData = new Computer[100];
            int stackRear = 0;
            int stackFront = 0;

            void Push(Computer target)
            {
                stackData[stackFront] = target;
                ++stackFront;
            }
            Computer Pop()
            {
                if (stackFront - stackRear < 1) return null;
                ++stackRear;
                return stackData[stackRear - 1];
            }

            Push(networks[0]);
            networks[0].Infect();
            while (stackFront - stackRear > 0)
            {
                Computer currentComputer = Pop();

                for (int index = 0; index < currentComputer.connectedCursor; ++index)
                {
                    if (currentComputer.connected[index].Infected == false)
                    {
                        Push(currentComputer.connected[index]);
                        currentComputer.connected[index].Infect();
                        ++result;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
