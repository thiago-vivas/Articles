using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._4.I.Problem
{
    public interface IAnimal
    {
        void Walk();
        void Breath();
        void Eat();
        void Argument();
    }

    public class Human : IAnimal
    {
        public void Argument()
        {
            // Argumentation
        }

        public void Breath()
        {
            // Breathing
        }

        public void Eat()
        {
            // Eating
        }

        public void Walk()
        {
            // Walk
        }
    }
    public class Whale : IAnimal
    {
        public void Argument()
        {
            // Argumentation
        }

        public void Breath()
        {
            // Breathing
        }

        public void Eat()
        {
            // Eating
        }

        public void Walk()
        {
            throw new NotImplementedException();
        }
    }
}
