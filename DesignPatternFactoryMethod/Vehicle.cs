using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactoryMethod
{
    public abstract class Vehicle
    {
        internal int capacity;
        public abstract string GetData();

        public int GetCapacity()
        {
            return capacity;
        }
        public void AddPassengers(int passengers)
        {
            if (capacity < passengers)
            {
                throw new Exception(this.GetData() + " reached max capacity");
            }
            else
                capacity -= passengers;
        }

    }
}
