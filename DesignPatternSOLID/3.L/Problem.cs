using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._3.L.Problem
{
    public class AdditionCalculation
    {
        public AdditionCalculation(int numberA, int numberB)
        {
            this.NumberB = numberB;
            this.NumberA = numberA;
        }
        public int NumberA { get; set; }
        public int NumberB { get; set; }
        public virtual int Calculate()
        {
            return this.NumberA + NumberB;
        }
    }
    public class SubtractionCalculation : AdditionCalculation
    {
        public SubtractionCalculation(int numberA, int numberB) : base(numberA, numberB)
        {
        }

        public new int Calculate()
        {
            return NumberA - NumberB;
        }
    }
}
