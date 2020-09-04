using DesignPatternAbstractFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAbstractFactory.Factory
{
    class SmallGroupFactory : AbstractFactory
    {
        public override Vehicle CreateLandVehicle()
        {
            return new Car();
        }

        public override Vehicle CreateSeaVehicle()
        {
            return new Boat();
        }
    }
}
