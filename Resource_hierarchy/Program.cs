namespace Lab_4_Charp.Resource_hierarchy
{
    internal class Program
    {
        static void Main(int a)
        {
            Console.WriteLine("Resource_hierarchy");
            Table table = new();

            for (int i = 0; i < 5; i++)
            {
                new Philosopher(i, table);
            }

            Console.ReadLine();
        }
    }
}
