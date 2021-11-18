using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Flyweight
{
    public class FlyweightFactory
    {
        private readonly Dictionary<string, CarFlyweight> _flyweights;

        public FlyweightFactory(params CarFlyweight[] values)
        {
            _flyweights = values.ToDictionary(x => GetKey(x));
        }

        public string GetKey(CarFlyweight key)
        {
            List<string> elements = new List<string>
            {
                key.Company,
                key.Model,
                key.Color.ToArgb().ToString("x")
            };

            elements.Sort();

            return string.Join("_", elements);
        }

        public CarFlyweight GetFlyweight(CarFlyweight sharedState)
        {
            string key = GetKey(sharedState);

            if (!_flyweights.ContainsKey(key))
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                _flyweights.Add(key, sharedState);
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return _flyweights[key];
        }



        public void ListFlyweights()
        {
            var count = _flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in _flyweights)
            {
                Console.WriteLine(flyweight.Key);
            }
        }
    }
}
