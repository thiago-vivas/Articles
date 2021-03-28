using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._4.I
{

    public interface IFeed {
        void Eat();
    }

    public interface IArgument
    {
        void Argument();
    }

    public interface IGroundMoviment
    {
        void Walk();
    }
    public interface IAirMoviment
    {
        void Fly();
    }
    public interface IWaterMoviment
    {
        void Swimm();
    }

    public class Human : IGroundMoviment, IArgument, IFeed
    {
        public void Argument()
        {
            // Argument
        }

        public void Eat()
        {
            // Eat
        }

        public void Walk()
        {
            // Walk
        }
    }
    public class Whale : IWaterMoviment, IFeed
    {
        public void Eat()
        {
            // Eat
        }

        public void Swimm()
        {
            // Swimm
        }
    }
}
