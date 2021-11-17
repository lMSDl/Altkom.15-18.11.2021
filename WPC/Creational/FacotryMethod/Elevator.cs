using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Creational.FacotryMethod
{
    public class Elevator
    {
        private readonly Dictionary<string, IElevatorOperation> _commands;

        public Elevator()
        {
            _commands = new Dictionary<string, IElevatorOperation>
            {
            { nameof(ElevatorGoTo), new ElevatorGoTo() },
            { nameof(ElevatorDown), new ElevatorDown() },
            { nameof(ElevatorUp), new ElevatorUp() },
            };
        }

        public void Execute(IElevatorOperation operation, int floor)
        {
            operation?.Operate(floor);
        }

        public void Execute(string operation, int floor)
        {
            CreateAction(operation)?.Operate(floor);
        }

        public IElevatorOperation CreateAction(string action)
        {
            return _commands[action];

            //switch (nameof(Elevator) + action)
            //{
            //    case nameof(ElevatorGoTo):
            //        return new ElevatorGoTo();
            //    case nameof(ElevatorDown):
            //        return new ElevatorDown();
            //    case nameof(ElevatorUp):
            //        return new ElevatorUp();
            //}
            //return null;
        }

    }

    public interface IElevatorOperation
    {
        void Operate(int floor);
    }
    public class ElevatorDown : IElevatorOperation
    {
        public void Operate(int floor)
        {
            Console.WriteLine($"Winda zatrzyma się na piętrze {floor} podczas jazdy w dół");
        }
    }
    public class ElevatorUp : IElevatorOperation
    {
        public void Operate(int floor)
        {
            Console.WriteLine($"Winda zatrzyma się na piętrze {floor} podczas jazdy do góry");
        }
    }
    public class ElevatorGoTo : IElevatorOperation
    {
        public void Operate(int floor)
        {
            Console.WriteLine($"Winda rusza na piętrzo {floor}");
        }
    }
}
