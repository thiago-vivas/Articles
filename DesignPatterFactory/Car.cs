using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterFactory
{
 public   class Car : IVehicle
    {
        public Car()
        {
            base.capacity = 5;
        }
    }
}
