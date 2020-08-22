using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    public class BoatCreator : VehicleCreator
    {
        protected override Vehicle MakeVehicle()
        {
            Vehicle vehicle = new Boat();
            return vehicle;
        }
    }
}
