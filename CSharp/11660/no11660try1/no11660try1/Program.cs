using System;
using System.Text;

namespace no11660try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 각 배열의 원소에는 (0,0)에서 (x,y)를 꼭지점으로 하는 직사각형의 합을 적습니다.

            StringBuilder result = new StringBuilder();

            string[] m_recvLineNM = Console.ReadLine().Split(' ');
            int m_n = int.Parse(m_recvLineNM[0]);
            int m_m = int.Parse(m_recvLineNM[1]);
            int[,] m_sum = new int[m_n + 1, m_n + 1]; // m_sum[0, ?] = 0 and m_sum[?, 0] = 0 구현의 편의상 한칸 더 늘렸습니다.

            for (int y = 1; y <= m_n; ++y)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int lineSum = 0;
                for (int x = 1; x <= m_n; ++x)
                {
                    int one = int.Parse(recvLine[x - 1]);
                    lineSum += one;
                    m_sum[x, y] = m_sum[x, y - 1] + lineSum;
                }
            }

            for (int i = 0; i < m_m; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int y1 = int.Parse(recvLine[0]) - 1;
                int x1 = int.Parse(recvLine[1]) - 1;
                int y2 = int.Parse(recvLine[2]);
                int x2 = int.Parse(recvLine[3]);

                int one = m_sum[x2, y2] - m_sum[x1, y2] - m_sum[x2, y1] + m_sum[x1, y1];
                result.AppendLine(one.ToString());
            }
            Console.Write(result);
        }
    }
}
