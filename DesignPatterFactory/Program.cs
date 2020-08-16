using System;

namespace DesignPatternFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. How many passengers do you need?");
            int passengers = Convert.ToInt32(Console.ReadLine());
            var vehicle = VehicleCreator.GetVehicle(passengers);
            vehicle.AddPassengers(passengers);
            Console.WriteLine("Vehicle Type: " + vehicle.GetData() + ". With left capacity of: " + vehicle.GetCapacity());
        }
    }
}
