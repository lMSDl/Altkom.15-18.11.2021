using System;

namespace WPC.Behavioral.Strategy
{
    public class Client
    {
        public static void Execute()
        {
            var calculator = new Calculator();
            while (true)
            {
                var line = Console.ReadLine();

                var split = line.Split(' ');
                if (split.Length < 3)
                    continue;

                calculator.Strategy = GetCalcStrategy(split[1]);

                if (float.TryParse(split[0], out float val1) && float.TryParse(split[2], out float val2))
                {
                    var result = calculator.Operate(val1, val2);
                    Console.WriteLine(result);

                    result = GetStrategy(split[1]).Invoke(val1, val2);
                    Console.WriteLine(result);
                }

            }
        }

        private static ICalcStrategy GetCalcStrategy(string arg)
        {
            switch (arg)
            {
                case "*":
                    return new MultiplyCalcStrategy();
                case "/":
                    return new DivideCalcStrategy();
                case "+":
                    return new PlusCalcStrategy();
                case "-":
                    return new MinusCalcStrategy();
                default:
                    return null;
            }
        }

        private static Func<float, float, float> GetStrategy(string arg)
        {
            switch (arg)
            {
                case "*":
                    return (x, y) => x * y;
                case "/":
                    return (x, y) => x / y;
                case "+":
                    return (x, y) => x + y;
                case "-":
                    return (x, y) => x - y;
                default:
                    return null;
            }
        }
    }
}
