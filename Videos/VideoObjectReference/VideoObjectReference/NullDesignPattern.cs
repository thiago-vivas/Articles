using System;
using System.Collections.Generic;
using System.Text;

namespace VideoObjectReference
{
    public interface IComplexObject
    {
        void DoSomeStuff();
    }

    public class SampleComplexObject : IComplexObject
    {

        public void DoSomeStuff()
        {
            Console.WriteLine("\nI am a sample complex object!");
        }
    }

    public class NullComplexObject : IComplexObject
    {
        private NullComplexObject()
        { }
        private static NullComplexObject instance;

        public static NullComplexObject Instance
        {
            get
            {
                if (instance == null)
                    instance= new NullComplexObject();

                return instance;
            }
        }

        //do nothing methods  
        public void DoSomeStuff()
        { }
    }
}
