namespace no5341try1
{
    internal class Program
    {
        static int GetBlocks(int bottom)
        {
            int result = 0;
            for (int i = bottom; i > 0; --i) result += i;
            return result;
        }

        static void Main(string[] args)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            while (true)
            {
                int bottom = int.Parse(System.Console.ReadLine());
                if (bottom == 0) break;
                result.AppendLine(GetBlocks(bottom).ToString());
            }
            System.Console.WriteLine(result);
        }
    }
}
