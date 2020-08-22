using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    class Bus : Vehicle
    {

        public override string GetData()
        {
            return "I am a Bus!";
        }
    }
}
