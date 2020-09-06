using DesignPatternAbstractFactory.Factory;
using System;

namespace DesignPatternAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory factory = null;

            Console.WriteLine("Hello. How many passengers do you need?");
            int passengers = Convert.ToInt32(Console.ReadLine());
            if (passengers > 15)
                factory = new LargeGroupFactory();
            else
                factory = new SmallGroupFactory();

            var landVehicle = factory.CreateLandVehicle();
            var seaVehicle = factory.CreateSeaVehicle();

            Console.WriteLine("Land Vehicle : " + landVehicle.GetData() + ". With capacity of: " + landVehicle.GetCapacity());
            Console.WriteLine("Sea Vehicle : " + seaVehicle.GetData() + ". With capacity of: " + seaVehicle.GetCapacity());

        }
    }
}
