using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Command
{
    public class Garden
    {
        public int Size { get; }
        private List<string> Plants { get; } = new List<string>();

        public Garden(int size)
        {
            Size = size;
        }

        public bool Plant(string name)
        {
            if (Plants.Count < Size)
            {
                Plants.Add(name);
                Console.WriteLine($"Roślina {name} została zasadzona w ogrodzie");
                return true;
            }
            else
            {
                Console.WriteLine($"Brak miejsca w ogorodzie do zasadzenia: {name}");
                return false;
            }
        }

        public bool Remove(string name)
        {
            if (Plants.Any(x => x == name))
            {
                Plants.Remove(name);
                Console.WriteLine($"Roślina {name} została usunięta z ogrodu");
                return true;
            }
            else
            {
                Console.WriteLine($"W ogrodzie nie ma rośliny: {name}");
                return false;
            }
        }

        public override string ToString()
        {
            Console.WriteLine();
            Plants.ToList().ForEach(x => Console.WriteLine(x));
            return $"W ogrodzie jest {Plants.Count} roślin";
        }
    }
}