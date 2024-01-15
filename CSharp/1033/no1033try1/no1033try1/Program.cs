using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1033try1
{
    internal class Program
    {
        public class Graph<TNodeData, TEdgeData>
        {
            // NestedClass
            public class Edge
            {
                public Node connectedNode;
                public TEdgeData containData;
            }
            public class Node
            {
                public int index; // 인덱스 접근을 위하여
                public TNodeData containData;
                public System.Collections.Generic.List<Edge> edges;

                public Node()
                {
                    edges = new System.Collections.Generic.List<Edge>();
                }
            }

            // Fields
            public Node[] nodes;

            // Constructor
            public Graph() { }
            public Graph(int size)
            {
                nodes = new Node[size];
                for (int index = 0; index < size; ++index)
                {
                    nodes[index] = new Node();
                    nodes[index].index = index;
                }
            }

            // Function
            public void BuildOneWay(int begin, int destination, TEdgeData data)
            {
                nodes[begin].edges.Add(
                    new Edge()
                    {
                        connectedNode = nodes[destination],
                        containData = data
                    }
                    );
            }
            public void BuildTwoWay(int begin, int destination, TEdgeData data)
            {
                BuildOneWay(begin, destination, data);
                BuildOneWay(destination, begin, data);
            }
            public void BuildTwoWay(int begin, int destination, TEdgeData beginData, TEdgeData destinationData)
            {
                BuildOneWay(begin, destination, beginData);
                BuildOneWay(destination, begin, destinationData);
            }
        }

        public class Ratio
        {
            public int itemIndexA;
            public int itemIndexB;
            public int amountA;
            public int amountB;
        }
        //    public class Ratio
        //    {
        //        public int ingredientA;
        //        public int ingredientB;
        //        public int aAmount;
        //        public int bAmount;

        //        public void Init(string ratioString)
        //        {
        //            string[] nums = ratioString.Split(' ');

        //            ingredientA = int.Parse(nums[0]);
        //            ingredientB = int.Parse(nums[0]);
        //            aAmount = int.Parse(nums[0]);
        //            bAmount = int.Parse(nums[0]);
        //        }
        //    }

        //class Recipe
        //{
        //    public class Ratio
        //    {
        //        public int ingredientA;
        //        public int ingredientB;
        //        public int aAmount;
        //        public int bAmount;

        //        public void Init(string ratioString)
        //        {
        //            string[] nums = ratioString.Split(' ');

        //            ingredientA = int.Parse(nums[0]);
        //            ingredientB = int.Parse(nums[0]);
        //            aAmount = int.Parse(nums[0]);
        //            bAmount = int.Parse(nums[0]);
        //        }
        //    }

        //    public int[] amount;
        //    public Ratio[] ratios;

        //    public Recipe(int size)
        //    {
        //        amount = new int[size];
        //        for (int index = 0; index < size; ++index)
        //        {
        //            amount[index] = 1;
        //        }
        //        ratios = new Ratio[size - 1];
        //    }

        //}


        static void Spread(Graph<int, Ratio> recipe, int target, int opposite, int coefficient)
        {
            //Console.WriteLine($">> Spread(recipe, {target}, {opposite}, {coefficient})");

            // 그래프 탐색을 진행합니다.
            int[] queueItem = new int[recipe.nodes.Length];
            //int[] queueItem = new int[100];
            //Console.WriteLine($"int[] queueItem = new int[{recipe.nodes.Length}]");
            int queueRear = 0;
            int queueHead = 1;
            bool[] hasVisited = new bool[recipe.nodes.Length];
            queueItem[0] = target;
            hasVisited[target] = true;
            
            while (queueHead - queueRear > 0)
            {
                //Console.WriteLine($">> queueHead = {queueHead}");

                int oneItemIndex = queueItem[queueRear];
                // 해당 아이템을 곱합니다.
                recipe.nodes[oneItemIndex].containData *= coefficient;
                for (int index = 0; index < recipe.nodes[oneItemIndex].edges.Count; ++index)
                {
                    Graph<int, Ratio>.Edge oneEdge = recipe.nodes[oneItemIndex].edges[index];
                    //Console.WriteLine($">> recipe.nodes[oneItemIndex].edges[index].connectedNode.index = {oneEdge.connectedNode.index}");
                    if (oneEdge.connectedNode.index == opposite)
                    {
                        //Console.WriteLine($">> oneEdge.connectedNode.index == {oneEdge.connectedNode.index}");
                        continue;
                    }
                    if (hasVisited[oneEdge.connectedNode.index])
                    {
                        //Console.WriteLine($">> hasVisited[{oneEdge.connectedNode.index}] == true");
                        continue;
                    }

                    //Console.WriteLine($">> queueItem[{queueHead}] = {oneEdge.connectedNode.index}");
                    queueItem[queueHead] = oneEdge.connectedNode.index;
                    hasVisited[oneEdge.connectedNode.index] = true;
                    ++queueHead;
                    //Console.WriteLine($"queueHead++. queueHead = {queueHead}");
                }

                queueRear++;
            }
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Ratio[] ratios = new Ratio[count - 1];
            Graph<int, Ratio> recipe = new Graph<int, Ratio>(count);
            List<int> primeNums = new List<int>();

            for (int i = 2; i < 59_049; ++i)
            {
                bool isPrimeNum = true;
                for (int index = 0; index < primeNums.Count; ++index)
                {
                    if (i % primeNums[index] == 0)
                    {
                        isPrimeNum = false;
                        break;
                    }
                }
                if (isPrimeNum) primeNums.Add(i);
                //if (isPrimeNum) Console.WriteLine($">> primeNum = {i}");
            }

            for (int index = 0; index < recipe.nodes.Length; ++index)
            {
                recipe.nodes[index].containData = 1;
            }

            for (int index = 0; index < count - 1; ++index)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int oneItemIndexA = int.Parse(nums[0]);
                int oneItemIndexB = int.Parse(nums[1]);

                ratios[index] = new Ratio()
                {
                    itemIndexA = oneItemIndexA,
                    itemIndexB = oneItemIndexB,
                    amountA = int.Parse(nums[2]),
                    amountB = int.Parse(nums[3])
                };
                recipe.BuildTwoWay(oneItemIndexA, oneItemIndexB, ratios[index]);
            }

            for (int index = 0; index < ratios.Length; ++index)
            {
                Ratio one = ratios[index];
                Spread(recipe, one.itemIndexA, one.itemIndexB, one.amountA);
                Spread(recipe, one.itemIndexB, one.itemIndexA, one.amountB);
            }

            for (int primeIndex = 0; primeIndex < primeNums.Count;)
            {
                bool isDivideable = true;
                for (int index = 0; index < count; ++index)
                {
                    if (recipe.nodes[index].containData % primeNums[primeIndex] != 0)
                    {
                        isDivideable = false;
                    }
                }

                if (isDivideable)
                {
                    for (int index = 0; index < count; ++index)
                    {
                        recipe.nodes[index].containData /= primeNums[primeIndex];
                        //Console.WriteLine($"recipe.nodes[{index}].containData({recipe.nodes[index].containData}) /= {primeNums[primeIndex]}");
                    }
                }
                else
                {
                    primeIndex++;
                    //Console.WriteLine($"primeIndex = {primeIndex}");
                }
            }

            StringBuilder result = new StringBuilder();
            result.Append(recipe.nodes[0].containData);
            for (int index = 1; index < recipe.nodes.Length; ++index)
            {
                result.Append($" {recipe.nodes[index].containData}");
            }
            Console.WriteLine(result);
        }
    }
}
