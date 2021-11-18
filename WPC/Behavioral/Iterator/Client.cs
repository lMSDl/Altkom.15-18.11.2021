using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Iterator
{
    public static class Client
    {
        public static void Execute()
        {
            var list = new List<string>() { "a", "b", "c" };

            var buffer = new Buffer<string>(list);

            using (var iterator = buffer.GetEnumerator())
                while (iterator.MoveNext())
                {
                    var item = iterator.Current;
                    Console.WriteLine($"{item[0]}{item[1]}");
                }

            foreach (var item in buffer)
            {
                Console.WriteLine($"{item[0]}{item[1]}");
            }
        }
    }
}
