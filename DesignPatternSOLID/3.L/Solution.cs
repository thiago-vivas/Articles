using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternSOLID._3.L
{
    abstract class Calculate
    {
        public int NumberA { get; set; }
        public int NumberB { get; set; }

        public abstract int Sum()
        {
            return new NotImplementedException();
        }
    }
}
