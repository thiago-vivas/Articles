using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    class Car : Vehicle
    {
        public Car()
        {
            base.capacity = 5;
        }

        public override string GetData()
        {
            return "I am a car!";
        }
    }
}
