using Lab_4_Charp;
using Lab_4_Charp.Change_order;

namespace Lab_4_Csharp
{
    internal class Philosopher
    {
        private Table table;
        private Waiter waiter;
        private int id;
        private int leftFork, rightFork;
        private Thread thread;

        public Philosopher(int id, Table table, Waiter waiter)
        {
            this.id = id;
            this.table = table;
            this.waiter = waiter;
            rightFork = id;
            leftFork = (id + 1) % 5;
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Philosopher {id} is thinking ({i + 1})");

                waiter.RequestPermission();

                table.GetFork(rightFork);
                table.GetFork(leftFork);

                Console.WriteLine($"Philosopher {id} is eating ({i + 1})");

                table.PutFork(rightFork);
                table.PutFork(leftFork);

                waiter.ReleasePermission();
            }
        }
    }
}
