using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Proxy
{
    public class Database : IDatabase
    {
        private int _connectionCounter = 0;

        public bool IsConnected { get; set; }

        public void Connect()
        {
            IsConnected = true;
            Console.WriteLine("Connection open");
        }

        public void Disconnect()
        {
            IsConnected = false;
            Console.WriteLine("Connection closed");
        }

        public async Task<int?> RequestAsync(int parameter)
        {
            if (_connectionCounter >= 5)
            {
                Console.WriteLine($"Request {parameter} dropped!");
                return null;
            }

            _connectionCounter++;
            Console.WriteLine($"Opening connectino {_connectionCounter}");
            await Task.Delay(1000);

            Console.WriteLine($"Request {parameter} completed ({_connectionCounter})");
            _connectionCounter--;
            return parameter;
        }
    }
}
