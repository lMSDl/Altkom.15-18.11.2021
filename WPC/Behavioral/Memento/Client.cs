using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.Memento
{
    public static class Client
    {
        public static void Execute()
        {
            var person = new Person();
            person.Name = "Adam Adamski";
            person.BirthDate = new DateTime(1992, 1, 23);

            var caretaker = new GenericCaretaker<Person>(person);
            caretaker.SaveState();
            
            Console.WriteLine($"Name: {person.Name}");

            person.Name = "Ala";
            Console.WriteLine($"Name: {person.Name}");
            caretaker.SaveState();
            Console.WriteLine($"Name: {person.Name}");

            person.Name = "Ala Alowska";
            Console.WriteLine($"Name: {person.Name}");

            caretaker.Undo();
            Console.WriteLine($"Name: {person.Name}");

            person.Name = "Ewa Ewowska";
            Console.WriteLine($"Name: {person.Name}");
            caretaker.SaveState();

            caretaker.ShowHistory();


            caretaker.Undo();
            caretaker.Undo();
            caretaker.Undo();
            Console.WriteLine($"Name: {person.Name}");


        }
    }
}
