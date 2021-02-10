using System;
using System.Collections.Generic;

namespace VideoObjectReference
{
    class Program
    {
        static void  Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ErrorSamples samples = new ErrorSamples(null);
            samples.Run();
        }
    }
}
