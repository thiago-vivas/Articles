using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactory
{
    public class VehicleCreator
    {
        public static Vehicle GetVehicle(int passengers)
        {
            if (passengers <= 5)
                return new Car();
            else if (passengers > 5 && passengers <= 50)
                return new Bus();
            else
                return new Boat();
        }
    }
}
