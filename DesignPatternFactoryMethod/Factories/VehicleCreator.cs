using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    public abstract class VehicleCreator
    {
        protected abstract Vehicle MakeVehicle();

        public Vehicle CreateVehicle()
        {
            return this.MakeVehicle();
        }
    }
}