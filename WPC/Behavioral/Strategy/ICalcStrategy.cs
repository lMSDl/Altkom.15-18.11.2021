namespace WPC.Behavioral.Strategy
{
    public interface ICalcStrategy
    {
        float Calculate(float value1, float value2);
    }

    public class PlusCalcStrategy : ICalcStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return value1 + value2;
        }
    }

    public class MinusCalcStrategy : ICalcStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return value1 - value2;
        }
    }

    public class MultiplyCalcStrategy : ICalcStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return value1 * value2;
        }
    }

    public class DivideCalcStrategy : ICalcStrategy
    {
        public float Calculate(float value1, float value2)
        {
            return value1 / value2;
        }
    }
}
