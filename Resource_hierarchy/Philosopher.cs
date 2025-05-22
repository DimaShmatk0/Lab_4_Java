namespace Lab_4_Charp.Resource_hierarchy
{
    internal class Philosopher
    {
        private readonly Table table;
        private readonly int leftFork, rightFork;
        private readonly int id;
        private readonly Thread thread;

        public Philosopher(int id, Table table)
        {
            this.id = id;
            this.table = table;

            rightFork = id;
            leftFork = (id + 1) % 5;

            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Philosopher {id} is thinking {i + 1} times");

                if (rightFork < leftFork)
                {
                    table.GetFork(rightFork);
                    table.GetFork(leftFork);
                }
                else
                {
                    table.GetFork(leftFork);
                    table.GetFork(rightFork);
                }

                Console.WriteLine($"Philosopher {id} is eating {i + 1} times");

                if (rightFork < leftFork)
                {
                    table.PutFork(leftFork);
                    table.PutFork(rightFork);
                }
                else
                {
                    table.PutFork(rightFork);
                    table.PutFork(leftFork);
                }
            }
        }
    }
}
