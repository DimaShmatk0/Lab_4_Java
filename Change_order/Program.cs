namespace Lab_4_Charp.Change_order
{
    internal class Program
    {
        static void Main(bool a)
        {
            Console.WriteLine("Change_order");
            Table table = new();

            for (int i = 0; i < 5; i++)
            {
                new Philosopher(i, table);
            }
        }
    }
}
