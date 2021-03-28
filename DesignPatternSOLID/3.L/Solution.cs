using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._3.L
{
    public abstract class MathCalculate
    {
        public MathCalculate(int numberA, int numberB)
        {
            this.NumberB = numberB;
            this.NumberA = numberA;
        }
        public int NumberA { get; set; }
        public int NumberB { get; set; }

        public abstract int Calculate();
    }
    public class Addition : MathCalculate
    {
        public Addition(int numberA, int numberB) : base(numberA, numberB)
        {
        }

        public override int Calculate()
        {
            return this.NumberA + NumberB;
        }
    }
    public class Subtraction : MathCalculate
    {
        public Subtraction(int numberA, int numberB) : base(numberA, numberB)
        {
        }

        public override int Calculate()
        {
            return NumberA - NumberB;
        }
    }
}
