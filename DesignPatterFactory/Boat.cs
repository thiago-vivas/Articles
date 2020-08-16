using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterFactory
{
    public class Boat : IVehicle
    {
        public Boat()
        {
            base.capacity = 150;
        }
    }
}
