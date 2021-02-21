using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoObjectReference
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var existingItem = GetItem("anything");
            var nullItem = GetItem("anythingElse");

            existingItem.DoSomeStuff();
            nullItem.DoSomeStuff();

        }


        private static IComplexObject GetItem(string name)
        {
            if (name.Equals("anything"))
                return new SampleComplexObject();
            if (name.Equals("anything2"))
                return new SampleComplexObject();
            if (name.Equals("anything3"))
                return new SampleComplexObject();
            if (name.Equals("anything4"))
                return new SampleComplexObject();

            return NullComplexObject.Instance;
        }
        private static SampleObj GetNullObject()
        {
            return null;
        }
        private static SampleObj GetNewObject()
        {
            return new SampleObj { Item1 = "I exist." };
        }

    }

}