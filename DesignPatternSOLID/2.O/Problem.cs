using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._2.O
{
    //here we have a class does math calculation with 3 operations, how would we do if need to include others?
    public class MathCalculate
    {
        public double Calculate(double numberA, double numberB, CalculationType calculationType)
        {
            double result = 0;
            switch (calculationType)
            {
                case CalculationType.addition:
                    result = numberA + numberB;
                    break;
                case CalculationType.multiplication:
                    result = numberA * numberB;
                    break;
                case CalculationType.subtraction:
                    result = numberA - numberB;
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    public enum CalculationType
    {
        addition,
        multiplication,
        subtraction
    }
}
