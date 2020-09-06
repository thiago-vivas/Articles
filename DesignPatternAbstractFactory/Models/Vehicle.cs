using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternAbstractFactory.Models
{
    public abstract class Vehicle
    {
        internal int capacity;
        public string GetData()
        {
            return this.GetType().Name;
        }
        public int GetCapacity()
        {
            return capacity;
        }
    }
}
