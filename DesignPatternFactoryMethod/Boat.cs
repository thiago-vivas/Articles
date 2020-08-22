using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    class Boat : Vehicle
    {
        public Boat()
        {
            base.capacity = 150;
        }

        public override string GetData()
        {
            return "I am a boat!";
        }
    }
}
