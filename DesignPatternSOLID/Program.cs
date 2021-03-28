using DesignPatternSOLID._2.O;
using DesignPatternSOLID._3.L;
using DesignPatternSOLID._3.L.Problem;
using System;

namespace DesignPatternSOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdditionCalculation additionCalculation = new AdditionCalculation(3, 2);
            //SubtractionCalculation subtractionCalculation = new SubtractionCalculation(3, 2);
            //AdditionCalculation subtractionCalculationTwo = new SubtractionCalculation(3, 2);

            //var additionResult = additionCalculation.Calculate();
            //var subtractionResult = subtractionCalculation.Calculate();
            //var subtractionTwoResult = subtractionCalculationTwo.Calculate();


            //Addition additionCalculation2 = new Addition(3, 2);
            //Subtraction subtractionCalculation2 = new Subtraction(3, 2);
            //MathCalculate subtractionCalculationTwo2 = new Subtraction(3, 2);

            //var additionResult = additionCalculation2.Calculate();
            //var subtractionResult = subtractionCalculation2.Calculate();
            //var subtractionTwoResult = subtractionCalculationTwo2.Calculate();

            string sampleString = "Normal string";
            string newString = sampleString.ThiagoString();
        }
    }
}
