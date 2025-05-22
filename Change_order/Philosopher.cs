namespace Lab_4_Charp.Change_order
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

            if (id == 0)
            {
                leftFork = id;
                rightFork = (id + 1) % 5;
            }
            else
            {
                rightFork = id;
                leftFork = (id + 1) % 5;
            }

            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Order.Philosopher {id} is thinking {i + 1} times");

                table.GetFork(rightFork);
                table.GetFork(leftFork);


                Console.WriteLine($"Order.Philosopher {id} is eating {i + 1} times");

                table.PutFork(leftFork);
                table.PutFork(rightFork);
            }
        }
    }
}
