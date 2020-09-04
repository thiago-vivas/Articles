using DesignPatternAbstractFactory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAbstractFactory.Factory
{
   abstract class AbstractFactory
    {
        public abstract Vehicle CreateLandVehicle();
        public abstract Vehicle CreateSeaVehicle();
    }
}
