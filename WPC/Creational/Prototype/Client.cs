using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.Prototype
{
    public class Client
    {
        public static void Execute()
        {
            var p1 = new Person
            {
                Age = 23,
                Name = "Adam Adamski",
                Addresses = new List<string> { "Krakowska 3, 11-222 Warszawa" }
            };

            Display(p1);

            var p2 = (Person)p1.Clone();
            p2.Name = "Ewa Adamska";
            Display(p2);

            p2.Addresses.Clear();
            p2.Addresses.Add("Warszawska 1/3, 22-111 Kraków");

            Display(p1);
            Display(p2);
        }

        public static void Display(Person person)
        {
            Console.WriteLine($"Name: {person.Name}, Age {person.Age}, Address: {string.Join(';', person.Addresses)}");
        }
    }
}
