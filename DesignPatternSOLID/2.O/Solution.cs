using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._2.O
{
    public abstract class BaseCalculation
    {
        public abstract double Calculate(double numberA, double numberB);
    }

    public class AdditionCalculation : BaseCalculation
    {
        public override double Calculate(double numberA, double numberB)
        {
            return numberA + numberB;
        }
    }
    public class MultiplicationCalculation : BaseCalculation
    {
        public override double Calculate(double numberA, double numberB)
        {
            return numberA * numberB;
        }
    }

    public class SubtractionCalculation : BaseCalculation
    {
        public override double Calculate(double numberA, double numberB)
        {
            return numberA - numberB;
        }
    }

    public class DivisionCalculation : BaseCalculation
    {
        public override double Calculate(double numberA, double numberB)
        {
            return numberA / numberB;
        }
    }
}
