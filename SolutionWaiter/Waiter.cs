namespace Lab_4_Charp
{
    internal class Waiter
    {
        private SemaphoreSlim permission;

        public Waiter()
        {
            this.permission = new SemaphoreSlim(4);
        }

        public void RequestPermission()
        {
            permission.Wait();
        }

        public void ReleasePermission()
        {
            permission.Release();
        }
    }
}
