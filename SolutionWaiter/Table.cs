namespace Lab_4_Charp.SolutionWaiter
{
    internal class Table
    {
        private SemaphoreSlim[] forks = new SemaphoreSlim[5];

        public Table()
        {
            for (int i = 0; i < 5; i++)
            {
                forks[i] = new SemaphoreSlim(1);
            }
        }

        public void GetFork(int id)
        {
            forks[id].Wait();
        }

        public void PutFork(int id)
        {
            forks[id].Release();
        }
    }
}
