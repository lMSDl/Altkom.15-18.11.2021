using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Proxy
{
    public class Client
    {
        public static void Execute()
        {
            IDatabase database = new Database();
            database = new DatabaseProxy(database);

            database.Connect();

            for (var i = 1; i < 11; i++)
            {
                _ = database.RequestAsync(i);
            }

            Console.ReadKey();

            for (var i = 1; i < 11; i++)
            {
                _ = database.RequestAsync(i);
            }

            Console.ReadKey();
        }
    }
}
