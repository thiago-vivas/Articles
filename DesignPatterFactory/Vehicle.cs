using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternFactory
{
    public abstract class Vehicle
    {
        internal int capacity;
        public string GetData()
        {
            return this.GetType().ToString().Split(".")[1];
        }
        public int GetCapacity()
        {
            return capacity;
        }
        public void AddPassengers(int passengers)
        {
            if (capacity < passengers)
            {
                throw new Exception(this.GetData() +" reached max capacity");
            }
            else
                capacity -= passengers;
        }

    }
}
