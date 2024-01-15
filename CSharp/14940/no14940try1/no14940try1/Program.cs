using System;
using System.Text;

namespace no14940try1
{
    internal class Program
    {
        class Map
        {
            public int[,] data; // [x, y]로 접근
            public int[,] step;
            public bool[,] visited;
            public int SizeY { get; private set; }
            public int SizeX { get; private set; }
            public int StartX { get; private set; }
            public int StartY { get; private set; }
            
            public Map(int _xSize, int _ySize)
            {
                SizeY = _ySize;
                SizeX = _xSize;
                data = new int[SizeX, SizeY];
                step = new int[SizeX, SizeY];
                visited = new bool[SizeX, SizeY];

                for (int y = 0; y < SizeY; ++y)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');

                    for (int x = 0; x < SizeX; ++x)
                    {
                        switch (recvLine[x][0])
                        {
                            case '0':
                                data[x, y] = 0;
                                break;
                            case '1':
                                data[x, y] = 1;
                                break;
                            case '2':
                                StartX = x; StartY = y;
                                data[x, y] = 2;
                                break;
                            default: break;
                        }
                    }
                }
            }
            public bool IsAbleToStep(int x, int y)
            {
                if (x < 0 || x >= SizeX) return false;
                if (y < 0 || y >= SizeY) return false;
                return !((data[x, y] == 0) || (visited[x, y]));
            }
            public void Step(Node item)
            {
                step[item.x, item.y] = item.step;
                visited[item.x, item.y] = true;
            }
            public void Seal()
            {
                for (int x = 0; x < SizeX; ++x)
                {
                    for (int y = 0; y < SizeY; ++y)
                    {
                        if (visited[x,y] == false)
                        {
                            if (data[x, y] == 1) step[x, y] = -1;
                        }
                    }
                }
            }
            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                // 벽은 0으로 표현
                // 못간건 -1로 표현

                for (int y = 0; y < SizeY; ++y)
                {
                    result.Append(step[0, y]);

                    for (int x = 1; x < SizeX; ++x)
                    {
                        result.Append($" {step[x, y]}");
                    }
                    result.Append('\n');
                }

                return result.ToString();
            }
        }
        class NodeQueue
        {
            Node[] data;
            int rear = 0;
            int head = 0;

            public NodeQueue(int size)
            {
                data = new Node[size];
            }

            public Node Pop()
            {
                if (head - rear <= 0) return null;
                ++rear;
                return data[rear - 1];
            }
            public void Push(Node item)
            {
                data[head] = item;
                ++head;
            }
            public bool IsEmpty()
            {
                return rear >= head;
            }
        }

        class Node
        {
            public int x;
            public int y;
            public int step;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int n = int.Parse(nums[0]);
            int m = int.Parse(nums[1]);

            Map map = new Map(m, n);
            NodeQueue queue = new NodeQueue(n * m + 1);

            Node start = new Node() { x = map.StartX, y = map.StartY, step = 0 };
            queue.Push(start);
            map.Step(start);
            //Console.WriteLine($"StartX = {map.StartX}, startY = {map.StartY}");
            while (!(queue.IsEmpty()))
            {
                Node one = queue.Pop();
                //Console.WriteLine($"while loop : one.x = {one.x}, one.y = {one.y}, one.step = {one.step}");

                if (map.IsAbleToStep(one.x + 1, one.y))
                {
                    Node next = new Node() { x = one.x + 1, y = one.y, step = one.step + 1 };
                    queue.Push(next);
                    map.Step(next);
                }
                if (map.IsAbleToStep(one.x - 1, one.y))
                {
                    Node next = new Node() { x = one.x - 1, y = one.y, step = one.step + 1 };
                    queue.Push(next);
                    map.Step(next);
                }
                if (map.IsAbleToStep(one.x, one.y + 1))
                {
                    Node next = new Node() { x = one.x, y = one.y + 1, step = one.step + 1 };
                    queue.Push(next);
                    map.Step(next);
                }
                if (map.IsAbleToStep(one.x, one.y - 1))
                {
                    Node next = new Node() { x = one.x, y = one.y - 1, step = one.step + 1 };
                    queue.Push(next);
                    map.Step(next);
                }
            }
            map.Seal();
            Console.WriteLine(map.ToString());
        }
    }
}
