using System;
using System.Collections.Generic;
using System.Text;

namespace VideoObjectReference
{
    public class SampleObj
    {
        public string Item1 { get; set; }
        public SampleChildObj ChildObj { get; set; }
    }
    public class SampleChildObj
    {
        public string Item2 { get; set; }
    }
}
