using DesignPatternAbstractFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAbstractFactory.Factory
{
    class LargeGroupFactory : AbstractFactory
    {
        public override Vehicle CreateLandVehicle()
        {
            return new Bus();
        }

        public override Vehicle CreateSeaVehicle()
        {
            return new Cruise();
        }
    }
}
