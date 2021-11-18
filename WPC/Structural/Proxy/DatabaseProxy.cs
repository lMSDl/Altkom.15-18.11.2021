using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPC.Structural.Proxy
{
    public class DatabaseProxy : IDatabase
    {
        private readonly IDatabase _database;
        private readonly SemaphoreSlim semaphoreSlim;

        public int MaxCount { get; set; } = 3;

        public DatabaseProxy(IDatabase database)
        {
            semaphoreSlim = new SemaphoreSlim(MaxCount);
            _database = database;
        }

        public bool IsConnected => _database.IsConnected;

        public void Connect()
        {
            _database.Connect();
        }

        public void Disconnect()
        {
            _database.Disconnect();
        }

        public async Task<int?> RequestAsync(int parameter)
        {
            if (!IsConnected)
                Connect();
            await semaphoreSlim.WaitAsync();
            var result = await _database.RequestAsync(parameter);
            semaphoreSlim.Release();

            if (semaphoreSlim.CurrentCount == MaxCount)
                Disconnect();

            return result;
        }
    }
}
