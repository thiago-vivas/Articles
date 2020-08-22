using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    public class CarCreator : VehicleCreator
    {
        protected override Vehicle MakeVehicle()
        {
            Vehicle vehicle = new Car();
            vehicle.capacity = 5;
            return vehicle;
        }
    }
}
