internal class Program
{
    private static void Main(string[] args)
    {
        int n;
        for (int i = 1; i < 101 ; i++)
        {
            if (i % 3 == 0 || i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}