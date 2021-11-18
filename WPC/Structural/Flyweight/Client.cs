using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Structural.Flyweight
{
    public static class Client
    {
        public static void Execute()
        {
            var factory = new FlyweightFactory(
                  new CarFlyweight { Company = "Chevrolet", Model = "Camaro2018", Color = Color.Pink },
                  new CarFlyweight { Company = "Mercedes Benz", Model = "C300", Color = Color.Black },
                  new CarFlyweight { Company = "Mercedes Benz", Model = "C500", Color = Color.Red },
                  new CarFlyweight { Company = "BMW", Model = "M5", Color = Color.Red },
                  new CarFlyweight { Company = "BMW", Model = "X6", Color = Color.White }
              );

            factory.ListFlyweights();

            var car1 = new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = Color.Red
            };


            Add(factory, car1);

            var car2 = new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = Color.Red
            };
            Add(factory, car2);


            factory.ListFlyweights();

            var car3 = new Car
            {
                Number = "ADlA98",
                Owner = "Tom Tom",
                Company = "BMW",
                Model = "X1",
                Color = Color.Red
            };
            Add(factory, car3);

            car3.CarFlyweight = new CarFlyweight { Color = Color.Black, Company = car3.Company, Model = car3.Model };
            Add(factory, car3);


            car3.CarFlyweight.Operation(car3);
            car2.CarFlyweight.Operation(car2);
            factory.ListFlyweights();

        }

        static void Add(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(car.CarFlyweight);
            car.CarFlyweight = flyweight;

            flyweight.Operation(car);
        }
    }
}
